using System;
using System.Windows.Forms;

namespace Shotr.Ui.Plugin.CorePlugins
{
    public partial class CorePluginForm : MetroFramework5.Forms.MetroForm
    {
        public CorePluginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
