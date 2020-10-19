using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using POEHideoutGround.Data.Navbar;

namespace POEHideoutGround.Shared.NavMenu
{
    public partial class NavMenu : ComponentBase
    {

        [Inject]
        private HttpClient Http { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        private bool collapseNavMenu = true;

        public string versionNumber = "0.3.0";

        protected string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        protected void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected void ToggleTheme()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        public Navbar Navbar { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var text = await Http.GetStringAsync("data/navbar/data.json");
            Navbar = JsonConvert.DeserializeObject<Navbar>(text);
        }
    }
}