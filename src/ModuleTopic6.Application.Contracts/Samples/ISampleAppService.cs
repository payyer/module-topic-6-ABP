using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ModuleTopic6.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();

    Task<SampleDto> DeleteAsync(int id);
}
