using System.IO;
using System.Media;
using Shotr.Core.Entities;
using Shotr.Core.Properties;
using Shotr.Core.Settings;

namespace Shotr.Core.Services
{
    public class MusicPlayerService
    {
        private readonly BaseSettings _settings;
        private readonly dcrypt _dcrypt;

        private readonly SoundPlayer _capturedSound;

        public MusicPlayerService(BaseSettings settings, dcrypt dcrypt)
        {
            _settings = settings;
            _dcrypt = dcrypt;

            var capturedMemoryStream = new MemoryStream(_dcrypt.Decrypt(Resources.sounds_1046_et_voila));
            _capturedSound = new SoundPlayer(capturedMemoryStream);
        }
        
        public void PlayCaptured()
        {
            if (_settings.PlaySounds)
            {
                _capturedSound.Play();
            }
        }
    }
}
