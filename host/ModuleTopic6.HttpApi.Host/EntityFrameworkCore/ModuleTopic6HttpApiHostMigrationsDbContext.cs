using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ModuleTopic6.EntityFrameworkCore;

public class ModuleTopic6HttpApiHostMigrationsDbContext : AbpDbContext<ModuleTopic6HttpApiHostMigrationsDbContext>
{

    public ModuleTopic6HttpApiHostMigrationsDbContext(DbContextOptions<ModuleTopic6HttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureModuleTopic6();
    }
}
