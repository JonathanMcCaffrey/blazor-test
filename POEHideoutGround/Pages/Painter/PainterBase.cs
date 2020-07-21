using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using POEHideoutGround.Components;
using POEHideoutGround.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace POEHideoutGround.Pages.Painter
{
    public class PainterBase : ComponentBase
    {

        [Inject]
        private HttpClient Http { get; set; }


        int minX = 153;
        int minY = 559;
        int maxX = 560;
        int maxY = 153;

        int minTileSize = 23;

        int tileCanvasWidth = 17;
        int tileCanvasHeight = 17;

        List<TileData> canvasData;

        protected int BrushSize { get; set; }


        protected string SelectedBrushKey { get; set; } = "2825914735_1";


        public static TileData DefaultBrush = new TileData(name: "Arctic", var: "1", hash: "2825914735", image: "arctic_2_l", size: 69);

        public TileData SelectedBrush
        {
            get
            {

                if (BrushData == null) return DefaultBrush;

                foreach (var tile in BrushData)
                {
                    if (tile.Key == SelectedBrushKey)
                    {
                        return tile;
                    }
                }

                // Should never be null
                return null;
            }

            set { }
        }


        protected List<TileData> BrushData;

        protected override async Task OnInitializedAsync()
        {

            BrushData = await Http.GetJsonAsync<List<TileData>>("data/ground.json");
        }


        protected bool IsPainting { get; set; } = false;
        protected void OnMouseDown(MouseEventArgs mouseEventArgs)
        {
            IsPainting = true;
        }

        protected void OnMouseUp(MouseEventArgs mouseEventArgs)
        {
            IsPainting = false;
        }

        protected void OnMouseOut(MouseEventArgs mouseEventArgs)
        {
            //TODO Better implementation
            OnMouseUp(mouseEventArgs);
        }


    }
}

