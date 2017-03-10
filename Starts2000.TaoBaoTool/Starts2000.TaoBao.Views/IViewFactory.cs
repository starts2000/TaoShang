using System.Windows.Forms;

namespace Starts2000.TaoBao.Views
{
    internal interface IViewFactory
    {
        T GetView<T>() where T : ViewBase;
    }
}
