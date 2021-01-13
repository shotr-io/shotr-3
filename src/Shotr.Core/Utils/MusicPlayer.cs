﻿using System.IO;
using System.Media;
using Shotr.Core.Properties;
using Shotr.Core.Settings;

namespace Shotr.Core.Utils
{
    public class MusicPlayer
    {
        private readonly BaseSettings _settings;
        private readonly dcrypt _dcrypt;

        private readonly SoundPlayer _capturedSound;
        private readonly SoundPlayer _uploadedSound;

        public MusicPlayer(BaseSettings settings, dcrypt dcrypt)
        {
            _settings = settings;
            _dcrypt = dcrypt;

            var capturedMemoryStream = new MemoryStream(_dcrypt.Decrypt(Resources.sounds_1046_et_voila));
            _capturedSound = new SoundPlayer(capturedMemoryStream);
                
                
            var uploadedMemoryStream = new MemoryStream(_dcrypt.Decrypt(Resources.sounds_917_communication_channel));
            _uploadedSound = new SoundPlayer(uploadedMemoryStream);
        }
        
        public void PlayCaptured()
        {
            if (_settings.PlaySounds)
            {
                _capturedSound.Play();
            }
        }

        public void PlayUploaded()
        {
            if (_settings.PlaySounds)
            {
                _uploadedSound.Play();
            }
        }
    }
}
