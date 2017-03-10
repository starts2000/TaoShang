using System;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager.Client
{
    public partial class FormMain : Form
    {
        readonly ManagerDal _manager = new ManagerDal();

        public FormMain()
        {
            InitializeComponent();
            Init();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadUserList(string.Empty);
        }

        void Init()
        {
            btnSearch.Click += (sender, e) =>
            {
                LoadUserList(tbAccount.Text.Trim());
            };

            paginationUserList.Reload += (sender, e) =>
            {
                LoadUserList(tbAccount.Text.Trim());
            };

            tsmiAudit.Click += (sender, e) =>
            {
                if(dgvUserList.SelectedRows == null || dgvUserList.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "请先选择需要审核的帐户！", 
                        "帐号审核", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var user = dgvUserList.SelectedRows[0].DataBoundItem as User;
                var form = new FormUserAudit(_manager, user);
                form.ShowDialog(this);
            };

            tsmiAddGold.Click += (sender, e) =>
            {
                if (dgvUserList.SelectedRows == null || dgvUserList.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "请先选择需要添加金币的帐户！",
                        "添加金币", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var user = dgvUserList.SelectedRows[0].DataBoundItem as User;
                var form = new FormGoldAdd(_manager, user);
                form.ShowDialog(this);
            };

            tsmiAddHangupTime.Click += (sender, e) =>
            {
                if (dgvUserList.SelectedRows == null || dgvUserList.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "请先选择需要添加挂机时间的帐户！",
                        "添加挂机时间", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var user = dgvUserList.SelectedRows[0].DataBoundItem as User;
                var form = new FormHangupTimeAdd(_manager, user);
                form.ShowDialog(this);
            };

            tsmiShopManager.Click += (sender, e) =>
            {
                if (dgvUserList.SelectedRows == null || dgvUserList.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "请先选择需要进行店铺管理的帐户！",
                        "店铺管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var user = dgvUserList.SelectedRows[0].DataBoundItem as User;
                var form = new FormShopManager(_manager, user);
                form.ShowDialog(this);
            };

            tsmiRestPassword.Click += (sender, e) =>
            {
                if (dgvUserList.SelectedRows == null || dgvUserList.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "请先选择需要进行重置密码的帐户！",
                        "重置账户密码", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var user = dgvUserList.SelectedRows[0].DataBoundItem as User;
                var form = new FormResetPasswod(_manager, user);
                form.ShowDialog(this);
            };

            tsmiSubAccountManager.Click += (sender, e) =>
            {
                if (dgvUserList.SelectedRows == null || dgvUserList.SelectedRows.Count == 0)
                {
                    MessageBox.Show(this, "请先选择需要进行小号管理的帐户！",
                        "小号管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var user = dgvUserList.SelectedRows[0].DataBoundItem as User;
                var form = new FormSubAccountManager(_manager, user);
                form.ShowDialog(this);
            };
        }

        async void LoadUserList(string account)
        {
            try
            {
             var data = await _manager.GetUsers(account, paginationUserList.PageIndex, paginationUserList.PageSize);
                if(data != null)
                {
                    paginationUserList.Count = data.Item1;
                    dgvUserList.DataSource = data.Item2;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "获取用户列表信息失败！错误：" + ex.Message, 
                    "获取用户列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}