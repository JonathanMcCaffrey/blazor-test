using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using POEHideoutGround.Components;
using POEHideoutGround.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace POEHideoutGround.Pages.Calculator
{
    /// <summary>
    /// Test summary
    /// </summary>
    public class CalculatorBase : ComponentBase
    {

        [Inject]
        protected HttpClient Http { get; set; }


        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected IMatToaster Toaster { get; set; }

        protected TileCalculator GroundComponent;

        protected override async Task OnInitializedAsync()
        {
            //TODO: This loading seems too slow. Look into why, and speed this up
            groundData = await Http.GetJsonAsync<List<TileData>>("data/ground.json");
            waterData = await Http.GetJsonAsync< List<TileData>>("data/water.json");
            grassPatchesData = await Http.GetJsonAsync<List<TileData>>("data/grassPatches.json");
            oriathData = await Http.GetJsonAsync<List<TileData>>("data/oriath.json");

            List<TileData> medOriathTiles = oriathData.FindAll(e => e.Size == 46);
            oriathData = medOriathTiles;

            GroundComponent.Refresh();
        }


        public async Task CopyTextToClipboard()
        {

            await JSRuntime.InvokeVoidAsync("clipboardCopy.copyText", LayoutData);

            Toaster.Add("Copied to clipboard", MatToastType.Info, "Action");
        }

        public static TileData DefaultGroundTile = new TileData(name: "Dirt Ground", var: "2", hash: "1798490749", image: "dirt_3_l", size: 69);
        public static TileData DefaultWaterTile = new TileData(name: "Water Plane", var: "22", hash: "1179014731", image: "water_23_l", size: 69);
        public static TileData DefaultGrassPatchesTile = new TileData(name: "Grass Patch", var: "4", hash: "3856837925", image: "grasspatch_5_l", size: 69);
        public static TileData DefaultOriathTile = new TileData(name: "Oriath Ground", var: "5", hash: "3123067737", image: "oriath_6_m", size: 46);
        public static TileData DefaultOriathSubTile = new TileData(name: "Oriath Ground", var: "1", hash: "3123067737", image: "oriath_2_m", size: 46);



        public bool groundDisabled { get; set; } = false;
        public bool waterDisabled { get; set; } = true;
        public bool grassPatchesDisabled { get; set; } = true;

        #region varibles
        int minX = 153;
        int minY = 559;
        int maxX = 560;
        int maxY = 153;

        int xOffset = 6;
        int yOffset = 6;

        int largeTileDimensions = 69;
        int grassPatchDimensions = 30;
        int medTileDimensions = 46;
        // int smallTileDimensions = 23;



        public int CurrentCount { get; set; }

        public bool HasNoTiles { get; set; } = true;


        public string LayoutData { get; set; }


        string defaultRotation = "0";
        // Rotation Data
        //Rot=49152
        //Rot=32768
        //Rot=16385
        //Rot=1

        // Set in Calculator.razor, as I can't seem to easily set this otherwise...
        public List<TileData> groundData;
        public List<TileData> waterData;
        public List<TileData> oriathData;
        public List<TileData> grassPatchesData;

        public TileData SelectedGroundTile { get; set; }
        public TileData SelectedWaterTile { get; set; }
        public TileData SelectedGrassPatchesTile { get; set; }
        public TileData SelectedOriathTile { get; set; }

        public TileData SelectedOriathSubTile { get; set; }



        #endregion

        public void GenerateAndCopy()
        {
            Generate();
            CopyTextToClipboard();
        }

        public void Generate()
        {
            ClearLayoutData();
            GenerateGround();
            GenerateWater();
            GenerateGrassPatches();
            GenerateOriath();

            ErrorCatching();

            HasNoTiles = CurrentCount == 0;
        }


        public void Clear()
        {
            ClearLayoutData();

            HasNoTiles = true;
        }


        public void ClearLayoutData()
        {
            CurrentCount = 0;
            LayoutData = "";
        }

        public void ErrorCatching()
        {
            if (LayoutData == "")
            {
                LayoutData = "No layout could be generated. Please ensure you have selected a tile, and you have it's generation enabled.";
            }
        }

        public void GenerateGround()
        {
            if (SelectedGroundTile == null) { return; }

            for (int x = minX + xOffset; x <= maxX; x += largeTileDimensions)
            {
                for (int y = minY - yOffset; y >= maxY; y -= largeTileDimensions)
                {
                    LayoutData += $"{SelectedGroundTile.Name} = {{ Hash={SelectedGroundTile.Hash}, X={x}, Y={y}, Rot={defaultRotation}, Flip=0, Var={SelectedGroundTile.Var} }}\n";


                    CurrentCount++;
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
                    LayoutData += $"{SelectedWaterTile.Name} = {{ Hash={SelectedWaterTile.Hash}, X={x}, Y={y}, Rot={defaultRotation}, Flip=0, Var={SelectedWaterTile.Var} }}\n";

                    CurrentCount++;
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

            int extraOffset = GrassExtraSpacing / 2;


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

                    LayoutData += $"{SelectedGrassPatchesTile.Name} = {{ Hash={SelectedGrassPatchesTile.Hash}, X={newX}, Y={newY}, Rot={defaultRotation}, Flip=0, Var={SelectedGrassPatchesTile.Var} }}\n";

                    CurrentCount++;

                }
            }
        }


        protected int SelectedPattern { get; set; }
        private void GenerateOriath()
        {
            // Enum for Patterns

            if (SelectedOriathTile == null) { return; }


            var xSteps = 0;
            var ySteps = 0;
            for (int x = minX + xOffset; x <= maxX; x += medTileDimensions)
            {
                xSteps++;

                for (int y = minY - yOffset; y >= maxY; y -= medTileDimensions)
                {
                    ySteps++;

                    int newX = (int)(x);
                    int newY = (int)(y);

                    newX = newX < minX ? newX = minX : newX > maxX ? maxX : newX;
                    newY = newY > minY ? newY = minY : newY < maxY ? maxY : newY;


                    if (ySteps % 2 == 0 && SelectedOriathSubTile != null && SelectedPattern == 0)
                    {
                        LayoutData += $"{SelectedOriathSubTile.Name} = {{ Hash={SelectedOriathSubTile.Hash}, X={newX}, Y={newY}, Rot={defaultRotation}, Flip=0, Var={SelectedOriathSubTile.Var} }}\n";
                    }
                    else if (xSteps % 2 == 0 && SelectedOriathSubTile != null && SelectedPattern == 1)
                    {
                        LayoutData += $"{SelectedOriathSubTile.Name} = {{ Hash={SelectedOriathSubTile.Hash}, X={newX}, Y={newY}, Rot={defaultRotation}, Flip=0, Var={SelectedOriathSubTile.Var} }}\n";
                    }
                    else if ((ySteps % 2 == 0 || xSteps % 2 == 0) && SelectedOriathSubTile != null && SelectedPattern == 2)
                    {
                        LayoutData += $"{SelectedOriathSubTile.Name} = {{ Hash={SelectedOriathSubTile.Hash}, X={newX}, Y={newY}, Rot={defaultRotation}, Flip=0, Var={SelectedOriathSubTile.Var} }}\n";
                    }
                    else
                    {
                        LayoutData += $"{SelectedOriathTile.Name} = {{ Hash={SelectedOriathTile.Hash}, X={newX}, Y={newY}, Rot={defaultRotation}, Flip=0, Var={SelectedOriathTile.Var} }}\n";
                    }


                    CurrentCount++;

                }
            }
        }

    }
}

