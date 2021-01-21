using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Shotr.Core.Entities.Hotkeys;
using Shotr.Core.Settings;

namespace Shotr.Core.Services
{
    public class HotKeyService
    {
        private readonly BaseSettings _settings;
        private readonly KeyboardHook _keyboardHook;

        private readonly List<HotKeyHook> _hotkeys;
        private readonly List<KeyTask> _failed;

        public event EventHandler<KeyPressedEventArgs> KeyPressed = delegate { };

        public HotKeyService(BaseSettings settings, KeyboardHook keyboardHook)
        {
            _settings = settings;
            _keyboardHook = keyboardHook;

            _hotkeys = new List<HotKeyHook>();
            _failed = new List<KeyTask>();

            _keyboardHook.KeyPressed += (sender, args) =>
            {
                KeyPressed(sender, args);
            };
        }

        public void LoadHotKeys()
        {
            if (_settings.Login.Enabled == true)
            {
                LoadHotKey(_settings.Hotkey.Clipboard, KeyTask.UploadClipboard);
                LoadHotKey(_settings.Hotkey.Fullscreen, KeyTask.Fullscreen);
                LoadHotKey(_settings.Hotkey.RecordScreen, KeyTask.RecordScreen);
                LoadHotKey(_settings.Hotkey.ActiveWindow, KeyTask.ActiveWindow);
                LoadHotKey(_settings.Hotkey.Region, KeyTask.Region);
            }
            
            LoadHotKey(_settings.Hotkey.NoUpload, KeyTask.RegionNoUpload);
        }

        public void UnloadHotKeys()
        {
            foreach (var f in _hotkeys)
            {
                try
                {
                    _keyboardHook.UnregisterHotKey(f.Id);
                }
                catch { }
            }
            _hotkeys.Clear();
        }

        public void LoadSingleHotKey(Keys keys, KeyTask task)
        {
            LoadHotKey(keys, task);
        }

        public void UnloadHotKey(KeyTask task)
        {
            var hotkey = _hotkeys.FirstOrDefault(p => p.Task == task);
            if (hotkey is { })
            {
                _keyboardHook.UnregisterHotKey(hotkey.Id);
                _hotkeys.Remove(hotkey);
            }
        }
        
        public bool SetNewHook(HotKeyModifiers modifiers, Keys keys, KeyTask task)
        {
            var hotkey = GetHotKey(task);
            if (hotkey is { })
            {
                if (hotkey.Modifiers == modifiers && hotkey.Keys == keys)
                {
                    return true;
                }
                
                _keyboardHook.UnregisterHotKey(hotkey.Id);
                _hotkeys.Remove(hotkey);
            }

            try
            {
                if (keys == Keys.None)
                {
                    var newHotKey = new HotKeyHook(-1, 0, 0);
                    newHotKey.Task = task;
                    _hotkeys.Add(newHotKey);
                    return true;
                }

                var tempHotKey = _keyboardHook.RegisterHotKey(new HotKeyData(keys));
                tempHotKey.Task = task;
                _hotkeys.Add(tempHotKey);
                Console.WriteLine($"Modified hook for {task}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //register old hotkey.
                var oldHotKey = _keyboardHook.RegisterHotKey(new HotKeyData(hotkey.Keys));
                oldHotKey.Task = task;
                _hotkeys.Add(oldHotKey);
                return false;
            }

            return true;
        }

        public HotKeyHook? GetHotKey(KeyTask task)
        {
            return _hotkeys.FirstOrDefault(p => p.Task == task);
        }

        public HotKeyHook? GetHotKey(int id)
        {
            return _hotkeys.FirstOrDefault(p => p.Id == id);
        }

        private void LoadHotKey(Keys keys, KeyTask task)
        {
            try
            {
                if (keys == 0)
                {
                    Console.WriteLine($"Skipped {task} hook, because the keys were empty.");
                    return;
                }
                
                var hotkey = _keyboardHook.RegisterHotKey(new HotKeyData(keys));
                hotkey.Task = task;
                Console.WriteLine($"Added {task} hook.");
                _hotkeys.Add(hotkey);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to hook {task} capture hotkey: {ex}");
                _failed.Add(task);
            }
        }
    }
}