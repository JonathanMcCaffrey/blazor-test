using System.Net.Http;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using POEHideoutGround.Data.Navbar;

namespace POEHideoutGround.Shared.NavMenu
{
  public class NavMenuBase : ComponentBase
  {

    [Inject]
    private HttpClient Http { get; set; }

    private bool collapseNavMenu = true;

    public string versionNumber = "0.3.0";

    protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    protected void ToggleNavMenu()
    {
      collapseNavMenu = !collapseNavMenu;
    }



    Navbar Navbar { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Navbar = await Http.GetJsonAsync<Navbar>("data/data.json");
    }


  }

}