using System.Windows.Forms;
using ShotrUploaderPlugin;

namespace Shotr.Core.Plugin.CorePlugins
{
    class CorePluginTest : ShotrCorePlugin
    {
        public override string Name
        {
            get { return "Test Plugin"; }
        }

        public override void OnStarted(ShotrCore m)
        {
            
        }

        public override void OnClosing(ShotrCore m)
        {
            
        }

        public override Form GetForm(ShotrCore m)
        {
            return new CorePluginForm();
        }

        public override bool Enabled
        {
            get { return false; }
        }
    }
}
