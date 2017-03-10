using System;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewReadyConnectClient : ViewBaseEx
    {
        public ViewReadyConnectClient()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            sbtnConnect.Click += (sender, e) =>
            {
                var mainView = this.Owner as ViewOptMain;
                if (Model != null)
                {
                    mainView.OnRemoteOperationRequest(Model);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
        }

        internal UserSubAccountPageListVM Model
        {
            get;
            set;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Model != null)
            {
                lbAccount.Text = Model.UserAccount;
                lbIpAddress.Text = Model.IpAddress;
                lbArea.Text = string.Format("{0} - {1} - {2}",
                    Model.Province, Model.City, Model.District);
                lbTabaoAccount.Text = Model.TaoBaoAccount;
            }
        }
    }
}