using MetroFramework5.Controls;

namespace MetroFramework5.Design
{
    internal class MetroPanelDesigner : System.Windows.Forms.Design.ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (Control is MetroPanel)
            {
                //this.EnableDesignMode(((MetroPanel)this.Control).ScrollablePanel, "ScrollablePanel");
            }
        }
    }
}
