using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Shotr.Ui.Utils;

namespace Shotr.Ui.Capture
{
    public enum FFmpegVideoCodec
    {
        [Description("x264")]
        libx264,
        [Description("VP8")]
        libvpx,
        [Description("Xvid")]
        libxvid
    }

    public enum FFmpegPreset
    {
        [Description("Ultra fast")]
        ultrafast,
        [Description("Super fast")]
        superfast,
        [Description("Very fast")]
        veryfast,
        [Description("Faster")]
        faster,
        [Description("Fast")]
        fast,
        [Description("Medium")]
        medium,
        [Description("Slow")]
        slow,
        [Description("Slower")]
        slower,
        [Description("Very slow")]
        veryslow
    }

    public enum FFmpegAudioCodec
    {
        [Description("AAC")]
        libvoaacenc,
        [Description("Vorbis")]
        libvorbis,
        [Description("MP3")]
        libmp3lame
    }
    public class FFmpegHelper : ExternalCLIManager
    {
        public static readonly int libmp3lame_qscale_end = 9;
        public static readonly string SourceNone = "None";
        public static readonly string SourceGDIGrab = "GDI grab";

        public StringBuilder Output { get; private set; }
        public ScreencastOptions Options { get; private set; }

        public FFmpegHelper(ScreencastOptions options)
        {
            Output = new StringBuilder();
            OutputDataReceived += FFmpegHelper_DataReceived;
            ErrorDataReceived += FFmpegHelper_DataReceived;
            Options = options;
            //Directory.CreateDirectory(Options.OutputPath);
        }

