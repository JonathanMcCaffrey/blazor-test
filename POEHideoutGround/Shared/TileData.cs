using Microsoft.AspNetCore.Components;
using System;

//TODO Can't make new namespaces. VS Studio or Blazor bug?
//namespace POEHideoutGround.Data
namespace POEHideoutGround.Shared
{
    public class TileData : ComponentBase
    {
        /// <summary>
        /// Human readable asset name.
        /// </summary>
        [Parameter]
        public string Name { get; set; }

        /// <summary>
        /// Display variant used of asset.
        /// </summary>
        [Parameter]
        public string Var { get; set; }

        /// <summary>
        /// Identifiction hash of the static asset reference.
        /// </summary>
        [Parameter]
        public string Hash { get; set; }

        /// <summary>
        /// Unique variant/hash key used by the calculator.
        /// </summary>
        [Parameter]
        public int Key
        {
            get
            {
                return int.Parse(Hash) * 100 + int.Parse(Var);
            }
        }

        /// <summary>
        /// The variant displayed to the player in-game. Which is the variant number + 1
        ///</summary>
        public string DisplayVar { get { return (int.Parse(Var) + 1).ToString(); } }


        #region unused
        /// <summary>
        /// Asset instance X position in the hideout
        /// </summary>
        [Parameter]
        public int X { get; set; }

        /// <summary>
        /// Asset instance Y position in the hideout
        ///</summary>
        [Parameter]
        public int Y { get; set; }

        /// <summary>
        /// Asset instance rotation in the hideout. 90 degrees represented by the value 16385.
        /// </summary>
        [Parameter]
        public int Rot { get; set; }

        /// <summary>
        /// Asset instance mirroring in the hideout. Probably mirrored on the X-axis.
        /// </summary>
        [Parameter]
        public bool Flip { get; set; }
        #endregion

        public TileData() { }

        public TileData(string name, string var, string hash)
        {
            Name = name;
            Var = var;
            Hash = hash;
        }
    }
}