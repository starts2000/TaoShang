using System.Drawing;
using CCWin.SkinControl;
using Starts2000.TaoBao.Views.ViewResource;

namespace Starts2000.TaoBao.Views
{
    public class SkinButtonEx : SkinButton
    {
        public SkinButtonEx()
        {
            this.DrawType = DrawStyle.Img;
            this.Palace = true;
            this.BackColor = Color.Transparent;
            this.NormlBack = ViewResources.btn_normal_1;
            this.MouseBack = ViewResources.btn_hover_1;
            this.DownBack = ViewResources.btn_pressed_1;
        }

        protected override Size DefaultSize
        {
            get { return new Size(75, 25); }
        }
    }
}
