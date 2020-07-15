using Microsoft.AspNetCore.Components;
using POEHideoutGround.Data;
using System.Collections.Generic;

namespace POEHideoutGround.Components
{
    /// <summary>
    /// Test summary
    /// </summary>
    public class TileCalculatorBase : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string TileTypeName { get; set; }

        public string SelectedKey { get; set; }

        [Parameter]
        public TileData DefaultTileData { get; set; }

        [Parameter]
        public TileData[] TileData { get; set; }


        public bool IsDisabled { get; set; }

        [Parameter]
        public bool DefaultTile { get; set; }

        public void Toggle(object checkedValue)
        {
            IsDisabled = !(bool)checkedValue;
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            SelectedKey = DefaultTileData.Key;
        }

        [Parameter]
        public TileData SelectedTile
        {
            get
            {
                if (IsDisabled)
                {
                    return null;
                }

                foreach (var tile in TileData)
                {
                    if (tile.Key == SelectedKey)
                    {
                        return tile;
                    }
                }

                return null;
            }

            set { }
        }

        public string SelectedImage
        {
            get { return "images/tile/" + SelectedTile.Image + ".png"; }
        }
    }
}

