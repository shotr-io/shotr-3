using System.IO;
using Shotr.Ui.Properties;

namespace Shotr.Ui.Utils
{
    class MusicPlayer
    {
        private static System.Media.SoundPlayer sp;
        public static void PlayCaptured()
        {
            if (Program.Settings.GetValue("play_sounds") != null ? (bool)Program.Settings.GetValue("play_sounds")[0] : true)
            {
                using (MemoryStream p = new MemoryStream(Program.dc.Decrypt(Resources.sounds_1046_et_voila)))
                {
                    sp = new System.Media.SoundPlayer(p);
                    sp.Play();
                }
            }
        }

        public static void PlayUploaded()
        {
            if (Program.Settings.GetValue("play_sounds") != null ? (bool)Program.Settings.GetValue("play_sounds")[0] : true)
            {
                using (MemoryStream p = new MemoryStream(Program.dc.Decrypt(Resources.sounds_917_communication_channel)))
                {
                    sp = new System.Media.SoundPlayer(p);
                    sp.Play();
                }
            }
        }
    }
}
