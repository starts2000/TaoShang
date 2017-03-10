using System;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager.Client
{
    public partial class FormShopManager : Form
    {
        readonly ManagerDal _manager;
        readonly User _user;

        public FormShopManager(ManagerDal manager, User user)
        {
            InitializeComponent();
            _manager = manager;
            _user = user;
            tsmiAudit.Click += tsmiAudit_Click;
            tsmiCancelAudit.Click += tsmiCancelAudit_Click;
            tsmiUpdate.Click += tsmiUpdate_Click;
            tsmiDelete.Click += tsmiDelete_Click;
            base.Text = string.Format("{0} - 会员：{1}", base.Text, _user.Account);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadShopList();
        }

        async void LoadShopList()
        {
            try
            {
                var shops = await _manager.GetShops(_user.Id);
                dgvShopList.DataSource = shops;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "获取用户店铺信息失败！错误：" + ex.Message,
                    "用户店铺管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void tsmiCancelAudit_Click(object sender, EventArgs e)
        {
            Audit(false);
        }

        void tsmiAudit_Click(object sender, EventArgs e)
        {
            Audit(true);
        }

        async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvShopList.SelectedRows == null || dgvShopList.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "请先选择需要删除的店铺信息！",
                    "用户店铺管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("请确认是否删除店铺信息？", "用户店铺管理", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                var shop = dgvShopList.SelectedRows[0].DataBoundItem as Shop;
                try
                {
                    var ret = await _manager.DeleteShop(shop.Id);
                    string msg = ret ? "删除店铺信息成功！" : "删除店铺信息失败！";
                    MessageBox.Show(this, msg, "用户店铺管理", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (ret)
                    {
                        LoadShopList();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, "删除店铺信息失败，错误信息：" + ex.Message,
                        "用户店铺管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (dgvShopList.SelectedRows == null || dgvShopList.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "请先选择需要修改的店铺信息！",
                    "用户店铺管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var shop = dgvShopList.SelectedRows[0].DataBoundItem as Shop;
            var form = new FormUpdateShop(_manager, shop);
            if(form.ShowDialog(this) == DialogResult.OK)
            {
                LoadShopList();
            }
        }

        async void Audit(bool audit)
        {
            if (dgvShopList.SelectedRows == null || dgvShopList.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "请先选择需要进行店铺管理的帐户！",
                    "用户店铺管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var shop = dgvShopList.SelectedRows[0].DataBoundItem as Shop;
            try
            {
                var ret = await _manager.ShopAudit(shop.Id, audit);
                string info = ret ? "用户店铺审核成功！" : "用户店铺审核失败！";

                MessageBox.Show(this, string.Format(
                    "{0}{1}", !audit ? "取消" : string.Empty, info), "用户店铺审核",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ret)
                {
                    LoadShopList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, string.Format(
                    "{0}用户店铺审核失败，错误：{1}", !audit ? "取消" : string.Empty, ex.Message),
                    "用户店铺审核", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}