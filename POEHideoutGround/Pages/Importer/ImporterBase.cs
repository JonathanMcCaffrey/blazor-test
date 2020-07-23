using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BlazorInputFile;

namespace POEHideoutGround.Pages.Importer
{
  public class ImporterBase : ComponentBase
  {
    public string UploadedDataHideoutFormat { get; set; }

    protected async Task HandleFileSelected(IFileListEntry[] files)
    {
      if (files == null || files.Length == 0)
      {
        return;
      }

      var file = files[0];

      UploadedDataHideoutFormat = "";

      using (var reader = new System.IO.StreamReader(file.Data))
      {
        var line = await reader.ReadLineAsync();

        while (line != null)
        {
          UploadedDataHideoutFormat += line;

          line = await reader.ReadLineAsync();
        }
      }
    }


  }
}

