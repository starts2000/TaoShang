using System;
using System.Collections.Generic;
using System.Linq;
using CCWin;
using Microsoft.Win32;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewBrowserSet : ViewBaseEx
    {
        readonly static IDictionary<int, string> IEVer = new Dictionary<int, string>
        {
            { -1, "" },
            { 0x2711, "强制IE10" },
            { 0x2710, "标准IE10" },
            { 0x270f, "强制IE9" },
            { 0x2328, "标准IE9" },
            { 0x22b8, "强制IE8" },
            { 0x1f40, "标准IE8" },
            { 0x1b58, "标准IE7" }
        };

        string subkey;
        string productName;

        public ViewBrowserSet()
        {
            InitializeComponent();
            productName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            sbtnSet.Click += sbtnSetClick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string s = "";

            if (IntPtr.Size == 4)
            {
                this.subkey = @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
            }
            else if (IntPtr.Size == 8)
            {
                this.subkey = @"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
            }

            if (RegistryHelper.IsRegistryExist(Registry.LocalMachine, this.subkey, this.productName))
            {
                s = RegistryHelper.GetRegistryData(Registry.LocalMachine, this.subkey, this.productName);
                
                string ieVer;
                IEVer.TryGetValue(int.Parse(s), out ieVer);
                lbIEVer.Text = ieVer;
            }
            else
            {
                lbIEVer.Text = "没有设置默认浏览器。";
            }

            scbIEVer.DisplayMember = "Value";
            scbIEVer.DataSource = IEVer.ToList();
        }

        void sbtnSetClick(object sender, EventArgs e)
        {
            if(scbIEVer.SelectedItem == null)
            {
                MessageBoxEx.Show(this, "请选择浏览器版本！", "浏览器设置");
                return;
            }

            var ieVer = (KeyValuePair<int, string>)scbIEVer.SelectedItem;

            if (RegistryHelper.IsRegistryExist(Registry.LocalMachine, this.subkey, this.productName))
            {
                try
                {
                    RegistryHelper.DeleteRegist(Registry.LocalMachine, this.subkey, this.productName);
                    RegistryHelper.SetRegistryData(Registry.LocalMachine, this.subkey, this.productName, ieVer.Key);
                }
                catch (Exception)
                {
                }
            }

            try
            {
                RegistryHelper.SetRegistryData(Registry.LocalMachine, this.subkey, this.productName, ieVer.Key);
                MessageBoxEx.Show(this, "设置成功！", "浏览器设置");
            }
            catch (Exception)
            {
            }
        
            webBrowser.Refresh();
        }
    }

    internal static class RegistryHelper
    {
        internal static void DeleteRegist(RegistryKey root, string subkey, string name)
        {
            RegistryKey key = root.OpenSubKey(subkey, true);
            foreach (string str in key.GetSubKeyNames())
            {
                if (str == name)
                {
                    key.DeleteSubKeyTree(name);
                }
            }
        }

        internal static string GetRegistryData(RegistryKey root, string subkey, string name)
        {
            string str = "";
            RegistryKey key = root.OpenSubKey(subkey, true);
            if (key != null)
            {
                str = key.GetValue(name).ToString();
            }
            return str;
        }

        internal static bool IsRegistryExist(RegistryKey root, string subkey, string name)
        {
            bool flag = false;
            RegistryKey key = root.OpenSubKey(subkey, true);
            if (key == null)
            {
                return false;
            }
            foreach (string str in key.GetValueNames())
            {
                if (str == name)
                {
                    flag = true;
                    return true;
                }
            }
            return flag;
        }

        internal static void SetRegistryData(RegistryKey root, string subkey, string name, int value)
        {
            root.CreateSubKey(subkey).SetValue(name, value);
        }
    }
}