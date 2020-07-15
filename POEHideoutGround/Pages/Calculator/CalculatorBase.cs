using Microsoft.AspNetCore.Components;
using POEHideoutGround.Data;
using System;
using System.Collections.Generic;

namespace POEHideoutGround.Pages.Calculator
{
    /// <summary>
    /// Test summary
    /// </summary>
    public class CalculatorBase : ComponentBase
    {

        public static TileData DefaultGroundTile = new TileData(name: "Dirt Ground", var: "2", hash: "1798490749", image: "dirt_3_l");
        public static TileData DefaultWaterTile = new TileData(name: "Water Plane", var: "22", hash: "1179014731", image: "water_23_l");
        public static TileData DefaultGrassPatchesTile = new TileData(name: "Grass Patch", var: "4", hash: "3856837925", image: "grasspatch_5_l");


        public bool groundDisabled { get; set; } = false;
        void GroundToggle(object checkedValue)
        {
            groundDisabled = !(bool)checkedValue;
        }

        public bool waterDisabled { get; set; } = true;
        void WaterToggle(object checkedValue)
        {
            waterDisabled = !(bool)checkedValue;
        }

        public bool grassPatchesDisabled { get; set; } = true;
        void GrassPatchesToggle(object checkedValue)
        {
            grassPatchesDisabled = !(bool)checkedValue;
        }

        string SelectedGroundKey { get; set; } = DefaultGroundTile.Key;
        string SelectedWaterKey { get; set; } = DefaultWaterTile.Key;
        string SelectedGrassPatchesKey { get; set; } = DefaultGrassPatchesTile.Key;

        #region varibles
        int minX = 153;
        int minY = 559;
        int maxX = 560;
        int maxY = 153;

        int xOffset = 6;
        int yOffset = 6;

        int largeTileDimensions = 69;
        int grassPatchDimensions = 30;

        public int currentCount = 0;

        public string layoutData = "";

        string defaultRotation = "0";
        // Rotation Data
        //Rot=49152
        //Rot=32768
        //Rot=16385
        //Rot=1

        // Set in Calculator.razor, as I can't seem to easily set this otherwise...
        public TileData[] groundData;
        public TileData[] waterData;
        public TileData[] grassPatchesData;


        public TileData SelectedGroundTile
        {
            get
            {
                if (groundDisabled)
                {
                    return null;
                }

                foreach (var tile in groundData)
                {
                    if (tile.Key == SelectedGroundKey)
                    {
                        return tile;
                    }
                }

                return null;
            }
        }

        public TileData SelectedWaterTile
        {
            get
            {
                if (waterDisabled)
                {
                    return null;
                }

                foreach (var tile in waterData)
                {
                    if (tile.Key == SelectedWaterKey)
                    {
                        return tile;
                    }
                }

                return null;
            }
        }

        public TileData SelectedGrassPatchesTile
        {
            get
            {
                if (grassPatchesDisabled)
                {
                    return null;
                }

                foreach (var tile in grassPatchesData)
                {
                    if (tile.Key == SelectedGrassPatchesKey)
                    {
                        return tile;
                    }
                }

                return null;
            }
        }



        #endregion



        public void Generate()
        {
            ClearLayoutData();
            GenerateGround();
            GenerateWater();
            GenerateGrassPatches();

            ErrorCatching();
        }


        public void Clear()
        {
            ClearLayoutData();
        }

        public void Copy()
        {
            layoutData = "Copy to clipboard not implemented";
        }


        public void ClearLayoutData()
        {
            currentCount = 0;
            layoutData = "";
        }

        public void ErrorCatching()
        {
            if (layoutData == "")
            {
                layoutData = "No layout could be generated. Please ensure you have selected a tile, and you have it's generation enabled.";
            }
        }

        public void GenerateGround()
        {
            if (SelectedGroundTile == null) { return; }

            int debugLimit = 0;
            for (int x = minX + xOffset; x <= maxX; x += largeTileDimensions)
            {
                for (int y = minY - yOffset; y >= maxY; y -= largeTileDimensions)
                {
                    layoutData += $"{SelectedGroundTile.Name} = {{ Hash={SelectedGroundTile.Hash}, X={x}, Y={y}, Rot={defaultRotation}, Flip=0, Var={SelectedGroundTile.Var} }}\n";


                    currentCount++;
                    if (debugLimit++ > 10)
                    {
                        //    return;
                    }
                }
            }
        }


        public void GenerateWater()
        {
            if (SelectedWaterTile == null) { return; }


            for (int x = minX + xOffset; x <= maxX; x += largeTileDimensions)
            {
                for (int y = minY - yOffset; y >= maxY; y -= largeTileDimensions)
                {
                    layoutData += $"{SelectedWaterTile.Name} = {{ Hash={SelectedWaterTile.Hash}, X={x}, Y={y}, Rot={defaultRotation}, Flip=0, Var={SelectedWaterTile.Var} }}\n";

                    currentCount++;
                }
            }
        }



        private int _grassPlacementChaos = 24;
        public int GrassPlacementChaos
        {
            get
            {
                return _grassPlacementChaos;
            }

            set
            {
                if (value >= 0 && value <= 48)
                {
                    _grassPlacementChaos = value;
                }
                else if (value < 0)
                {
                    _grassPlacementChaos = 0;
                }
                else if (value > 48)
                {
                    _grassPlacementChaos = 48;
                }
            }
        }

        private int _grassExtraSpacing = 0;
        public int GrassExtraSpacing
        {
            get
            {
                return _grassExtraSpacing;
            }

            set
            {
                if (value >= 0 && value <= 48)
                {
                    _grassExtraSpacing = value;
                }
                else if (value < 0)
                {
                    _grassExtraSpacing = 0;
                }
                else if (value > 48)
                {
                    _grassExtraSpacing = 48;
                }
            }
        }

        private void GenerateGrassPatches()
        {
            if (SelectedGrassPatchesTile == null) { return; }

            var random = new Random();

            int debugLimit = 0;

            int extraOffset = extraOffset = GrassExtraSpacing / 2;


            for (int x = minX + xOffset + extraOffset; x <= maxX; x += grassPatchDimensions + GrassExtraSpacing)
            {
                for (int y = minY - yOffset + extraOffset; y >= maxY; y -= grassPatchDimensions + GrassExtraSpacing)
                {
                    var xRand = random.NextDouble() * GrassPlacementChaos;
                    var yRand = random.NextDouble() * GrassPlacementChaos;

                    int newX = (int)(xRand + x);
                    int newY = (int)(yRand + y);

                    newX = newX < minX ? newX = minX : newX > maxX ? maxX : newX;
                    newY = newY > minY ? newY = minY : newY < maxY ? maxY : newY;

                    layoutData += $"{SelectedGrassPatchesTile.Name} = {{ Hash={SelectedGrassPatchesTile.Hash}, X={newX}, Y={newY}, Rot={defaultRotation}, Flip=0, Var={SelectedGrassPatchesTile.Var} }}\n";

                    currentCount++;

                    if (debugLimit++ > 10)
                    {
                        //    return;
                    }


                }
            }
        }

    }
}

