using BlazorStyled;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using POEHideoutGround.Data;

namespace POEHideoutGround.Pages.Painter.PaintTile
{
    public class PaintTileBase : ComponentBase
    {

        [Inject]
        private IStyled Styled { get; set; }


        [Parameter]
        public int YPosition { get; set; } = 0;

        [Parameter]
        public int XPosition { get; set; } = 0;

        [Parameter]
        public bool IsPainting { get; set; } = false;


        public string Label { get; set; } = "";


        protected string TileColour { get; set; } = "purple";


        public string TileImage { get; set; } = "arctic_2_l";

        protected string painttile_Container;
        protected string painttile_Position;
        protected string painttile_Highlight;
        protected string painttile_Image;

        [Parameter]
        public TileData SelectedBrush { get; set; }

        protected TileData PaintData { get; set; }



        protected override void OnInitialized()
        {
            base.OnInitialized();


            //painttile_Container;

            Label = $"{XPosition}:{YPosition}";


            painttile_Position = Styled.Css($@"
                top:{XPosition * 23}px;
                left:{YPosition * 23}px;
            ");


        }

        protected void OnClick(MouseEventArgs e)
        {
            TileImage = SelectedBrush.Image;

            PaintData = SelectedBrush;

            painttile_Image = Styled.Css($@"
                background-image: url('images/tile/{TileImage}.png');
            ");

        }


        protected void OnMouseOver(MouseEventArgs e)
        {


            TileColour = "red";

            painttile_Highlight= Styled.Css($@"
                border: 2px solid {TileColour};
            ");

            if(IsPainting)
            {
                OnClick(e);
            }


            //e.target.style.color = "orange";

        }


        protected void OnMouseOut(MouseEventArgs e)
        {
            TileColour = "green";

            painttile_Highlight = Styled.Css($@"
                border: 2px solid {TileColour};
            ");


        }
    }
}

