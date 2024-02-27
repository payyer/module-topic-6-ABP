using Microsoft.EntityFrameworkCore;
using ModuleTopic6.OrderLists;
using ModuleTopic6.Orders;
using ModuleTopic6.Products;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ModuleTopic6.EntityFrameworkCore;

[ConnectionStringName(ModuleTopic6DbProperties.ConnectionStringName)]
public class ModuleTopic6DbContext : AbpDbContext<ModuleTopic6DbContext>, IModuleTopic6DbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderList> OrderLists { get; set; }

    public ModuleTopic6DbContext(DbContextOptions<ModuleTopic6DbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureModuleTopic6();
    }
}
