using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ModuleTopic6.EntityFrameworkCore;

[ConnectionStringName(ModuleTopic6DbProperties.ConnectionStringName)]
public interface IModuleTopic6DbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
