using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpload
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            checkBox1.Checked = Properties.Settings.Default.IsCheckBoxChecked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsCheckBoxChecked = checkBox1.Checked;
            Properties.Settings.Default.Save();

            if (checkBox1.Checked)
            {
                AddToStartup(true);
            }
            else
            {
                AddToStartup(false);
            }
        }

        private void AddToStartup(bool enable)
        {
            string appName = "MyAppName";
            string exePath = Application.ExecutablePath;

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
            {
                registryKey.SetValue(appName, exePath);
            }
            else
            {
                registryKey.DeleteValue(appName, false);
            }
        }
    }
}
