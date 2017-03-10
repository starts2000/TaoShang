using System.Drawing;
using Starts2000.TaoBao.Views.ViewResource;

namespace Starts2000.TaoBao.Views
{
    internal class ViewBaseEx : ViewBase
    {
        internal ViewBaseEx()
        {
            this.Back = ViewResources.BackImage;
            this.BorderRectangle = new Rectangle(10, 38, 10, 38);
        }
    }
}
