using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Shotr.Ui.Custom;
using Shotr.Ui.Hotkey;
using ShotrUploaderPlugin;

namespace Shotr.Ui.Utils
{
    [Serializable]
    public class Settings
    {
        public BinaryFormatter bin = new BinaryFormatter();
        public KeyboardHook hook = new KeyboardHook();
        public List<HotKeyHook> hotkeys = new List<HotKeyHook>();

        public Dictionary<string, object[]> settings = new Dictionary<string, object[]>();
        public Dictionary<long, UploadResult> ImageHistory = new Dictionary<long, UploadResult>();

        public string email;
        public string password;
        public string token;
        public bool login = false;

        public void CreateNewSettings()
        {
            //Create new settings.
            settings = new Dictionary<string, object[]>()
                {
                    { "region_hotkey", new object[] { Keys.Control | Keys.Shift | Keys.D4 } },
                    { "region_fullscreen", new object[] { Keys.Control | Keys.Shift | Keys.D3 } },
                    { "region_activewindow", new object[] { Keys.Control | Keys.Shift | Keys.D2 } },
                    { "region_record_screen", new object[] {Keys.Control | Keys.Shift | Keys.D1} },
                    { "region_clipboard", new object[] { Keys.Control | Keys.Shift | Keys.D5 } },
                    { "region_noupload_hotkey", new object[] { Keys.Control | Keys.Shift | Keys.Oemtilde } },
                    { "start_with_windows", new object[] { true } },
                    { "start_minimized", new object[] { false } },
                    { "image_history", new object[] { } },
                    { "image_uploader", new object[] { "Shotr" } },
                    { "image_uploader_direct_url", new object[] { false } },
                    { "program_subscribe_to_alpha_beta_releases", new object[] { false } },
                    { "program_stitch_fullscreen", new object[] { true } },
                    { "program_custom_uploaders", new object[] { new List<CustomUploaderInstance>() } },
                    { "region_capture_information", new object[] { true } },
                    { "region_capture_zoom", new object[] { true } },
                    { "region_capture_color", new object[] { true } },
                    { "play_sounds", new object[] { true } },
                    { "program_show_notifications", new object[] { true } },
                    { "shotr.login", new object[] { } },
                    { "screenshot.use_resizable_canvas", new object[] { true } },
                    { "settings.version", new object[] { 0 } },
                    { "settings.updatedto", new object[] { 0 } },
                    { "settings.show_record_warning", new object[] { true } },
                    { "shotr.token", new object[] { "" } }
                };
            Utils.AddToStartup(true);
            CheckNewSettings();
            SaveSettings();
        }

        private void DefaultHotKeys()
        {
            ChangeKey("region_hotkey", new object[] { Keys.Control | Keys.Shift | Keys.D4 });
            ChangeKey("region_fullscreen", new object[] { Keys.Control | Keys.Shift | Keys.D3 });
            ChangeKey("region_activewindow", new object[] { Keys.Control | Keys.Shift | Keys.D2 });
            ChangeKey("region_clipboard", new object[] { Keys.Control | Keys.Shift | Keys.D5 });
            ChangeKey("region_record_screen", new object[] { Keys.Control | Keys.Shift | Keys.D1 });
            ChangeKey("region_noupload_hotkey", new object[] { Keys.Control | Keys.Shift | Keys.D6 });
        }

