using Volo.Abp.Modularity;

namespace ModuleTopic6;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class ModuleTopic6ApplicationTestBase<TStartupModule> : ModuleTopic6TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
