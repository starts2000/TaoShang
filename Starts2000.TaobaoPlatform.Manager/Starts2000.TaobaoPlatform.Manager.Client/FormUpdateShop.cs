using System;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager.Client
{
    public partial class FormUpdateShop : Form
    {
        readonly ManagerDal _manager;
        readonly Shop _shop;

        public FormUpdateShop(ManagerDal manager, Shop shop)
        {
            InitializeComponent();

            _manager = manager;
            _shop = shop;
            Init();
        }

        void Init()
        {
            tbTaobaoAccount.Text = _shop.WangWangAccount;
            tbShopName.Text = _shop.ShopName;
            tbShopUrl.Text = _shop.ShopUrl;
            cbShopLevel.Text = _shop.ShopLevel;

            btnUpdate.Click += btnUpdate_Click;
        }

        async void btnUpdate_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbShopName.Text.Trim()))
            {
                MessageBox.Show("店铺名不能为空！", "修改店铺信息", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbShopName.Focus();
                return;
            }


            if (string.IsNullOrEmpty(tbShopUrl.Text.Trim()))
            {
                MessageBox.Show("店铺网址不能为空！", "修改店铺信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbShopUrl.Focus();
                return;
            }


            if (string.IsNullOrEmpty(cbShopLevel.Text))
            {
                MessageBox.Show("店铺等级不能为空！", "修改店铺信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbShopLevel.Focus();
                return;
            }

            try
            {
                var ret = await _manager.UpdateShop(new Shop
                    {
                        Id = _shop.Id,
                        ShopName = tbShopName.Text.Trim(),
                        ShopUrl = tbShopUrl.Text.Trim(),
                        ShopLevel = cbShopLevel.Text
                    });

                var msg = ret ? "修改店铺信息成功！" : "修改店铺信息失败！";
                MessageBox.Show(msg, "修改店铺信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(ret)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("修改店铺信息失败！ 错误信息：" + ex.Message, "修改店铺信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
