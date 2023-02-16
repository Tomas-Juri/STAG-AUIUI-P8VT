using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.KeyVault;
using Pulumi.Random;
using AzureNative = Pulumi.AzureNative;
using Azure = Pulumi.Azure;
// ReSharper disable InconsistentNaming

return await Pulumi.Deployment.RunAsync(() =>
{

    var adminDbPassword = new RandomPassword("DbPassword",
        new RandomPasswordArgs { Length = 18, Special = true, OverrideSpecial = "%!?", MinSpecial = 3 }).Result;
    var adminDbName = "administrator";

    // Create an Azure Resource Group
    var resourceGroup = new ResourceGroup("cngroup-utb-2023");

    // Create azure key vault
    var keyVault = new Vault("vault", new()
    {
        Location = "westeurope",
        Properties = new AzureNative.KeyVault.Inputs.VaultPropertiesArgs
        {
            AccessPolicies = new[]
            {
                new AzureNative.KeyVault.Inputs.AccessPolicyEntryArgs
                {
                    ObjectId = "86ea30fb-2d8a-40e4-8ad5-dc7c9d186464",
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
                    TenantId = "26f15fac-00be-4a15-b787-1411dafe6c2e",
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
            TenantId = "26f15fac-00be-4a15-b787-1411dafe6c2e"
        },
        ResourceGroupName = resourceGroup.Name,
        VaultName = "cngroup-utb-2023",
    });
    var adminPasswordSecret = new Azure.KeyVault.Secret("cngroup-utb-2023-sql-admin-password", new()
    {
        Value = adminDbPassword,
        KeyVaultId = keyVault.Id,
    });
    
    // Create azure sql server
    var sqlServer = new Azure.Sql.SqlServer("cngroup-utb-2023", new()
    {
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        Version = "12.0",
        AdministratorLogin = adminDbName,
        AdministratorLoginPassword = adminDbPassword,
    });
    
    /*
     * Amundsen
     * HD kvalita
     * Nevime
     * ORZ
     * Sempa
     * ToPujde
     */

    var database_OS_InternalTest = new Azure.Sql.Database("OS_InternalTest", new()
    {
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        ServerName = sqlServer.Name
    });
    var database_OS_Amundsen = new Azure.Sql.Database("OS_Amundsen", new()
    {
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        ServerName = sqlServer.Name
    });
    var database_OS_HD_kvalita = new Azure.Sql.Database("OS_HD_kvalita", new()
    {
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        ServerName = sqlServer.Name
    });
    var database_OS_Nevime = new Azure.Sql.Database("OS_Nevime", new()
    {
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        ServerName = sqlServer.Name
    });
    var database_OS_ORZ = new Azure.Sql.Database("OS_ORZ", new()
    {
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        ServerName = sqlServer.Name
    });
    var database_OS_Sempa = new Azure.Sql.Database("OS_Sempa", new()
    {
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        ServerName = sqlServer.Name
    });
    var database_OS_ToPujde = new Azure.Sql.Database("OS_ToPujde", new()
    {
        ResourceGroupName = resourceGroup.Name,
        Location = resourceGroup.Location,
        ServerName = sqlServer.Name
    });


    void createUser(string databaseName, string username, string password)
    {
        
    }

    string GetConnectionString(string databaseName)
    {
        return $"Server=tcp:{sqlServer.Name}.database.windows.net,1433;Initial Catalog={databaseName};" +
               $"Persist Security Info=False;" +
               $"User ID={adminDbName};" +
               $"Password={adminDbPassword};" +
               $"MultipleActiveResultSets=False;" +
               $"Encrypt=True;" +
               $"TrustServerCertificate=False;" +
               $"Connection Timeout=30;";
    }        
});



// interpolatedStringHandler.AppendLiteral("CREATE USER ");
// interpolatedStringHandler.AppendFormatted(username);
// interpolatedStringHandler.AppendLiteral(" WITH PASSWORD='");
// interpolatedStringHandler.AppendFormatted(password);
// interpolatedStringHandler.AppendLiteral("'");
// ref StringBuilder.AppendInterpolatedStringHandler local1 = ref interpolatedStringHandler;
// stringBuilder3.AppendLine(ref local1);
// StringBuilder stringBuilder4 = stringBuilder1;
// StringBuilder stringBuilder5 = stringBuilder4;
// interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(43, 1, stringBuilder4);
// interpolatedStringHandler.AppendLiteral("EXEC sp_addrolemember N'db_datareader', N'");
// interpolatedStringHandler.AppendFormatted(username);
// interpolatedStringHandler.AppendLiteral("'");
// ref StringBuilder.AppendInterpolatedStringHandler local2 = ref interpolatedStringHandler;
// stringBuilder5.AppendLine(ref local2);
// StringBuilder stringBuilder6 = stringBuilder1;
// StringBuilder stringBuilder7 = stringBuilder6;
// interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(43, 1, stringBuilder6);
// interpolatedStringHandler.AppendLiteral("EXEC sp_addrolemember N'db_datawriter', N'");
// interpolatedStringHandler.AppendFormatted(username);
// interpolatedStringHandler.AppendLiteral("'");
// ref StringBuilder.AppendInterpolatedStringHandler local3 = ref interpolatedStringHandler;
// stringBuilder7.AppendLine(ref local3);
// StringBuilder stringBuilder8 = stringBuilder1;
// StringBuilder stringBuilder9 = stringBuilder8;
// interpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(41, 1, stringBuilder8);
// interpolatedStringHandler.AppendLiteral("EXEC sp_addrolemember N'db_ddladmin', N'");