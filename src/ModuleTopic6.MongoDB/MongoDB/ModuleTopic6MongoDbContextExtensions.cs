using Volo.Abp;
using Volo.Abp.MongoDB;

namespace ModuleTopic6.MongoDB;

public static class ModuleTopic6MongoDbContextExtensions
{
    public static void ConfigureModuleTopic6(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
