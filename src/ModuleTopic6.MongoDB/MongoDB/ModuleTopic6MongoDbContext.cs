using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ModuleTopic6.MongoDB;

[ConnectionStringName(ModuleTopic6DbProperties.ConnectionStringName)]
public class ModuleTopic6MongoDbContext : AbpMongoDbContext, IModuleTopic6MongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureModuleTopic6();
    }
}
