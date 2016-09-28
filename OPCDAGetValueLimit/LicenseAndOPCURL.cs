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
            licenseString = LicenseString.Text;
            opcUrlString = OPCUrlString.Text;
            File.WriteAllText("./Config/LicenseAndURL.config", licenseString + "@" + opcUrlString);
        }
    }
}
