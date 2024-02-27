using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ModuleTopic6.EntityFrameworkCore;

public class ModuleTopic6HttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<ModuleTopic6HttpApiHostMigrationsDbContext>
{
    public ModuleTopic6HttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ModuleTopic6HttpApiHostMigrationsDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new ModuleTopic6HttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