        public void DumpSettings()
        {
            Console.WriteLine("Settings dump....");
            foreach (var item in settings)
            {
                Console.WriteLine($"==== {item.Key} ====");
                foreach (var value in item.Value)
                {
                    Console.WriteLine(value);
                }
            }
            Console.WriteLine("End Settings dump....");
        }
        //save status of shit.
        public void LoadSettings()
        {
            if (File.Exists(Program.FolderPath + "history"))
            {
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(Program.FolderPath + "history"));
                try
                {
                    ImageHistory = (Dictionary<long, UploadResult>)bin.Deserialize(ms);
                }
                catch { /*MessageBox.Show(ex.ToString());*/ }
            }
            if (File.Exists(Program.FolderPath + "settings"))
            {
                MemoryStream ms = new MemoryStream(File.ReadAllBytes(Program.FolderPath + "settings"));
                try
                {
                    settings = (Dictionary<string, object[]>)bin.Deserialize(ms);
                    CheckNewSettings();
                    return;
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }
            CreateNewSettings();
        }
        //
        public void SaveSettings()
        {
            try
            {
                using (MemoryStream ok = new MemoryStream())
                {
                    //go through each thing and see if it's a typeloadexceptionholder
                    if (settings.ContainsKey("program_custom_uploaders"))
                    {
                        foreach (object m in settings["program_custom_uploaders"])
                        {
                            if (m.GetType().ToString() == "System.Runtime.Serialization.TypeLoadExceptionHolder")
                            {
                                //remove it from the list.
                                settings["program_custom_uploaders"] = new object[] { new List<CustomUploaderInstance>() };
                                break;
                            }
                        }
                    }
                    bin.Serialize(ok, settings);
                    File.WriteAllBytes(Program.FolderPath + "settings", ok.ToArray());
                }
                using (MemoryStream ok = new MemoryStream())
                {
                    bin.Serialize(ok, ImageHistory);
                    File.WriteAllBytes(Program.FolderPath + "history", ok.ToArray());
                }
            }
            catch
            {
            }
        }
        private int GetUpdatedTo()
        {
            return (int)GetValue("settings.updatedto")[0];
        }
        private void SetUpdatedTo(int ver)
        {
            ChangeKey("settings.updatedto", new object[] { ver });
            ChangeKey("settings.version", new object[] { ver });
        }
        private void CheckNewSettings()
        {
            //check for settings versions.
            try
            {
                if (GetValue("settings.version") == null)
                {
                    SetUpdatedTo(0);
                }
            }
            catch
            {
                SetUpdatedTo(0);
            }

            try
            {
                if (((int)GetValue("settings.version")[0]) == 0)
                {
                    if (GetUpdatedTo() < 1)
                    {
                        ChangeKey("settings.screen_recording", new object[] { 60, 4, true });
                        ChangeKey("settings.screenshot", new object[] { FileExtensions.png, CompressionLevel.High, true });
                        SetUpdatedTo(1);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 1)
                {
                    if (GetUpdatedTo() < 2)
                    {
                        ChangeKey("settings.screen_recording", new object[] { 60, 4, true, false, "" });
                        ChangeKey("settings.screenshot", new object[] { FileExtensions.png, CompressionLevel.High, true });
                        SetUpdatedTo(2);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 2)
                {
                    if (GetUpdatedTo() < 3)
                    {
                        ChangeKey("settings.screenshot", new object[] { FileExtensions.png, CompressionLevel.High, true });
                        ChangeKey("region_clipboard", new object[] { Keys.Control | Keys.Shift | Keys.D5 });
                        SetUpdatedTo(3);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 3)
                {
                    if (GetUpdatedTo() < 4)
                    {
                        //read all custom uploaders.
                        List<CustomUploaderInstance> m = (List<CustomUploaderInstance>)GetValue("program_custom_uploaders")[0];
                        //read each one and convert to new custom uploader instnace.
                        List<CustomUploaderInstance> p = new List<CustomUploaderInstance>();
                        foreach (CustomUploaderInstance i in m)
                        {
                            CustomUploaderInstance x = new CustomUploaderInstance(i.Title, i.URL, i.RequestType, i.FormName, i.UsePageURL, i.UploadValues, false, "");
                            p.Add(x);
                        }
                        m.Clear();
                        ChangeKey("settings.screenshot", new object[] { FileExtensions.png, CompressionLevel.High, true });
                        ChangeKey("program_custom_uploaders", new object[] { p });
                        SetUpdatedTo(4);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 4)
                {
                    if (GetUpdatedTo() < 5)
                    {
                        //add key for notifications.
                        ChangeKey("program_show_notifications", new object[] { true });
                        SetUpdatedTo(5);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 5)
                {
                    if (GetUpdatedTo() < 6)
                    {
                        ChangeKey("general.savetodirectory", new object[] { false });
                        SetUpdatedTo(6);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 6)
                {
                    if (GetUpdatedTo() < 7)
                    {
                        //add in login variable to store past logins.
                        ChangeKey("shotr.login", new object[] { });
                        ChangeKey("shotr.key", new object[] { });
                        SetUpdatedTo(7);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 7)
                {
                    if (GetUpdatedTo() < 8)
                    {
                        //add option for resizable canvas.
                        ChangeKey("screenshot.use_resizable_canvas", new object[] { true });
                        SetUpdatedTo(8);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 8)
                {
                    if (GetUpdatedTo() < 9)
                    {
                        ChangeKey("settings.show_record_warning", new object[] { true });
                        SetUpdatedTo(9);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 9)
                {
                    if (GetUpdatedTo() < 10)
                    {
                        ChangeKey("general.savetodirectory", new object[] { false, "" });
                        SetUpdatedTo(10);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 10)
                {
                    if (GetUpdatedTo() < 11)
                    {
                        ChangeKey("region_noupload_hotkey", new object[] { Keys.Control | Keys.Shift | Keys.Oemtilde });
                        SetUpdatedTo(11);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 11)
                {
                    if (GetUpdatedTo() < 12)
                    {
                        ChangeKey("shotr.token", new object[] { "" });
                        SetUpdatedTo(12);
                    }
                }

                if ((int)GetValue("settings.version")[0] == 12)
                {
                    if (GetUpdatedTo() < 13)
                    {
                        var saveToDirectory = GetValue("general.savetodirectory");
                        if (saveToDirectory.Length < 2)
                        {
                            ChangeKey("general.savetodirectory", new object[] { false, "" });
                        }
                        SetUpdatedTo(13);
                    }
                }
            }
            catch
            {
            }
        }

        public UploadResult GetUploadedImage(string time)
        {
            return ImageHistory[Utils.ToUnixTime(DateTime.Parse(time))];
        }

        public UploadResult GetUploadedImage(long unixtime)
        {
            return ImageHistory[unixtime];
        }

        public void ChangeKey(string key, object[] value)
        {
            if (settings.ContainsKey(key))
                //delete key.
                settings.Remove(key);
            //add key.
            settings.Add(key, value);
            //save settings.
            SaveSettings();
        }

        public object[] GetValue(string key)
        {
            if(settings.ContainsKey(key))
            {
                return settings[key];
            }
            return new object[] { false };
        }

        public bool SetNewHook(Modifiers mk, Keys k, KeyTask task)
        {
            //check if it is the same
            foreach (HotKeyHook hk in hotkeys)
            {
                if (hk.Task == task)
                {
                    //is it the same?
                    if (hk.Modifiers == mk && hk.Keys == k)
                    {
                        return true;
                    }
                    else
                    {
                        hook.UnregisterHotKey(hk.ID);
                        hotkeys.Remove(hk);
                        try
                        {
                            if (k == Keys.None)
                            {
                                //set to none?
                                string type1 = ((ScreenshotType)task).ToString();
                                settings.Remove(type1);
                                settings.Add(type1, new object[] { k });
                                HotKeyHook p = new HotKeyHook(-1, 0, 0);
                                p.Task = task;
                                hotkeys.Add(p);
                                return true;
                            }
                            HotKeyHook tmp = hook.RegisterHotKey(new HotKeyData(k));
                            tmp.Task = task;
                            hotkeys.Add(tmp);
                            //save that shit.
                            string type = ((ScreenshotType)task).ToString();
                            settings.Remove(type);
                            settings.Add(type, new object[] { k });
                            Console.WriteLine("Modified hook for {0}.", type);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            //register old hotkey.
                            HotKeyHook hs = hook.RegisterHotKey(new HotKeyData(hk.Keys));
                            hs.Task = task;
                            hotkeys.Add(hs);
                            return false;
                        }
                        break;
                    }
                }
            }
            SaveSettings();
            return true;
        }

        public Settings()
        {
            LoadSettings();
            LoadHotKeys();
            //startup fullscreen window listener.
            
        }

        public void UnloadHotKeys()
        {
            foreach (HotKeyHook f in hotkeys)
            {
                try
                {
                    hook.UnregisterHotKey(f.ID);
                }
                catch { }
            }
            hotkeys.Clear();
        }

        public void LoadHotKeys()
        {
            try
            {
                if (GetValue("region_hotkey").Length >= 2)
                {
                    //new settings.
                    MessageBox.Show("Shotr has detected an old settings configuration. Shotr will need to replace your old configuration with a new one. To do this, your hotkeys will be set back to default.", "Shotr", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //set hotkeys back to default.
                    DefaultHotKeys();
                }

                List<KeyTask> failed = new List<KeyTask>();
                try
                {
                    if (GetValue("region_hotkey") == null) { ChangeKey("region_hotkey", new object[] { Keys.Control | Keys.Shift | Keys.D4 }); }
                    HotKeyHook region = hook.RegisterHotKey(new HotKeyData((Keys)GetValue("region_hotkey")[0]));
                    region.Task = KeyTask.Region;
                    hotkeys.Add(region);
                    Console.WriteLine("Added region hook.");
                }
                catch 
                {
                    Console.WriteLine("Failed to hook region capture hotkey.");
                    failed.Add(KeyTask.Region);
                }

                try { 
                    if (GetValue("region_fullscreen") == null) { ChangeKey("region_fullscreen", new object[] { Keys.Control | Keys.Shift | Keys.D3 }); }
                    HotKeyHook fullscreen = hook.RegisterHotKey(new HotKeyData((Keys)GetValue("region_fullscreen")[0]));
                    fullscreen.Task = KeyTask.Fullscreen;
                    hotkeys.Add(fullscreen);
                    Console.WriteLine("Added fullscreen hook.");
                }
                catch
                {
                    Console.WriteLine("Failed to hook fullscreen capture hotkey.");
                    failed.Add(KeyTask.Fullscreen);
                }

                try 
                { 
                    if (GetValue("region_activewindow") == null) { ChangeKey("region_activewindow", new object[] { Keys.Control | Keys.Shift | Keys.D2 }); }
                    HotKeyHook active = hook.RegisterHotKey(new HotKeyData((Keys)GetValue("region_activewindow")[0]));
                    active.Task = KeyTask.ActiveWindow;
                    hotkeys.Add(active);
                    Console.WriteLine("Added active window hook.");
                }
                catch
                {
                    Console.WriteLine("Failed to hook active window capture hotkey.");
                    failed.Add(KeyTask.ActiveWindow);
                }

                try
                { 
                    if (GetValue("region_record_screen") == null) { ChangeKey("region_record_screen", new object[] { Keys.Control | Keys.Shift | Keys.D1 }); }
                    HotKeyHook record = hook.RegisterHotKey(new HotKeyData((Keys)GetValue("region_record_screen")[0]));
                    record.Task = KeyTask.RecordScreen;
                    hotkeys.Add(record);
                    Console.WriteLine("Added record screen hook: {0}.", record.Task.ToString());
                }
                catch
                {
                    Console.WriteLine("Failed to hook record screen hotkey.");
                    failed.Add(KeyTask.RecordScreen);
                }

                try
                {
                    if (GetValue("region_clipboard") == null) { ChangeKey("region_clipboard", new object[] { Keys.Control | Keys.Shift | Keys.D5 }); }
                    HotKeyHook clipboard = hook.RegisterHotKey(new HotKeyData((Keys)GetValue("region_clipboard")[0]));
                    clipboard.Task = KeyTask.UploadClipboard;
                    hotkeys.Add(clipboard);
                    Console.WriteLine("Added clipboard upload hook: {0}.", clipboard.Task.ToString());
                }
                catch
                {
                    Console.WriteLine("Failed to hook clipboard upload hotkey.");
                    failed.Add(KeyTask.UploadClipboard);
                }

                try
                {
                    if (GetValue("region_noupload_hotkey") == null) { ChangeKey("region_noupload_hotkey", new object[] { Keys.Control | Keys.Shift | Keys.D6 }); }
                    HotKeyHook noupload = hook.RegisterHotKey(new HotKeyData((Keys)GetValue("region_noupload_hotkey")[0]));
                    noupload.Task = KeyTask.RegionNoUpload;
                    hotkeys.Add(noupload);
                    Console.WriteLine("Added clipboard upload hook: {0}.", noupload.Task.ToString());
                }
                catch
                {
                    Console.WriteLine("Failed to hook no upload hotkey.");
                    failed.Add(KeyTask.RegionNoUpload);
                }

                if (failed.Count > 0)
                {
                    string list = "";
                    foreach (KeyTask i in failed)
                    {
                        list += "\"" + i.ToString() + "\"\n";
                    }
                    MessageBox.Show(String.Format("Could not set a global keyboard hook for the following keys: \n{0}\nPlease close any applications that may be using hotkeys or change the hotkeys in the \"Settings\" menu.", list), "Shotr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                //MessageBox.Show("Could not set a global keyboard hook! Please close any applications that may be using hotkeys or change the hotkeys in the \"Settings\" menu.", "Shotr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    public enum ScreenshotType : int
    {
        region_empty = -1,
        region_hotkey = 1,
        region_fullscreen = 2,
        region_activewindow = 3,
        region_record_screen = 4,
        region_clipboard = 5,
        region_noupload_hotkey = 6,
    }

    public enum CompressionLevel : int
    {
        Maximum = 100,
        Ultra = 90,
        High = 75,
        Medium = 50,
        Low = 40
    }
}
