using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ModuleTopic6.Pages;

public class IndexModel : ModuleTopic6PageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
