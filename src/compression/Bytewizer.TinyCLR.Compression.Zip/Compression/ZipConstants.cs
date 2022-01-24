using System.Text;

#if NanoCLR
namespace Bytewizer.NanoCLR.IO.Zip
#else
namespace Bytewizer.TinyCLR.IO.Zip
#endif
{
	/// <summary>
	/// This class contains constants used for zip.
	/// </summary>
	public sealed class ZipConstants
	{
		/* The local file header */
		public const int LOCHDR = 30;
		public const int LOCSIG = 'P' | ('K' << 8) | (3 << 16) | (4 << 24);
		
		public const int LOCVER =  4;
		public const int LOCFLG =  6;
		public const int LOCHOW =  8;
		public const int LOCTIM = 10;
		public const int LOCCRC = 14;
		public const int LOCSIZ = 18;
		public const int LOCLEN = 22;
		public const int LOCNAM = 26;
		public const int LOCEXT = 28;
		
		public const int SPANNINGSIG = 'P' | ('K' << 8) | (7 << 16) | (8 << 24);
		public const int SPANTEMPSIG = 'P' | ('K' << 8) | ('0' << 16) | ('0' << 24);
		
		/* The Data descriptor */
		public const int EXTSIG = 'P' | ('K' << 8) | (7 << 16) | (8 << 24);
		public const int EXTHDR = 16;
		
		public const int EXTCRC =  4;
		public const int EXTSIZ =  8;
		public const int EXTLEN = 12;
		
		/* The central directory file header */
		public const int CENSIG = 'P' | ('K' << 8) | (1 << 16) | (2 << 24);
		
		/* The central directory file header for 64bit ZIP*/
		public const int CENSIG64 = 'P' | ('K' << 8) | (6 << 16) | (6 << 24);
		
		public const int CENHDR = 46;
		
		public const int CENVEM =  4;
		public const int CENVER =  6;
		public const int CENFLG =  8;
		public const int CENHOW = 10;
		public const int CENTIM = 12;
		public const int CENCRC = 16;
		public const int CENSIZ = 20;
		public const int CENLEN = 24;
		public const int CENNAM = 28;
		public const int CENEXT = 30;
		public const int CENCOM = 32;
		public const int CENDSK = 34;
		public const int CENATT = 36;
		public const int CENATX = 38;
		public const int CENOFF = 42;
		
		/* The entries in the end of central directory */
		public const int ENDSIG = 'P' | ('K' << 8) | (5 << 16) | (6 << 24);
		public const int ENDHDR = 22;
		
		public const int HDRDIGITALSIG = 'P' | ('K' << 8) | (5 << 16) | (5 << 24);
		public const int CENDIGITALSIG = 'P' | ('K' << 8) | (5 << 16) | (5 << 24);
		
		/* The following two fields are missing in SUN JDK */
		public const int ENDNRD =  4;
		public const int ENDDCD =  6;
		
		public const int ENDSUB =  8;
		public const int ENDTOT = 10;
		public const int ENDSIZ = 12;
		public const int ENDOFF = 16;
		public const int ENDCOM = 20;

		// 0 gives default code page, set it to whatever you like or alternatively alter it via property at runtime for more flexibility
		// Some care for compatability purposes is required as you can specify unicode code pages here.... if this way of working seems ok
		// then some protection may be added to make the interface a bit more robust perhaps.
		static int defaultCodePage = 0;  
		
		public static int DefaultCodePage {
			get {
				return defaultCodePage; 
			}
			set {
				defaultCodePage = value; 
			}
		}
		
		public static string ConvertToString(byte[] data)
		{
			return Encoding.UTF8.GetString(data, 0, data.Length);
		}
		
		public static byte[] ConvertToArray(string str)
		{
			return Encoding.UTF8.GetBytes(str);
		}
	}
}
