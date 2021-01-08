using System;
using System.Windows.Forms;
using MetroFramework5.Forms;

namespace Shotr.Core.Plugin.CorePlugins
{
    public partial class CorePluginForm : MetroForm
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
