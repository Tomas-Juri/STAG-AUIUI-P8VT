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
using SecretArgs = Pulumi.AzureNative.KeyVault.SecretArgs;
using SkuName = Pulumi.AzureNative.KeyVault.SkuName;

// ReSharper disable InconsistentNaming

const string TenantId = "52992157-2a29-4fab-a811-3876d08e0bfe";

static string PrefixDashed(string name)
    => string.IsNullOrEmpty(name) ? "stag-auiui-p8vt--2025" : $"stag-auiui-p8vt-{name}";

static string PrefixZeroes(string name)
    => string.IsNullOrEmpty(name) ? "stag00auiui00p8vt002025" : $"stag00auiui00p8vt0020250{name}";

return await Pulumi.Deployment.RunAsync(() =>
{
    // Create passwords
    // Dont put dashes into usernames
    var adminDbUsername = "UtbAdministrator";
    var adminDbPassword = CreatePassword("administrator-password");

    var internalTestDbUsername = "InternalTestAdministrator";
    var internalTestDbPassword = CreatePassword("internal-test-password");

    var team1UserName = "TeamJednaAdministrator";
    var team1Password = CreatePassword("team-jedna-password");

    var team2UserName = "AlKaidaAdministrator";
    var team2Password = CreatePassword("al-kaida-password");

    var team3UserName = "HerculesAdministrator";
    var team3Password = CreatePassword("hercules-password");

    var team4UserName = "KohortaAdministrator";
    var team4Password = CreatePassword("kohorta-password");

    var team5UserName = "RGenAdministrator";
    var team5Password = CreatePassword("r-gen-password");

    var team6UserName = "StaciEAdministrator";
    var team6Password = CreatePassword("staci-e-password");

    var team7UserName = "TeamLoraxAdministrator";
    var team7Password = CreatePassword("team-lorax-password");

    Output<string> CreatePassword(string name) =>
        new RandomPassword(PrefixDashed(name),
                new RandomPasswordArgs { Length = 18, Special = true, OverrideSpecial = "%!?", MinSpecial = 3 })
            .Result;

    // Create an Azure Resource Group
    var resourceGroup = new ResourceGroup(PrefixDashed(string.Empty),
        new ResourceGroupArgs
        {
            ResourceGroupName = PrefixDashed(string.Empty),
            Location = "germanywestcentral"
        });

    // Create azure sql server
    var sqlServer = new Server(PrefixDashed(string.Empty),
        new()
        {
            ServerName = PrefixDashed(string.Empty),
            ResourceGroupName = resourceGroup.Name,
            Location = resourceGroup.Location,
            Version = "12.0",
            AdministratorLogin = adminDbUsername,
            AdministratorLoginPassword = adminDbPassword
        });

    var internalTestDatabase = CreateDatabase(PrefixDashed("internal-test"), sqlServer, resourceGroup);
    var team1database = CreateDatabase(PrefixDashed("team-jedna"), sqlServer, resourceGroup);
    var team2database = CreateDatabase(PrefixDashed("al-kaida"), sqlServer, resourceGroup);
    var team3database = CreateDatabase(PrefixDashed("hercules"), sqlServer, resourceGroup);
    var team4database = CreateDatabase(PrefixDashed("kohorta"), sqlServer, resourceGroup);
    var team5database = CreateDatabase(PrefixDashed("r-gen"), sqlServer, resourceGroup);
    var team6database = CreateDatabase(PrefixDashed("staci-e"), sqlServer, resourceGroup);
    var team7database = CreateDatabase(PrefixDashed("team-lorax"), sqlServer, resourceGroup);

    Database CreateDatabase(string name, Server server, ResourceGroup rg)
    {
        return new Database(name,
            new()
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
                RequestedBackupStorageRedundancy = BackupStorageRedundancy.Local,
            });
    }

    CreateSecret(PrefixDashed("administrator-password"), adminDbPassword);
    CreateSecret(PrefixDashed("internal-test-connection-string"),
        GetConnectionString(PrefixDashed("internal-test"), internalTestDbUsername, internalTestDbPassword));
    CreateSecret(PrefixDashed("team-jedna-connection-string"),
        GetConnectionString(PrefixDashed("team-jedna"), team1UserName, team1Password));
    CreateSecret(PrefixDashed("al-kaida-connection-string"), GetConnectionString(PrefixDashed("al-kaida"), team2UserName, team2Password));
    CreateSecret(PrefixDashed("hercules-connection-string"), GetConnectionString(PrefixDashed("hercules"), team3UserName, team3Password));
    CreateSecret(PrefixDashed("kohorta-connection-string"), GetConnectionString(PrefixDashed("kohorta"), team4UserName, team4Password));
    CreateSecret(PrefixDashed("r-gen-string"), GetConnectionString(PrefixDashed("r-gen"), team5UserName, team5Password));
    CreateSecret(PrefixDashed("staci-e-connection-string"), GetConnectionString(PrefixDashed("staci-e"), team6UserName, team6Password));
    CreateSecret(PrefixDashed("team-lorax-connection-string"),
        GetConnectionString(PrefixDashed("team-lorax"), team7UserName, team7Password));


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
        return new Secret(name,
            new SecretArgs
            {
                ResourceGroupName = resourceGroup.Name,
                SecretName = name,
                VaultName = "stag00auiui00p8vt002025",
                Properties = new AzureNative.KeyVault.Inputs.SecretPropertiesArgs
                {
                    Value = value,
                },
            });
    }

    // create db users
    Output.Tuple(adminDbPassword, internalTestDbPassword, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3,
            PrefixDashed("internal-test"),
            internalTestDbUsername,
            output.Item1,
            output.Item2));

    Output.Tuple(adminDbPassword, team1Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3,
            PrefixDashed("team-jedna"),
            team1UserName,
            output.Item1,
            output.Item2));

    Output.Tuple(adminDbPassword, team2Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3,
            PrefixDashed("al-kaida"),
            team2UserName,
            output.Item1,
            output.Item2));

    Output.Tuple(adminDbPassword, team3Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3,
            PrefixDashed("hercules"),
            team3UserName,
            output.Item1,
            output.Item2));

    Output.Tuple(adminDbPassword, team4Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3,
            PrefixDashed("kohorta"),
            team4UserName,
            output.Item1,
            output.Item2));

    Output.Tuple(adminDbPassword, team5Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3,
            PrefixDashed("r-gen"),
            team5UserName,
            output.Item1,
            output.Item2));

    Output.Tuple(adminDbPassword, team6Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3,
            PrefixDashed("staci-e"),
            team6UserName,
            output.Item1,
            output.Item2));

    Output.Tuple(adminDbPassword, team7Password, sqlServer.Name)
        .Apply(async output => await CreateUser(
            output.Item3,
            PrefixDashed("team-lorax"),
            team7UserName,
            output.Item1,
            output.Item2));


    async Task CreateUser(
        string sqlServerName,
        string databaseName,
        string username,
        string adminPassword,
        string password
    )
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
        return $"Server={sqlServerName}.database.windows.net,1433;" +
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
    var appServicePlan = new AppServicePlan(PrefixDashed(string.Empty),
        new()
        {
            Kind = "app",
            Location = "germanywestcentral",
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
    CreateWebApp(PrefixDashed("team-jedna"), appServicePlan);
    CreateWebApp(PrefixDashed("al-kaida"), appServicePlan);
    CreateWebApp(PrefixDashed("hercules"), appServicePlan);
    CreateWebApp(PrefixDashed("kohorta"), appServicePlan);
    CreateWebApp(PrefixDashed("r-gen"), appServicePlan);
    CreateWebApp(PrefixDashed("staci-e"), appServicePlan);
    CreateWebApp(PrefixDashed("team-lorax"), appServicePlan);

    WebApp CreateWebApp(string name, AppServicePlan appServicePlan)
    {
        return new WebApp(name,
            new WebAppArgs
            {
                Name = name,
                ResourceGroupName = resourceGroup.Name,
                RedundancyMode = RedundancyMode.None,
                Kind = "app",
                Location = "germanywestcentral",
                ServerFarmId = appServicePlan.Name
            });
    }
});
