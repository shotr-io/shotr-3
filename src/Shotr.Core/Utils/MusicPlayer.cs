using System.IO;
using System.Media;
using Shotr.Core.Properties;

namespace Shotr.Core.Utils
{
    public class MusicPlayer
    {
        private static SoundPlayer sp;
        public static void PlayCaptured()
        {
            if (Settings.Instance.GetValue("play_sounds") == null || (bool)Settings.Instance.GetValue("play_sounds")[0])
            {
                using (MemoryStream p = new MemoryStream(Settings.dc.Decrypt(Resources.sounds_1046_et_voila)))
                {
                    sp = new SoundPlayer(p);
                    sp.Play();
                }
            }
        }

        public static void PlayUploaded()
        {
            if (Settings.Instance.GetValue("play_sounds") == null || (bool)Settings.Instance.GetValue("play_sounds")[0])
            {
                using (MemoryStream p = new MemoryStream(Settings.dc.Decrypt(Resources.sounds_917_communication_channel)))
                {
                    sp = new SoundPlayer(p);
                    sp.Play();
                }
            }
        }
    }
}
