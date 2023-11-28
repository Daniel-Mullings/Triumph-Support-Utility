using TriumphSupportUtility.Tools;

namespace TriumphSupportUtility_Client
{
    public partial class WinForm_PrinterInstall : Form
    {
        private static Tool_PrinterInstall printerInstall_sukvmprn01 = new Tool_PrinterInstall("s-ukvm-prn01");
        private static Tool_PrinterInstall printerInstall_sukvmlrsl01 = new Tool_PrinterInstall("s-ukvm-lrsl01");
        private List<Tool_PrinterInstall> printerInstallObjs = new List<Tool_PrinterInstall>() { printerInstall_sukvmprn01, printerInstall_sukvmlrsl01 };

        private bool Install()
        {
            foreach (var printerInstallObj in printerInstallObjs)
            {
                if (printerInstallObj.printerCollection.Contains(ComboBox_PrinterList.SelectedItem.ToString()))
                    return printerInstallObj.Install(ComboBox_PrinterList.SelectedItem.ToString());
            }
            return false;
        }
        private void Init()
        {
            DialogResult = DialogResult.OK;
            printerInstall_sukvmprn01.Init();
            printerInstall_sukvmlrsl01.Init();
            InitPrinterList();
        }
        private void InitPrinterList()
        {
            foreach (var printerInstallObj in printerInstallObjs)
            {
                foreach (var sharePrinter in printerInstallObj.printerCollection)
                    ComboBox_PrinterList.Items.Add(sharePrinter);
            }
        }

        public WinForm_PrinterInstall()
        {
            InitializeComponent();
            Init();
        }

        private void Button_Install_Click(object sender, EventArgs e)
        {
            Button_Install.Enabled = false;
            if (Install())
            {
                MessageBox.Show("Printer Install Successful", "Notice: Printer Install Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Printer Install Unsuccessful", "Error: Printer Install Unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
            }
        }
        private void ComboBox_PrinterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button_Install.Enabled = true;
        }
        private void ComboBox_PrinterList_KeyPress(object sender, KeyPressEventArgs e)
        { 
            e.Handled = true;
        }
    }
}