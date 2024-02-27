using Microsoft.EntityFrameworkCore;
using ModuleTopic6.OrderLists;
using ModuleTopic6.Orders;
using ModuleTopic6.Products;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ModuleTopic6.EntityFrameworkCore;

public static class ModuleTopic6DbContextModelCreatingExtensions
{
    public static void ConfigureModuleTopic6(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(ModuleTopic6DbProperties.DbTablePrefix + "Questions", ModuleTopic6DbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.Entity<Product>(p =>
        {
            p.ToTable("Products");
            p.ConfigureByConvention();
        });
        builder.Entity<Order>(o =>
        {
            o.ToTable("Orders");
            o.ConfigureByConvention();
            o.HasMany(o => o.OrderLists)
                .WithOne(o => o.Order)
                .HasForeignKey(p => p.OrderId)
                .IsRequired();
        });
        builder.Entity<OrderList>(ol =>
        {
            ol.ToTable("OrderLists");
            ol.ConfigureByConvention();
        });
    }
}
