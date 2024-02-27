using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ModuleTopic6.MongoDB;

[ConnectionStringName(ModuleTopic6DbProperties.ConnectionStringName)]
public interface IModuleTopic6MongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
