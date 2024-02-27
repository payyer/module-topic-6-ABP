using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace ModuleTopic6.MongoDB;

[DependsOn(
    typeof(ModuleTopic6DomainModule),
    typeof(AbpMongoDbModule)
    )]
public class ModuleTopic6MongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<ModuleTopic6MongoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
        });
    }
}
