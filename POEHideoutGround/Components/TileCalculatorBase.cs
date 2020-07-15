using Microsoft.AspNetCore.Components;
using POEHideoutGround.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

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


        private string _selectedKey;
        public string SelectedKey { get { return _selectedKey; } 
            set {
                _selectedKey = value;
                OnSelectedTileChanged();
            }
        }

        [Parameter]
        public TileData DefaultTileData { get; set; }

        [Parameter]
        public TileData[] TileData { get; set; }

        private bool _isDisbled;
        public bool IsDisabled { get { return _isDisbled;  } 
            set { 
                _isDisbled = value;
                OnSelectedTileChanged();
            } }

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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                OnSelectedTileChanged();
            }
        }


        [Parameter]
        public EventCallback<TileData> SelectedTileChanged { get; set; }

        public Task OnSelectedTileChanged()
        {
            return SelectedTileChanged.InvokeAsync(SelectedTile);
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

