using System;
using System.Drawing;
using System.Windows.Forms;
using CCWin.SkinClass;
using CCWin.SkinControl;
using Starts2000.TaoBao.Views.ViewResource;

namespace Starts2000.TaoBao.Views
{
    class NotifyIconManager : INotifyIconMagager
    {
        readonly NotifyIcon _notifyIcon;
        readonly SkinContextMenuStrip _menu;

        public NotifyIconManager()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = ViewResources.favicon;

            _menu = new SkinContextMenuStrip();
            _menu.BackColor = Color.White;
            _menu.BackRadius = 6;
            _menu.RadiusStyle = RoundStyle.All;
            _menu.DropDownImageSeparator = Color.Gray;
            _menu.ItemSplitter = Color.Gray;
            _menu.ItemAnamorphosis = false;
            _menu.ItemBorderShow = false;
            _menu.ItemRadiusStyle = RoundStyle.None;
            _menu.TitleAnamorphosis = false;
            _menu.TitleRadiusStyle = RoundStyle.None;
            _menu.TitleColor = Color.FromArgb(230, 230, 230);
            _menu.Items.Add("打开窗口", null, (sender, e) =>
            {
                Operate(OptType.ShowMainForm);
            });

            _menu.Items.Add("退出", null, (sender, e) =>
            {
                Operate(OptType.Exit);
            });

            _notifyIcon.ContextMenuStrip = _menu;
            _notifyIcon.MouseClick += (sender, e) =>
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        Operate(OptType.LeftClik);
                        break;
                    case MouseButtons.Right:
                        break;
                }
            };
        }

        void OnOperate(OptType type)
        {
            if(Operate != null)
            {
                Operate(type);
            }
        }

        #region INotifyIconMagager 成员

        public void Show()
        {
            if (_notifyIcon != null)
            {
                _notifyIcon.Visible = true;
            }
        }

        public void ShowBalloonTip(int timeout, string tipTitle, string tipText, ToolTipIcon tipIcon)
        {
            if (_notifyIcon != null && _notifyIcon.Visible)
            {
                _notifyIcon.ShowBalloonTip(timeout, tipTitle, tipText, tipIcon);
            }
        }

        public void Close()
        {
            if(_notifyIcon != null)
            {
                _notifyIcon.Visible = false;
            }
        }

        public string Text
        {
            set
            {
                if(_notifyIcon != null)
                {
                    _notifyIcon.Text = value;
                }
            }
        }

        public Action<OptType> Operate
        {
            get;
            set;
        }

        #endregion
    }
}
