using System;
using System.IO;
using System.Windows.Forms;

namespace DATest
{
    public partial class LicenseAndOPCURL : Form
    {
        public static string licenseString = string.Empty;
        public static string opcUrlString = string.Empty;

        public LicenseAndOPCURL()
        {
            InitializeComponent();
            LicenseString.Text = licenseString;
            OPCUrlString.Text = opcUrlString;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            licenseString = LicenseString.Text.Trim();
            opcUrlString = OPCUrlString.Text.Trim();
            File.WriteAllText("./Config/LicenseAndURL.config", licenseString + "@" + opcUrlString);
            MessageBox.Show("已写入：" + licenseString + "@" + opcUrlString, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
