using Microsoft.AspNetCore.Components;
using POEHideoutGround.Shared;
using System.Collections.Generic;

namespace POEHideoutGround.Components
{
    public class TileCalculatorBase : ComponentBase
    {
        public int SelectedKey = 0;

        [Parameter]
        public TileData DefaultTileData { get; set; }

        [Parameter]
        public IEnumerable<TileData> TileData { get; set; }


        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool DefaultTile { get; set; }

        public void Toggle(object checkedValue)
        {

        }
    }
}
