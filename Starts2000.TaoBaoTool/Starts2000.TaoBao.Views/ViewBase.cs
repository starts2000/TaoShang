using System;
using System.Drawing;
using System.Windows.Forms;
using CCWin;
using Ninject;
using Ninject.Extensions.Logging;
using Starts2000.TaoBao.Views.ViewResource;

namespace Starts2000.TaoBao.Views
{
    internal class ViewBase : CCSkinMain
    {
        [Inject]
        public ILoggerFactory LoggerFactory {protected get; set; }

        internal ViewBase()
        {
            this.CloseBoxSize = new Size(39, 20);
            this.ControlBoxOffset = new Point(0, -1);
            this.EffectWidth = 2;
            this.BackColor = Color.FromArgb(97, 159, 215);
            this.ForeColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackLayout = false;
            this.BorderPalace = ViewResources.all_inside_bkg;

            this.CloseDownBack = ViewResources.btn_close_down;
            this.CloseMouseBack = ViewResources.btn_close_highlight;
            this.CloseNormlBack = ViewResources.btn_close_disable;

            this.MaxDownBack = ViewResources.btn_max_down;
            this.MaxMouseBack = ViewResources.btn_max_highlight;
            this.MaxNormlBack = ViewResources.btn_max_normal;

            this.MiniDownBack = ViewResources.btn_mini_down;
            this.MiniMouseBack = ViewResources.btn_mini_highlight;
            this.MiniNormlBack = ViewResources.btn_mini_normal;

            this.RestoreDownBack = ViewResources.btn_restore_down;
            this.RestoreMouseBack = ViewResources.btn_restore_highlight;
            this.RestoreNormlBack = ViewResources.btn_restore_normal;

            this.Icon = ViewResources.favicon;
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
        }

        protected void SetToMax()
        {
            Rectangle rect = Screen.GetBounds(this);
            //Location = new Point(rect.X, rect.Y);
            //Size = new Size(rect.Width - 6, rect.Height - 6);
            SetBounds(rect.X, rect.Y, rect.Width, rect.Height);
        }

        protected void Invoke(Action action)
        {
            if(InvokeRequired)
            {
                BeginInvoke(action);
                return;
            }

            action();
        }

        protected bool CheckControlTextNullOrEmpty(Control provider,
            Control control, ErrorProvider errorProvider, string info)
        {
            if(string.IsNullOrEmpty(control.Text.Trim()))
            {
                errorProvider.SetError(provider, info);
                return false;
            }

            return true;
        }

        protected void RemoveErrorOnControlFocused(Control provider,
            Control control, ErrorProvider errorProvider)
        {
            control.GotFocus += (sender, e) =>
            {
                errorProvider.SetError(provider, string.Empty);
            };
        }

        protected void Error(string message, Exception e)
        {
            LoggerFactory.GetCurrentClassLogger().ErrorException(message, e);
        }
    }
}