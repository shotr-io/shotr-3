using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Reflection;
using System.Text;
using Shotr.Core.MimeDetect.Matchers.TextSignature;

namespace Shotr.Core.MimeDetect.Matchers
{
	public class Text
	{
		private readonly List<Signature> _signatures = new List<Signature>();

		public Text()
		{
			// Create new instances of all types.
			foreach (Type f in Assembly.GetExecutingAssembly().GetTypes())
			{
				try
				{
					if (typeof(BaseTextSignature).IsAssignableFrom(f) && f != typeof(BaseTextSignature))
					{
						// Load
						var sigInstance = (BaseTextSignature) Activator.CreateInstance(f);
						// Create a lowercase entry for these signatures.				    
						_signatures.Add(new Signature(
							new List<string>(sigInstance.Signatures),
							sigInstance.Lang));
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}

		public bool Bash(byte[] f)
		{
			return DetectShebang(f, LangTypes.Bash);
		}

		public bool Cpp(byte[] f)
		{
			return Detect(f, LangTypes.Cpp);
		}

		public bool Go(byte[] f)
		{
			return Detect(f, LangTypes.Go);
		}

		public bool Css(byte[] f)
		{
			return Detect(f, LangTypes.Css);
		}

		public bool C(byte[] f)
		{
			return Detect(f, LangTypes.C);
		}

		public bool Cs(byte[] f)
		{
			return Detect(f, LangTypes.Cs);
		}

		public bool Rust(byte[] f)
		{
			return Detect(f, LangTypes.Rust);
		}

		public bool Txt(byte[] f)
		{
			var x = Matcher.TrimLws(f);
			foreach (var b in x)
			{
				if (b <= 0x08 || b == 0x0B || 0x0E <= b && b <= 0x1A || 0x1C <= b && b <= 0x1F)
				{
					return false;
				}
			}

			return true;
		}

		public bool Html(byte[] f)
		{
			return DetectMarkup(f, LangTypes.Html);
		}

		public bool Xml(byte[] f)
		{
			return DetectMarkup(f, LangTypes.Xml);
		}

		public bool Php(byte[] f)
		{
			if (!Detect(f, LangTypes.Php))
			{
				return DetectShebang(f, LangTypes.Php);
			}

			return true;
		}

		public bool Json(byte[] f)
		{
			try
			{
				JsonValue.Parse(Encoding.UTF8.GetString(f));
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Js(byte[] f)
		{
			return DetectShebang(f, LangTypes.Js);
		}

		public bool Lua(byte[] f)
		{
			return DetectShebang(f, LangTypes.Lua);
		}

		public bool Perl(byte[] f)
		{
			return DetectShebang(f, LangTypes.Perl);
		}

		public bool Python(byte[] f)
		{
			return DetectShebang(f, LangTypes.Python);
		}

		public bool Rtf(byte[] f)
		{
			return f.Prefix(new byte[] {0x7b, 0x5c, 0x72, 0x74, 0x66, 0x31});
		}

		public bool VisualBasic(byte[] f)
		{
			return Detect(f, LangTypes.VisualBasic);
		}
		
		
		private Signature Get(LangTypes type)
		{
			return _signatures.FirstOrDefault(l => l.LangType == type);
		}

		private bool DetectMarkup(byte[] file, LangTypes type)
		{
			var sigList = Get(type);
			foreach (var sig in sigList.Signatures)
			{
				var resp = MiniDetectMarkup(file, sig);
				if (resp)
				{
					return true;
				}
			}

			return false;
		}

		private bool MiniDetectMarkup(byte[] file, string sig)
		{
			if (file.Length < sig.Length + 1)
			{
				return false;
			}

			for (var i = 0; i < sig.Length; i++)
			{
				var db = file[i];
				if ('A' <= sig[i] && sig[i] <= 'Z')
				{
					db &= 0xDF;
				}

				if (sig[i] != db)
				{
					return false;
				}
			}
			
			var dd = file[sig.Length];
			if (dd != ' ' && dd != '>')
			{
				return false;
			}

			return true;
		}

		private bool Detect(byte[] file, LangTypes type)
		{
			var sigList = Get(type);
			foreach (var sig in sigList.Signatures)
			{
				if (MiniDetect(file, sig))
				{
					return true;
				}
			}

			return false;
		}

		private bool MiniDetect(byte[] file, string sig)
		{
			if (file.Length < sig.Length + 1)
			{
				return false;
			}
				
			for(var i = 0; i < sig.Length; i++)
			{
				var b = sig[i];
				var db = file[i];
				if ('A' <= b && b <= 'Z')
				{
					db &= 0xDF;
				}

				if (b != db)
				{
					return false;
				}
			}

			return true;
		}

		private bool DetectShebang(byte[] file, LangTypes type)
		{
			var line = Matcher.FirstLine(file);
			var matcher = Get(type);
			foreach (var sig in matcher.Signatures)
			{
				var rsp = MiniDetectShebang(line, sig);
				if (rsp)
				{
					return true;
				}
			}

			return false;
		}

		private bool MiniDetectShebang(byte[] line, string sig)
		{
			if (line.Length < sig.Length + 2)
			{
				return false;
			}

			if (line[0] != '#' || line[1] != '!')
			{
				return false;
			}

			var byt = Matcher.TrimLws(Matcher.TrimRws(line.Skip(2).ToArray()));
			
			return byt.Prefix(sig);
		}
	}
}