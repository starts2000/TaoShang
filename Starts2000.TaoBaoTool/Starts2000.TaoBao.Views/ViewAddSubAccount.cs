using System;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using Starts2000.TaoBao.Views.Utils;
using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewAddSubAccount : ViewBaseEx
    {
        readonly IUserSubAccountBll _subAccountBll;
        readonly IAreaBll _areaBll;

        public ViewAddSubAccount(IUserSubAccountBll subAccountBll, IAreaBll areaBll)
        {
            InitializeComponent();
            _subAccountBll = subAccountBll;
            _areaBll = areaBll;
            Init();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            scbProvince.DataSource = _areaBll.GetProvinceList();
            scbTaoBaoLevel.DataSource = ConstData.TaoBaoLevels;
            scbConsumptionLevel.DataSource = ConstData.ConsumptionLevels;
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

            sbtnAdd.Click += (sender, e) =>
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

                _subAccountBll.Add(subAccount, state =>
                {
                    string info = string.Empty;

                    switch (state)
                    {
                        case UserSubAccountOptState.Failed:
                            info = "服务器异常，添加小号失败！";
                            break;
                        case UserSubAccountOptState.CannotConnectServer:
                            info = "连接服务器失败！";
                            break;
                        case UserSubAccountOptState.InvalidOpt:
                            info = "非法操作！与服务器连接断开，请稍后重试！";
                            break;
                        case UserSubAccountOptState.Successed:
                            info = "添加小号成功！";
                            break;
                    }

                    Invoke(() =>
                    {
                        MessageBoxEx.Show(this, info, "添加小号", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (state == UserSubAccountOptState.Successed)
                        {
                            Clear();
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

        void Clear()
        {
            foreach(Control control in Controls)
            {
                Type type = control.GetType();
                if(type == typeof(SkinTextBox))
                {
                    var textBox = control as SkinTextBox;
                    textBox.SkinTxt.Text = string.Empty;
                }
                else if(type == typeof(SkinComboBox))
                {
                    var comboBox = control as SkinComboBox;
                    comboBox.SelectedIndex = -1;
                }
                else if(type == typeof(SkinCheckBox))
                {
                    if (control.Name != "scbEnabled")
                    {
                        var checkBox = control as SkinCheckBox;
                        checkBox.Checked = false;
                    }
                }
            }
        }
    }
}
