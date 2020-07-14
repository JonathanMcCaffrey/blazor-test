
namespace POEHideoutGround.Data
{
    public class TileData
    {
        /// <summary>
        /// Human readable asset name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Display variant used of asset.
        /// </summary>
        public string Var { get; set; }

        /// <summary>
        /// Identifiction hash of the static asset reference.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Unique variant/hash key used by the calculator.
        /// </summary>
        public int Key
        {
            get { return int.Parse(Hash) * 100 + int.Parse(Var); }
        }


        /// <summary>
        /// The variant displayed to the player in-game. Which is the variant number + 1
        ///</summary>
        public string DisplayVar { get { return (int.Parse(Var) + 1).ToString(); } }


        #region unused
        /// <summary>
        /// Asset instance X position in the hideout
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Asset instance Y position in the hideout
        ///</summary>
        public int Y { get; set; }

        /// <summary>
        /// Asset instance rotation in the hideout. 90 degrees represented by the value 16385.
        /// </summary>
        public int Rot { get; set; }

        /// <summary>
        /// Asset instance mirroring in the hideout. Probably mirrored on the X-axis.
        /// </summary>
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