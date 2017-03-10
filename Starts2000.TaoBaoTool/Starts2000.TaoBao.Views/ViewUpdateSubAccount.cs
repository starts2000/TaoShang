using System;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewUpdateSubAccount : ViewBaseEx
    {
        readonly IUserSubAccountBll _subAccountBll;
        readonly IAreaBll _areaBll;
        UserSubAccount _subAccount;

        public ViewUpdateSubAccount(IUserSubAccountBll subAccountBll,
            IAreaBll areaBll)
        {
            InitializeComponent();
            _subAccountBll = subAccountBll;
            _areaBll = areaBll;
            Init();
        }

        internal UserSubAccount SubAccount
        {
            set
            {
                _subAccount = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            scbProvince.DataSource = _areaBll.GetProvinceList();
            scbTaoBaoLevel.DataSource = ConstData.TaoBaoLevels;
            scbConsumptionLevel.DataSource = ConstData.ConsumptionLevels;
            BindSubAccount();
        }

        void Init()
        {
            scbProvince.SelectedIndexChanged += (sender, e) =>
            {
                if (scbProvince.SelectedIndex != -1)
                {
                    var value = scbProvince.SelectedItem as Province;
                    if (value.ProvinceID != -1)
                    {
                        scbCity.DisplayMember = "CityName";
                        scbCity.DataSource = _areaBll.GetCityList(value.ProvinceID);
                    }
                    else
                    {
                        scbCity.DataSource = null;
                        scbDistrict.DataSource = null;
                    }
                }
                else
                {
                    scbCity.DataSource = null;
                    scbDistrict.DataSource = null;
                }
            };

            scbCity.SelectedIndexChanged += (sender, e) =>
            {
                if (scbCity.SelectedIndex != -1)
                {
                    var value = scbCity.SelectedItem as City;
                    if (value.CityID != -1)
                    {
                        scbDistrict.DisplayMember = "DistrictName";
                        scbDistrict.DataSource = _areaBll.GetDistrictList(value.CityID);
                    }
                    else
                    {
                        scbDistrict.DataSource = null;
                    }
                }
                else
                {
                    scbDistrict.DataSource = null;
                }
            };

            RemoveErrorOnControlFocused(
                stbTaoBaoAccount, stbTaoBaoAccount.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(
                stbTaoBaoPassword, stbTaoBaoPassword.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(
                stbTaoBaoPayPassword, stbTaoBaoPayPassword.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(
                scbTaoBaoLevel, scbTaoBaoLevel, errorProvider);
            RemoveErrorOnControlFocused(
                scbConsumptionLevel, scbConsumptionLevel, errorProvider);
            RemoveErrorOnControlFocused(
                slDistrict, scbProvince, errorProvider);
            RemoveErrorOnControlFocused(
                slDistrict, scbCity, errorProvider);
            RemoveErrorOnControlFocused(
                slDistrict, scbDistrict, errorProvider);
            RemoveErrorOnControlFocused(
                stbAge, stbAge.SkinTxt, errorProvider);
            RemoveErrorOnControlFocused(scbSex, scbSex, errorProvider);
            RemoveErrorOnControlFocused(
                stbShippingAddress, stbShippingAddress.SkinTxt, errorProvider);

            sbtnUpdate.Click += (sender, e) =>
            {
                if(!CheckControlTextNullOrEmpty(stbTaoBaoAccount,
                    stbTaoBaoAccount.SkinTxt, errorProvider, "淘宝帐号不能为空！"))
                {
                    return;
                }
                if (!CheckControlTextNullOrEmpty(stbTaoBaoPassword,
                    stbTaoBaoPassword.SkinTxt, errorProvider, "登录密码不能为空！"))
                {
                    return;
                }

                if(!CheckControlTextNullOrEmpty(stbTaoBaoPayPassword,
                    stbTaoBaoPayPassword.SkinTxt, errorProvider, "支付密码不能为空！"))
                {
                    return;
                }

                if (!CheckControlTextNullOrEmpty(scbTaoBaoLevel,
                    scbTaoBaoLevel, errorProvider, "小号等级不能为空！"))
                {
                    return;
                }

                if (!CheckControlTextNullOrEmpty(scbConsumptionLevel,
                    scbConsumptionLevel, errorProvider, "小号信用等级不能为空！"))
                {
                    return;
                }

                if (!CheckControlTextNullOrEmpty(slDistrict,
                    scbProvince, errorProvider, "所在地区：省、市、区不能为空！"))
                {
                    return;
                }

                if (!CheckControlTextNullOrEmpty(slDistrict,
                   scbCity, errorProvider, "所在地区：省、市、区不能为空！"))
                {
                    return;
                }

                if (!CheckControlTextNullOrEmpty(slDistrict,
                   scbDistrict, errorProvider, "所在地区：省、市、区不能为空！"))
                {
                    return;
                }

                if (!CheckControlTextNullOrEmpty(stbAge,
                   stbAge.SkinTxt, errorProvider, "年龄不能为空！"))
                {
                    return;
                }

                byte age;
                if (!byte.TryParse(stbAge.SkinTxt.Text, out age))
                {
                    errorProvider.SetError(stbAge, "请输入正确的年龄!");
                    return;
                }

                if (!CheckControlTextNullOrEmpty(scbSex,
                   scbSex, errorProvider, "性别不能为空！"))
                {
                    return;
                }

                if(!CheckControlTextNullOrEmpty(stbShippingAddress,
                    stbShippingAddress.SkinTxt, errorProvider, "收货地址不能为空！"))
                {
                    return;
                }

                var subAccount = new UserSubAccount
                {
                    Id = _subAccount.Id,
                    TaoBaoAccount = stbTaoBaoAccount.SkinTxt.Text.Trim(),
                    Password = stbTaoBaoPassword.SkinTxt.Text.Trim(),
                    PayPassword = stbTaoBaoPayPassword.SkinTxt.Text.Trim(),
                    HomePage = stbHomePage.SkinTxt.Text.Trim(),
                    Level = (scbTaoBaoLevel.SelectedItem as TaoBaoLevel).Id,
                    ConsumptionLevel = (scbConsumptionLevel.SelectedItem as ConsumptionLevel).Id,
                    Province = scbProvince.Text,
                    City = scbCity.Text,
                    District = scbDistrict.Text,
                    Age = age,
                    Sex = scbSex.SelectedIndex == 0,
                    ShippingAddress = stbShippingAddress.SkinTxt.Text.Trim(),
                    IsRealName = scbRealName.Checked,
                    IsBindingMobile = scbBindingMobile.Checked,
                    IsEnabled = scbEnabled.Checked
                };

                int temp;
                if(int.TryParse(stbUpperLimitAmount.SkinTxt.Text, out temp))
                {
                    subAccount.UpperLimitAmount = temp;
                }

                if (int.TryParse(stbUpperLimitNumber.SkinTxt.Text, out temp))
                {
                    subAccount.UpperLimitNumber = temp;
                }

                if (int.TryParse(stbCommission.SkinTxt.Text, out temp))
                {
                    subAccount.Commission = temp;
                }

                _subAccountBll.Update(subAccount, state =>
                {
                    string info = string.Empty;

                    switch (state)
                    {
                        case UserSubAccountOptState.Failed:
                            info = "服务器异常，修改小号信息失败！";
                            break;
                        case UserSubAccountOptState.CannotConnectServer:
                            info = "连接服务器失败！";
                            break;
                        case UserSubAccountOptState.InvalidOpt:
                            info = "非法操作！与服务器连接断开，请稍后重试！";
                            break;
                        case UserSubAccountOptState.Successed:
                            info = "修改小号信息成功！\r\n\r\n小号信息修改后，请联系客服或管理员重新审核！";
                            break;
                    }

                    Invoke(() =>
                    {
                        MessageBoxEx.Show(this, info, "修改小号信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (state == UserSubAccountOptState.Successed)
                        {
                            Close();
                            var owner = this.Owner as ViewSubAccountManage;
                            if (owner != null)
                            {
                                owner.BindUserSubAccountList();
                            }
                        }
                    });
                });
            };
        }

        void BindSubAccount()
        {
            stbTaoBaoAccount.SkinTxt.Text = _subAccount.TaoBaoAccount;
            stbTaoBaoPassword.SkinTxt.Text = TripleDES.Decrypt3DES(_subAccount.Password);
            stbTaoBaoPayPassword.SkinTxt.Text = TripleDES.Decrypt3DES(_subAccount.PayPassword);
            stbHomePage.SkinTxt.Text = _subAccount.HomePage;
            scbTaoBaoLevel.SelectedIndex = (_subAccount.Level ?? 1) - 1;
            scbConsumptionLevel.SelectedIndex = (_subAccount.ConsumptionLevel ?? 1) - 1;
            scbProvince.Text = _subAccount.Province;
            scbCity.Text = _subAccount.City;
            scbDistrict.Text = _subAccount.District;
            stbAge.SkinTxt.Text = _subAccount.Age.HasValue ? _subAccount.Age.Value.ToString() : string.Empty;

            if(_subAccount.Sex.HasValue)
            {
                scbSex.SelectedIndex = _subAccount.Sex.Value ? 0 : 1;
            }

            if (_subAccount.UpperLimitAmount.HasValue)
            {
                stbUpperLimitAmount.SkinTxt.Text = _subAccount.UpperLimitAmount.Value.ToString();
            }

            if(_subAccount.UpperLimitNumber.HasValue)
            {
                stbUpperLimitNumber.SkinTxt.Text = _subAccount.UpperLimitNumber.Value.ToString();
            }

            if(_subAccount.Commission.HasValue)
            {
                stbCommission.SkinTxt.Text = _subAccount.Commission.Value.ToString();
            }

            stbShippingAddress.SkinTxt.Text = _subAccount.ShippingAddress;
            scbRealName.Checked = _subAccount.IsRealName;
            scbBindingMobile.Checked = _subAccount.IsBindingMobile;
            scbEnabled.Checked = _subAccount.IsEnabled;
        }
    }
}
