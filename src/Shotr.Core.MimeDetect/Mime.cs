using System.IO;
using Shotr.Core.MimeDetect.Matchers;

namespace Shotr.Core.MimeDetect
{
    public class Mime
    {
        private Node _root;
        private Text _textMatcher;
        
        public Mime()
        {
	        // MS Office			
	        var Xlsx   = new Node(FileTypeEnum.Document, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx", MsOffice.Xlsx);
	        var Docx   = new Node(FileTypeEnum.Document, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx", MsOffice.Docx);
	        var Pptx   = new Node(FileTypeEnum.Document, "application/vnd.openxmlformats-officedocument.presentationml.presentation", "pptx", MsOffice.Pptx);
	        var Doc    = new Node(FileTypeEnum.Document, "application/msword", "doc", MsOffice.Doc);
	        var Ppt    = new Node(FileTypeEnum.Document, "application/vnd.ms-powerpoint", "ppt", MsOffice.Ppt);
	        var Xls    = new Node(FileTypeEnum.Document, "application/vnd.ms-excel", "xls", MsOffice.Xls);
	        
	        // Archive
            var SevenZ = new Node(FileTypeEnum.Archive, "application/x-7z-compressed", "7z", Archive.SevenZ);
            var Epub   = new Node(FileTypeEnum.Archive, "application/epub+zip", "epub", Archive.Epub);
            var Apk    = new Node(FileTypeEnum.Archive, "application/vnd.android.package-archive", "apk", Matcher.False);
            var Jar    = new Node(FileTypeEnum.Archive, "application/jar", "jar", Archive.Jar, Apk);
			var Zip    = new Node(FileTypeEnum.Archive, "application/zip", "zip", Archive.Zip, Xlsx, Docx, Pptx, Epub, Jar);
			var Rar = new Node(FileTypeEnum.Archive, "application/x-rar-compressed", "rar", Archive.Rar);
			var Targz = new Node(FileTypeEnum.Archive, "application/gzip", "tar.gz", Archive.TarGz);
			
			// Document
			var Pdf    = new Node(FileTypeEnum.Pdf, "application/pdf", "pdf", Document.Pdf);
			
			// Image
			var Ps   = new Node(FileTypeEnum.Document, "application/postscript",  "ps",   Image.Ps);
			var Psd  = new Node(FileTypeEnum.Document, "application/x-photoshop", "psd",  Image.Psd);
			var Png  = new Node(FileTypeEnum.Image,    "image/png",               "png",  Image.Png);
			var Jpg  = new Node(FileTypeEnum.Image,    "image/jpeg",              "jpg",  Image.Jpg);
			var Gif  = new Node(FileTypeEnum.Image,    "image/gif",               "gif",  Image.Gif);
			var Webp = new Node(FileTypeEnum.Image,    "image/webp",              "webp", Image.Webp);
			var Tiff = new Node(FileTypeEnum.Image,    "image/tiff",              "tiff", Image.Tiff);
			var Bmp  = new Node(FileTypeEnum.Image,    "image/bmp",               "bmp",  Image.Bmp);
			var Svg  = new Node(FileTypeEnum.Image,    "image/svg+xml",           "svg",  Image.Svg);
			//var Heic = new Node(FileTypeEnum.Image, "image/heic", "heic", Image.Heic);

			// Audio
			var Ogg      = new Node(FileTypeEnum.Audio, "application/ogg", "ogg",  Audio.Ogg);
			var Mp3      = new Node(FileTypeEnum.Audio, "audio/mpeg",      "mp3",  Audio.Mp3);
			var Flac     = new Node(FileTypeEnum.Audio, "audio/flac",      "flac", Audio.Flac);
			var Midi     = new Node(FileTypeEnum.Audio, "audio/midi",      "midi", Audio.Midi);
			var Ape      = new Node(FileTypeEnum.Audio, "audio/ape",       "ape",  Audio.Ape);
			var MusePack = new Node(FileTypeEnum.Audio, "audio/musepack",  "mpc",  Audio.MusePack);
			var Wav      = new Node(FileTypeEnum.Audio, "audio/wav",       "wav",  Audio.Wav);
			var Aiff     = new Node(FileTypeEnum.Audio, "audio/aiff",      "aiff", Audio.Aiff);
			var Au       = new Node(FileTypeEnum.Audio, "audio/basic",     "au",   Audio.Au);

			// Other XML types
			var X3d     = new Node(FileTypeEnum.Text, "model/x3d+xml",                        "x3d", Matcher.False);
			var Kml     = new Node(FileTypeEnum.Text, "application/vnd.google-earth.kml+xml", "kml", Matcher.False);
			var Collada = new Node(FileTypeEnum.Text, "model/vnd.collada+xml",                "dae", Matcher.False);
			var Gml     = new Node(FileTypeEnum.Text, "application/gml+xml",                  "gml", Matcher.False);
			var Gpx     = new Node(FileTypeEnum.Text, "application/gpx+xml",                  "gpx", Matcher.False);

			// Text
			_textMatcher = new Text();
			var Bash   = new Node(FileTypeEnum.Text, "text/x-shellscript",        "sh",   _textMatcher.Bash);
			var Json   = new Node(FileTypeEnum.Text, "text/json",                 "json", _textMatcher.Json);
			var Html   = new Node(FileTypeEnum.Text, "text/html; charset=utf-8",  "html", _textMatcher.Html);
			var Php    = new Node(FileTypeEnum.Text, "text/x-php; charset=utf-8", "php",  _textMatcher.Php);
			var Rtf    = new Node(FileTypeEnum.Text, "text/rtf",                  "rtf",  _textMatcher.Rtf);
			var Go     = new Node(FileTypeEnum.Text, "text/x-go",                 "go",   _textMatcher.Go);
			var Cs     = new Node(FileTypeEnum.Text, "text/cs",                   "cs",   _textMatcher.Cs);
			var Css    = new Node(FileTypeEnum.Text, "text/css",                  "css",  _textMatcher.Css);
			var C      = new Node(FileTypeEnum.Text, "text/x-c",                  "c",    _textMatcher.C);
			var Cpp    = new Node(FileTypeEnum.Text, "text/x-cpp",                "cpp",  _textMatcher.Cpp);
			var Js     = new Node(FileTypeEnum.Text, "text/javascript",           "js",   _textMatcher.Js);
			var Lua    = new Node(FileTypeEnum.Text, "text/x-lua",                "lua",  _textMatcher.Lua);
			var Perl   = new Node(FileTypeEnum.Text, "text/x-perl",               "pl",   _textMatcher.Perl);
			var Rust   = new Node(FileTypeEnum.Text, "text/x-rust",               "rs",   _textMatcher.Rust);
			var Python = new Node(FileTypeEnum.Text, "text/x-python",             "py",   _textMatcher.Python);
			var Vb     = new Node(FileTypeEnum.Text, "text/x-visualbasic",        "vb",   _textMatcher.VisualBasic);
			var Xml    = new Node(FileTypeEnum.Text, "text/xml; charset=utf-8", "xml", _textMatcher.Xml,
			                   Svg, X3d, Kml, Collada, Gml, Gpx);
			var Txt = new Node(FileTypeEnum.Text, "text/plain", "txt", _textMatcher.Txt,
			                   Bash, Html, Xml, Cpp, C, Css, Go, Cs, Cpp, Php, Js, Lua, Perl, Python, Rust, Vb, Json, Rtf);
			
			// Video
			var Mp4       = new Node(FileTypeEnum.Video, "video/mp4", "mp4", Video.Mp4);
			var WebM      = new Node(FileTypeEnum.Video, "video/webm", "webm", Video.WebM);
			var Mpeg      = new Node(FileTypeEnum.Video, "video/mpeg", "mpeg", Video.Mpeg);
			var Quicktime = new Node(FileTypeEnum.Video, "video/quicktime", "mov", Video.Quicktime);
			var ThreeGP   = new Node(FileTypeEnum.Video, "video/3gp", "3gp", Video.ThreeGP);
			var Avi       = new Node(FileTypeEnum.Video, "video/x-msvideo", "avi", Video.Avi);
			var Flv       = new Node(FileTypeEnum.Video, "video/x-flv", "flv", Video.Flv);

			_root = new Node(FileTypeEnum.Unknown, "application/octet-stream", "", Matcher.True, 
				SevenZ, Rar, Targz, Zip, Pdf, Png, Jpg, Gif, Webp, Tiff, Bmp, Svg,//Heic,
				Mp3, Flac, Midi, Ape, MusePack, Wav, Aiff, Mpeg, Au, Quicktime, Mp4, Ogg, WebM, ThreeGP, Avi, Flv, Ps, Psd, Txt,
				Doc, Xls, Ppt);
        }

        public Node Detect(byte[] file)
        {
            return _root.Match(file, _root);
        }

        public Node DetectFile(string path)
        {
	        if (File.Exists(path)) 
	        {
		        using (var f = new FileStream(path, FileMode.Open, FileAccess.Read))
		        {
			        byte[] b;
			        if (f.Length > 1024)
			        {
				        b = new byte[1024];
				        f.Read(b, 0, 1024);
			        }
			        else
			        {
				        b = new byte[f.Length];
				        f.Read(b, 0, (int)f.Length);
			        }
					var n = _root.Match(b, _root);
					return n;
		        }
	        }

	        return null;
        }

		public string GetMimeForFileExtension(string ext)
        {
            return _root.GetMimeForFileExt(null, ext);
        }

        public string GetFileExtensionForMime(string mime)
        {
            return _root.GetFileExtForMime(null, mime);
        }

		public string Tree()
        {
            return _root.Tree();
        }
    }
}