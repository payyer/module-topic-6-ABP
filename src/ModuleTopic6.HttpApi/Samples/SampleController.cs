using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace ModuleTopic6.Samples;

[Area(ModuleTopic6RemoteServiceConsts.ModuleName)]
[RemoteService(Name = ModuleTopic6RemoteServiceConsts.RemoteServiceName)]
[Route("api/ModuleTopic6/sample")]
public class SampleController : ModuleTopic6Controller, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;


    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpPost]
    public async Task<SampleDto> DeleteAsync(int id)
    {
        return new SampleDto() { Value = id };
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }

}
