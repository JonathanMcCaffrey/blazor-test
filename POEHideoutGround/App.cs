using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MatBlazor;


namespace POEHideoutGround
{
    public partial class App
    {


        [Inject]
        private HttpClient Http { get; set; }


        MatTheme lightTheme = new MatTheme()
        {
            Primary = "#39796b",
            Secondary = "#b4a647",
            OnPrimary = "#ffffff",
            OnSecondary = "#000000",
            OnSurface = "#000000",
            Surface = "#ffffff"

        };

        MatTheme darkTheme = new MatTheme()
        {
            Primary = "#00251a",
            Secondary = "#524a00",
            OnPrimary = "#ffffff",
            OnSecondary = "#ffffff",
            OnSurface = "#ffffff",
            Surface= "#12120C",
            
        };

    }
}
