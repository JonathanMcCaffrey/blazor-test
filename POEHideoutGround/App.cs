
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;


namespace POEHideoutGround
{
  public partial class App
  {


    private string Example {get; set;}

    [Inject]
    private HttpClient Http { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
      }

  }
}
