using System;
using System.Windows.Forms;

namespace Starts2000.TaoBao.Views
{
    interface INotifyIconMagager
    {
        void Show();
        void Close();
        void ShowBalloonTip(int timeout, string tipTitle, string tipText, ToolTipIcon tipIcon);

        string Text { set; }

        Action<OptType> Operate { get; set; }
    }

    enum OptType
    {
        None,
        LeftClik,
        RightClick,
        Exit,
        ShowMainForm
    }
}
