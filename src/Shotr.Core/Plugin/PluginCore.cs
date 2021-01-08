using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Shotr.Core.Utils;
using Shotr.Ui.Custom;
using ShotrUploaderPlugin;

namespace Shotr.Core.Plugin
{
    public class PluginCore
    {
        public static List<ImageUploader> Uploaders = new List<ImageUploader>();
        public static List<ShotrCorePlugin> CorePlugin = new List<ShotrCorePlugin>();

        public static event EventHandler OnPluginsChanged = delegate { };

        public static void AddCorePluginItem(ShotrCorePlugin m)
        {
            CorePlugin.Add(m);
            //
            OnPluginsChanged.Invoke(null, EventArgs.Empty);
        }

        public static void RemoveCorePluginItem(ShotrCorePlugin m)
        {
            CorePlugin.Remove(m);
            //
            OnPluginsChanged.Invoke(null, EventArgs.Empty);
        }

        public static void AddImageUploaderItem(ImageUploader m)
        {
            Uploaders.Add(m);
            //fire event.
            OnPluginsChanged.Invoke(null, EventArgs.Empty);
        }

        public static void RemoveImageUploaderItem(ImageUploader m)
        {
            Uploaders.Remove(m);
            OnPluginsChanged.Invoke(null, EventArgs.Empty);
        }

        public static ImageUploader GetUploader(string uploader)
        {
            foreach (ImageUploader p in Uploaders)
            {
                if (p.Title == uploader)
                {
                    return p;
                }
            }
            return null;
        }

        public static void InitCustoms()
        {
            object[] pl = Settings.Instance.GetValue("program_custom_uploaders");
            if (pl != null)
            {
                try
                {
                    List<CustomUploaderInstance> p = ((List<CustomUploaderInstance>)pl[0]);
                    foreach (CustomUploaderInstance x in p)
                    {
                        Uploaders.Add(x.Uploader);
                    }
                    OnPluginsChanged.Invoke(null, EventArgs.Empty);
                }
                catch { }
            }
        }

        public static bool LoadCorePlugins()
        {
            //Initialize stuffs.
            Console.WriteLine("Loading core plugin types from local assembly...");
            //Load all modules from current module.
            try
            {
                foreach (Type f in Assembly.GetExecutingAssembly().GetTypes())
                {
                    try
                    {
                        if (typeof(ShotrCorePlugin).IsAssignableFrom(f) && f != typeof(ShotrCorePlugin))
                        {
                            Console.WriteLine("Loaded type {0}.", f);
                            ShotrCorePlugin core = (ShotrCorePlugin)Activator.CreateInstance(f);
                            AddCorePluginItem(core);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }
            catch (ReflectionTypeLoadException e)
            {
                foreach (Exception p in e.LoaderExceptions)
                    Console.WriteLine(p.ToString());
            }
            //Load Plugins.
            if (!Directory.Exists(Settings.FolderPath + "Plugins")) { Directory.CreateDirectory(Settings.FolderPath + "Plugins"); }
            Console.WriteLine("Loading core plugin types from " + Settings.FolderPath + "Plugins");
            foreach (string filename in Directory.GetFiles(Settings.FolderPath + "Plugins\\"))
            {
                if (filename.EndsWith(".dll"))
                {
                    Assembly g = Assembly.Load(File.ReadAllBytes(filename));
                    //Test to see if it's a module.
                    if (g != null)
                    {
                        try
                        {
                            foreach (Type f in g.GetTypes())
                            {
                                if (typeof(ShotrCorePlugin).IsAssignableFrom(f) && f != typeof(ShotrCorePlugin))
                                {
                                    Console.WriteLine("Loaded type {0}.", f);
                                    ShotrCorePlugin core = (ShotrCorePlugin)Activator.CreateInstance(f);
                                    AddCorePluginItem(core);
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            return true;
        }

        public static bool Initialize()
        {
            //Initialize stuffs.
            Console.WriteLine("Loading types from local assembly...");
            //Load all modules from current module.
            try
            {
                foreach (Type f in Assembly.GetExecutingAssembly().GetTypes())
                {
                    try
                    {
                        if (typeof(ImageUploader).IsAssignableFrom(f) && f != typeof(ImageUploader) && f != typeof(UploaderBridge))
                        {
                            //Load the module.
                            Console.WriteLine("Loaded type {0}.", f);
                            ImageUploader brm = (ImageUploader)Activator.CreateInstance(f);
                            AddImageUploaderItem(brm);
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                }
            }
            catch (ReflectionTypeLoadException e)
            {
                foreach (Exception p in e.LoaderExceptions)
                    Console.WriteLine(p.ToString());
            }
            //Load Plugins.
            if (!Directory.Exists(Settings.FolderPath + "Plugins")) { Directory.CreateDirectory(Settings.FolderPath + "Plugins"); }
            Console.WriteLine("Loading types from "+ Settings.FolderPath + "Plugins");
            foreach (string filename in Directory.GetFiles(Settings.FolderPath + "Plugins\\"))
            {
                if (filename.EndsWith(".dll"))
                {
                    Assembly g = Assembly.Load(File.ReadAllBytes(filename));
                    //Test to see if it's a module.
                    if (g != null)
                    {
                        try
                        {
                            foreach (Type f in g.GetTypes())
                            {
                                if (typeof(ImageUploader).IsAssignableFrom(f) && f != typeof(ImageUploader))
                                {
                                    Console.WriteLine("Loaded type {0}.", f);
                                    ImageUploader plug = (ImageUploader)Activator.CreateInstance(f);
                                    AddImageUploaderItem(plug);
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            if (Uploaders.Count <= 0) { return false; }
            return true;
        }
    }
}

