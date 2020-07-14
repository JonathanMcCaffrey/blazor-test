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


        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public Class1 Test;

        
        [Parameter]
        public bool DefaultTile { get; set; }
    }
}
