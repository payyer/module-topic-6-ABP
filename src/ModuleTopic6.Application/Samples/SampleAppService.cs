using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ModuleTopic6.Samples;

public class SampleAppService : ModuleTopic6AppService, ISampleAppService
{
    public Task<SampleDto> GetAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    public Task<SampleDto> DeleteAsync(int id)
    {
        return Task.FromResult(
           new SampleDto
           {
               Value = id
           }
       );
    }
}
