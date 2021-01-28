using System;
using System.Windows.Forms;

namespace Shotr.Ui.Installer
{
    public partial class CancelForm : Form
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
