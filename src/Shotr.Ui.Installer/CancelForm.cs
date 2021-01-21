using System;
using MetroFramework5.Forms;

namespace Shotr.Ui.Installer
{
    public partial class CancelForm : MetroForm
    {
        public CancelForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
