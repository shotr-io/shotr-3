using ShotrUploaderPlugin;

namespace Shotr.Ui.Plugin.CorePlugins
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

        public override System.Windows.Forms.Form GetForm(ShotrCore m)
        {
            return new CorePluginForm();
        }

        public override bool Enabled
        {
            get { return false; }
        }
    }
}
