using Volo.Abp.Modularity;

namespace ModuleTopic6;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class ModuleTopic6DomainTestBase<TStartupModule> : ModuleTopic6TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
