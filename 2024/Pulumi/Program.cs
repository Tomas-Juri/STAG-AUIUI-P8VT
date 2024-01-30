using System.Data.SqlClient;
using System.Threading.Tasks;
using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.KeyVault;
using Pulumi.AzureNative.Sql;
using Pulumi.AzureNative.Sql.Inputs;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;
using Pulumi.Random;
using AzureNative = Pulumi.AzureNative;

// ReSharper disable InconsistentNaming

const string TenantId = "0f823349-2c12-431b-a03c-b2c0a43d6fb4";

static string PrefixDashed(string name)
    => string.IsNullOrEmpty(name) ? "utb--2024" : $"utb--2024-{name}";

static string PrefixZeroes(string name)
    => string.IsNullOrEmpty(name) ? "utb002024" : $"utb0020240{name}";

return await Pulumi.Deployment.RunAsync(() =>
{
    // Create passwords
    // Dont put dashes into usernames
    var adminDbUsername = "UtbAdministrator";
    var adminDbPassword = CreatePassword("administrator-password");

    var internalTestDbUsername = "InternalTestAdministrator";
    var internalTestDbPassword = CreatePassword("internal-test-password");

    var team1UserName = "Team1Administrator";
    var team1Password = CreatePassword("team1-password");

    var team2UserName = "Team2Administrator";
    var team2Password = CreatePassword("team2-password");

    var team3UserName = "Team3Administrator";
    var team3Password = CreatePassword("team3-password");

    var team4UserName = "Team4Administrator";
    var team4Password = CreatePassword("team4-password");

    Output<string> CreatePassword(string name) =>
        new RandomPassword(PrefixDashed(name),
                new RandomPasswordArgs { Length = 18, Special = true, OverrideSpecial = "%!?", MinSpecial = 3 })
            .Result;
    
    // Create an Azure Resource Group
    var resourceGroup = new ResourceGroup(PrefixDashed(string.Empty), new ResourceGroupArgs
    {
        ResourceGroupName = PrefixDashed(string.Empty),
        Location = "westeurope"
    });

    // Create azure key vault
    var keyVault = new Vault(PrefixZeroes(string.Empty), new()
    {
        VaultName = PrefixZeroes(string.Empty),
        Location = "westeurope",
        Properties = new AzureNative.KeyVault.Inputs.VaultPropertiesArgs
        {
            AccessPolicies = new[]
            {
                new AzureNative.KeyVault.Inputs.AccessPolicyEntryArgs
                {
                    ObjectId = "03ab3783-6c0a-4010-a32e-d24a21e31481",
                    Permissions = new AzureNative.KeyVault.Inputs.PermissionsArgs
                    {
                        Secrets = new InputList<Union<string, SecretPermissions>>
                        {
                            "get",
                            "list",
                            "set",
                            "delete",
                            "backup",
                            "restore",
                            "recover",
                            "purge",
                        },
                    },
                    TenantId = TenantId
                },
            },

            EnabledForDeployment = true,
            EnabledForDiskEncryption = true,
            EnabledForTemplateDeployment = true,
            Sku = new AzureNative.KeyVault.Inputs.SkuArgs
            {
                Family = "A",
                Name = SkuName.Standard,
            },
            TenantId = TenantId
        },
        ResourceGroupName = resourceGroup.Name
    });

    // Create azure sql server
    var sqlServer = new Server(PrefixDashed(string.Empty), new()
    {
        ServerName = PrefixDashed(string.Empty),
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        Version = "12.0",
        AdministratorLogin = adminDbUsername,
        AdministratorLoginPassword = adminDbPassword
    });

    var internalTestDatabase = CreateDatabase(PrefixDashed("internal-test"), sqlServer, resourceGroup);
    var team1database = CreateDatabase(PrefixDashed("team1"), sqlServer, resourceGroup);
    var team2database = CreateDatabase(PrefixDashed("team2"), sqlServer, resourceGroup);
    var team3database = CreateDatabase(PrefixDashed("team3"), sqlServer, resourceGroup);
    var team4database = CreateDatabase(PrefixDashed("team4"), sqlServer, resourceGroup);

    Database CreateDatabase(string name, Server server, ResourceGroup rg)
    {
        return new Database(name, new()
        {
            DatabaseName = name,
            ResourceGroupName = rg.Name,
            Location = rg.Location,
            ServerName = server.Name,
            Sku = new SkuArgs
            {
                Name = "Basic",
                Tier = "Basic",
                Size = "2"
            },
            RequestedBackupStorageRedundancy = RequestedBackupStorageRedundancy.Local
        });
    }
    
    CreateSecret(PrefixDashed("administrator-password"), adminDbPassword);
    CreateSecret(PrefixDashed("internal-test-connection-string"), GetConnectionString(PrefixDashed("internal-test"), internalTestDbUsername, internalTestDbPassword));
    CreateSecret(PrefixDashed("team1-connection-string"), GetConnectionString(PrefixDashed("team1"), team1UserName, team1Password));
    CreateSecret(PrefixDashed("team2-connection-string"), GetConnectionString(PrefixDashed("team2"), team2UserName, team2Password));
    CreateSecret(PrefixDashed("team3-connection-string"), GetConnectionString(PrefixDashed("team3"), team3UserName, team3Password));
    CreateSecret(PrefixDashed("team4-connection-string"), GetConnectionString(PrefixDashed("team4"), team4UserName, team4Password));


    Output<string> GetConnectionString(string databaseName, string userName, Output<string> password)
    {
        return password.Apply(value => $"Server=tcp::{PrefixDashed(string.Empty)}.database.windows.net,1433;" +
                                       $"Initial Catalog={databaseName};" +
                                       $"Persist Security Info=False;" +
                                       $"User ID={userName};" +
                                       $"Password={value};" +
                                       $"MultipleActiveResultSets=False;" +
                                       $"Encrypt=True;" +
                                       $"TrustServerCertificate=False;" +
                                       $"Connection Timeout=30;");
    }
    
    Secret CreateSecret(string name, Output<string> value)
    {
        return new Secret(name, new SecretArgs()
        {
            ResourceGroupName = resourceGroup.Name,
            SecretName = name,
            VaultName = keyVault.Name,
            Properties = new AzureNative.KeyVault.Inputs.SecretPropertiesArgs
            {
                Value = value,
            },
        });
    }

    // create db users
    Output.Tuple(adminDbPassword, internalTestDbPassword, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3, PrefixDashed("internal-test"),
            internalTestDbUsername, output.Item1, output.Item2));

    Output.Tuple(adminDbPassword, team1Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3, PrefixDashed("team1"), team1UserName,
            output.Item1, output.Item2));

    Output.Tuple(adminDbPassword, team2Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3, PrefixDashed("team2"), team1UserName,
            output.Item1, output.Item2));

    Output.Tuple(adminDbPassword, team3Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3, PrefixDashed("team3"), team1UserName,
            output.Item1, output.Item2));

    Output.Tuple(adminDbPassword, team4Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3, PrefixDashed("team4"), team1UserName,
            output.Item1, output.Item2));


    async Task CreateUser(string sqlServerName, string databaseName, string username, string adminPassword,
        string password)
    {
        var connString = GetAdminConnectionString(sqlServerName, databaseName, adminPassword);
        await using var sqlConn = new SqlConnection(connString);
        await sqlConn.OpenAsync();

        await using SqlCommand dropCmd = new($"DROP USER IF EXISTS {username}", sqlConn);
        await using SqlCommand createCmd = new($"CREATE USER {username} WITH PASSWORD='{password}'", sqlConn);
        await using SqlCommand dataReaderCmd = new($"EXEC sp_addrolemember N'db_datareader', N'{username}'", sqlConn);
        await using SqlCommand dataWriterCmd = new($"EXEC sp_addrolemember N'db_datawriter', N'{username}'", sqlConn);
        await using SqlCommand ddlAdminCmd = new($"EXEC sp_addrolemember N'db_ddladmin', N'{username}'", sqlConn);
        
        await dropCmd.ExecuteNonQueryAsync();
        await createCmd.ExecuteNonQueryAsync();
        await dataReaderCmd.ExecuteNonQueryAsync();
        await dataWriterCmd.ExecuteNonQueryAsync();
        await ddlAdminCmd.ExecuteNonQueryAsync();
    }

    string GetAdminConnectionString(string sqlServerName, string databaseName, string adminPassword)
    {
        adminDbPassword.Apply(password =>
        {
            Log.Info($"{sqlServerName} {databaseName} {adminDbUsername} {password}");
            return password;
        });
        
        return $"Server=tcp:{sqlServerName}.database.windows.net,1433;" +
               $"Initial Catalog={databaseName};" +
               $"Persist Security Info=False;" +
               $"User ID={adminDbUsername};" +
               $"Password={adminPassword};" +
               $"MultipleActiveResultSets=False;" +
               $"Encrypt=True;" +
               $"TrustServerCertificate=False;" +
               $"Connection Timeout=30;";
    }

    // Apps
    var appServicePlan = new AppServicePlan(PrefixDashed(string.Empty), new()
    {
        Kind = "app",
        Location = "westeurope",
        Name = PrefixDashed(string.Empty),
        ResourceGroupName = resourceGroup.Name,
        Sku = new SkuDescriptionArgs
        {
            Capacity = 1,
            Family = "B",
            Name = "B1",
            Size = "B1",
            Tier = "Basic",
        }
    });
    CreateWebApp(PrefixDashed("internal-test"), appServicePlan);
    CreateWebApp(PrefixDashed("team1"), appServicePlan);
    CreateWebApp(PrefixDashed("team2"), appServicePlan);
    CreateWebApp(PrefixDashed("team3"), appServicePlan);
    CreateWebApp(PrefixDashed("team4"), appServicePlan);

    WebApp CreateWebApp(string name, AppServicePlan appServicePlan)
    {
        return new WebApp(name, new WebAppArgs
        {
            Name = name,
            ResourceGroupName = resourceGroup.Name,
            RedundancyMode = RedundancyMode.None,
            Kind = "app",
            Location = "westeurope",
            ServerFarmId = appServicePlan.Name
        });
    }
});
