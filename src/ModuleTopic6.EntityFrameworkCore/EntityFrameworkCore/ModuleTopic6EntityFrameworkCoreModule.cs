using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ModuleTopic6.EntityFrameworkCore;

[DependsOn(
    typeof(ModuleTopic6DomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ModuleTopic6EntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ModuleTopic6DbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
