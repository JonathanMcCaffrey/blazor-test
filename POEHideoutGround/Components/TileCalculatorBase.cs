using Microsoft.AspNetCore.Components;
using POEHideoutGround.Data;
using System.Threading.Tasks;

namespace POEHideoutGround.Components
{
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


        [Parameter]
        public bool CheckedByDefault { get; set; } = false;


        private bool _isDisabled;
        [Parameter]
        public bool IsDisabled { get { return _isDisabled;  } 
            set {
                _isDisabled = value;
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


            IsDisabled = !CheckedByDefault;
            SelectedKey = DefaultTileData.Key;

            OnSelectedTileChanged();

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                SelectedKey = DefaultTileData.Key;

                IsDisabled = !CheckedByDefault;

                await OnSelectedTileChanged();


            }
        }


        [Parameter]
        public EventCallback<TileData> SelectedTileChanged { get; set; }

        public Task OnSelectedTileChanged()
        {
            return SelectedTileChanged.InvokeAsync(SelectedTile);
        }

        public void Refresh()
        {
            SelectedKey = DefaultTileData.Key;
            OnSelectedTileChanged();
        }

        [Parameter]
        public TileData SelectedTile
        {
            get
            {
                if (IsDisabled || TileData == null)
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

