using System;
using System.Windows.Forms;

namespace ShotrUploaderPlugin
{
    [Serializable]
    public abstract class ShotrCorePlugin
    {
        /// <summary>
        /// The name of your plugin.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Runs when your plugin is loaded.
        /// </summary>
        /// <param name="m">The instance of the Shotr core code.</param>
        public abstract void OnStarted(ShotrCore m);

        /// <summary>
        /// Runs when Shotr is closing.
        /// </summary>
        /// <param name="m">The instance of the Shotr core code.</param>
        public abstract void OnClosing(ShotrCore m);

        /// <summary>
        /// Grabs your form and places it as a tab in Shotr.
        /// </summary>
        /// <param name="m">The instance of the Shotr core code.</param>
        /// <returns>Your form instance.</returns>
        public abstract Form GetForm(ShotrCore m);

        /// <summary>
        /// Whether or not your plugin is enabled.
        /// </summary>
        public abstract bool Enabled { get; }
    }

    public class ShotrCore
    {

    }
}
