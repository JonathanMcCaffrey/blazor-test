using Data;
using Microsoft.AspNetCore.Components;
using POEHideoutGround.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POEHideoutGround.Components
{
    public class TileCalculatorBase : ComponentBase
    {
        int SelectedKey = 0;

        [Parameter]
        public TileData DefaultTileData { get; set; }

        [Parameter]
        public TileData[] TileDataList { get; set; }


        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public bool DefaultTile { get; set; }
    }
}