        private void FFmpegHelper_DataReceived(object sender, DataReceivedEventArgs e)
        {
            lock (this)
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Output.AppendLine(e.Data);
                    Console.WriteLine(e.Data);
                }
            }
        }

        public bool Record()
        {
            int errorCode = OpenNoOutput(Options.FFmpeg.CLIPath, Options.GetFFmpegCommands());
            bool result = errorCode == 0;
            return result;
        }

        public DirectShowDevices GetDirectShowDevices()
        {
            DirectShowDevices devices = new DirectShowDevices();

            if (File.Exists(Options.FFmpeg.CLIPath))
            {
                string arg = "-list_devices true -f dshow -i dummy";
                Open(Options.FFmpeg.CLIPath, arg);
                string output = Output.ToString();
                string[] lines = output.Split('\n');
                bool isVideo = true;
                Regex regex = new Regex("\\[dshow @ \\w+\\]  \"(.+)\"", RegexOptions.Compiled | RegexOptions.CultureInvariant);
                foreach (string line in lines)
                {
                    if (line.EndsWith("] DirectShow video devices\r", StringComparison.InvariantCulture))
                    {
                        isVideo = true;
                        continue;
                    }

                    if (line.EndsWith("] DirectShow audio devices\r", StringComparison.InvariantCulture))
                    {
                        isVideo = false;
                        continue;
                    }

                    Match match = regex.Match(line);

                    if (match.Success)
                    {
                        string value = match.Groups[1].Value;

                        if (isVideo)
                        {
                            devices.VideoDevices.Add(value);
                        }
                        else
                        {
                            devices.AudioDevices.Add(value);
                        }
                    }
                }
            }

            return devices;
        }

        public override void Close()
        {
            if(Closed)
            {
                return;
            }
            WriteInput("q");
            Thread.Sleep(200);
            if (!Closed)
            {
                int i = 0;
                while (true)
                {
                    if (!Closed)
                    {
                        Thread.Sleep(100);
                        if (i < 600)
                        {
                            WriteInput("q");
                            i++;
                        }
                        else break;
                    }
                    else break;
                }
            }
        }
    }

    public class DirectShowDevices
    {
        public List<string> VideoDevices = new List<string>();
        public List<string> AudioDevices = new List<string>();
    }
    public class FFmpegOptions
    {
        // General
        public string VideoSource { get; set; }
        public string AudioSource { get; set; }
        public FFmpegVideoCodec VideoCodec { get; set; }
        public FFmpegAudioCodec AudioCodec { get; set; }
        public string Extension { get; set; }
        public string CLIPath { get; set; }
        public string UserArgs { get; set; }
        public bool ShowError { get; set; }
        public bool UseCustomCommands { get; set; }
        public string CustomCommands { get; set; }

        // H.264 - x264
        public FFmpegPreset Preset { get; set; }
        public int x264_CRF { get; set; }

        // H.264 - VPx
        public int VPx_CRF { get; set; }

        // H.263
        public int XviD_qscale { get; set; }

        // Audio
        public int AAC_bitrate { get; set; }  // kbit/s
        public int Vorbis_qscale { get; set; }
        public int MP3_qscale { get; set; }

        public bool IsSourceSelected
        {
            get
            {
                return IsVideoSourceSelected || IsAudioSourceSelected;
            }
        }

        public bool IsVideoSourceSelected
        {
            get
            {
                return !string.IsNullOrEmpty(VideoSource) && !VideoSource.Equals(FFmpegHelper.SourceNone, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public bool IsAudioSourceSelected
        {
            get
            {
                return !string.IsNullOrEmpty(AudioSource) && !AudioSource.Equals(FFmpegHelper.SourceNone, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public FFmpegOptions()
        {
            // General
            VideoSource = FFmpegHelper.SourceGDIGrab;
            AudioSource = FFmpegHelper.SourceNone;
            VideoCodec = FFmpegVideoCodec.libx264;
            AudioCodec = FFmpegAudioCodec.libvoaacenc;
            Extension = "mp4";
            CLIPath = "ffmpeg.exe";
            UserArgs = "";
            ShowError = true;

            // x264
            x264_CRF = 30;
            Preset = FFmpegPreset.fast;

            // VPx
            VPx_CRF = 12;

            // XviD
            XviD_qscale = 3;

            // Audio
            AAC_bitrate = 128;
            Vorbis_qscale = 3;
            MP3_qscale = 4;
        }
    }
    public class ScreencastOptions
    {
        public string OutputPath { get; set; }
        public int GIFFPS { get; set; }
        public int ScreenRecordFPS { get; set; }
        public Rectangle CaptureArea { get; set; }
        public float Duration { get; set; }
        public bool DrawCursor { get; set; }
        public FFmpegOptions FFmpeg { get; set; }
        public int Threads { get; set; }

        public ScreencastOptions()
        {
            FFmpeg = new FFmpegOptions();
        }

        public string GetFFmpegCommands()
        {
            string commands;

            if (FFmpeg.UseCustomCommands && !string.IsNullOrEmpty(FFmpeg.CustomCommands))
            {
                commands = FFmpeg.CustomCommands.
                    Replace("$fps$", ScreenRecordFPS.ToString()).
                    Replace("$area_x$", CaptureArea.X.ToString()).
                    Replace("$area_y$", CaptureArea.Y.ToString()).
                    Replace("$area_width$", CaptureArea.Width.ToString()).
                    Replace("$area_height$", CaptureArea.Height.ToString()).
                    Replace("$cursor$", DrawCursor ? "1" : "0").
                    Replace("$duration$", Duration.ToString("0.0", CultureInfo.InvariantCulture).
                    Replace("$output$", Path.ChangeExtension(OutputPath, FFmpeg.Extension)));
            }
            else
            {
                commands = GetFFmpegArgs();
            }

            return commands.Trim();
        }

        public string GetFFmpegArgs(bool isCustom = false)
        {
            if (!FFmpeg.IsVideoSourceSelected && !FFmpeg.IsAudioSourceSelected)
            {
                return null;
            }

            StringBuilder args = new StringBuilder();
            args.Append("-y "); // -y for overwrite file
            args.Append("-rtbufsize 500M "); // default real time buffer size was 3041280 (3M)

            string fps = isCustom ? "$fps$" : ScreenRecordFPS.ToString();
           
            if (FFmpeg.IsVideoSourceSelected)
            {
                if (FFmpeg.VideoSource.Equals(FFmpegHelper.SourceGDIGrab, StringComparison.InvariantCultureIgnoreCase))
                {
                    // http://ffmpeg.org/ffmpeg-devices.html#gdigrab
                    args.AppendFormat("-threads {6} -f gdigrab -framerate {0} -offset_x {1} -offset_y {2} -video_size {3}x{4} -draw_mouse {5} -i desktop ",
                        fps, isCustom ? "$area_x$" : CaptureArea.X.ToString(), isCustom ? "$area_y$" : CaptureArea.Y.ToString(),
                        isCustom ? "$area_width$" : CaptureArea.Width.ToString(), isCustom ? "$area_height$" : CaptureArea.Height.ToString(),
                        isCustom ? "$cursor$" : DrawCursor ? "1" : "0", Threads);
                   
                    if (FFmpeg.IsAudioSourceSelected)
                    {
                        args.AppendFormat("-f dshow -i audio=\"{0}\" ", FFmpeg.AudioSource);
                    }
                }
                else
                {
                    args.AppendFormat("-f dshow -framerate {0} -i video=\"{1}\"", fps, FFmpeg.VideoSource);

                    if (FFmpeg.IsAudioSourceSelected)
                    {
                        args.AppendFormat(":audio=\"{0}\" ", FFmpeg.AudioSource);
                    }
                    else
                    {
                        args.Append(" ");
                    }
                }
            }
            else if (FFmpeg.IsAudioSourceSelected)
            {
                args.AppendFormat("-f dshow -i audio=\"{0}\" ", FFmpeg.AudioSource);
            }

            if (!string.IsNullOrEmpty(FFmpeg.UserArgs))
            {
                args.Append(FFmpeg.UserArgs + " ");
            }

            if (FFmpeg.IsVideoSourceSelected)
            {
                args.AppendFormat("-c:v {0} ", FFmpeg.VideoCodec.ToString());
                args.AppendFormat("-r {0} ", fps); // output FPS
                switch (FFmpeg.VideoCodec)
                {
                    case FFmpegVideoCodec.libx264: // https://trac.ffmpeg.org/wiki/x264EncodingGuide
                        args.AppendFormat("-crf {0} ", FFmpeg.x264_CRF);
                        args.AppendFormat("-preset {0} ", FFmpeg.Preset.ToString());
                        args.AppendFormat("-tune {0} ", "zerolatency");
                        args.Append("-pix_fmt yuv420p "); // -pix_fmt yuv420p required otherwise can't stream in Chrome
                        break;
                    case FFmpegVideoCodec.libvpx: // https://trac.ffmpeg.org/wiki/vpxEncodingGuide
                        args.AppendFormat("-crf {0} ", FFmpeg.VPx_CRF);
                        //args.Append(" -minrate 1M -maxrate 1M -b:v 1M ");
                        break;
                    case FFmpegVideoCodec.libxvid: // https://trac.ffmpeg.org/wiki/How%20to%20encode%20Xvid%20/%20DivX%20video%20with%20ffmpeg
                        args.AppendFormat("-qscale:v {0} ", FFmpeg.XviD_qscale);
                        break;
                }
            }

            if (FFmpeg.IsAudioSourceSelected)
            {
                switch (FFmpeg.AudioCodec)
                {
                    case FFmpegAudioCodec.libvoaacenc: // http://trac.ffmpeg.org/wiki/AACEncodingGuide
                        args.AppendFormat("-c:a libvo_aacenc -ac 2 -b:a {0}k ", FFmpeg.AAC_bitrate); // -ac 2 required otherwise failing with 7.1
                        break;
                    case FFmpegAudioCodec.libvorbis: // http://trac.ffmpeg.org/wiki/TheoraVorbisEncodingGuide
                        args.AppendFormat("-c:a {0} -qscale:a {1} ", FFmpegAudioCodec.libvorbis.ToString(), FFmpeg.Vorbis_qscale);
                        break;
                    case FFmpegAudioCodec.libmp3lame: // http://trac.ffmpeg.org/wiki/Encoding%20VBR%20(Variable%20Bit%20Rate)%20mp3%20audio
                        args.AppendFormat("-c:a {0} -qscale:a {1} ", FFmpegAudioCodec.libmp3lame.ToString(), FFmpeg.MP3_qscale);
                        break;
                }
            }

            if (Duration > 0)
            {
                args.AppendFormat("-t {0} ", isCustom ? "$duration$" : Duration.ToString("0.0", CultureInfo.InvariantCulture)); // duration limit
            }

            args.AppendFormat("\"{0}\"", isCustom ? "$output$" : Path.ChangeExtension(OutputPath, FFmpeg.Extension));

            return args.ToString();
        }
    }
}
