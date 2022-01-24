#if NanoCLR
namespace Bytewizer.NanoCLR.IO.GZip
#else
namespace Bytewizer.TinyCLR.IO.GZip
#endif
{
	/// <summary>
	/// This class contains constants used for gzip.
	/// </summary>
	public class GZipConstants 
	{
		/// <summary>
		/// Magic number found at start of GZIP header
		/// </summary>
		public static readonly int GZIP_MAGIC = 0x1F8B;
		
		/*  The flag byte is divided into individual bits as follows:
			
			bit 0   FTEXT
			bit 1   FHCRC
			bit 2   FEXTRA
			bit 3   FNAME
			bit 4   FCOMMENT
			bit 5   reserved
			bit 6   reserved
			bit 7   reserved
		 */

		public const int FTEXT    = 0x1;
		public const int FHCRC    = 0x2;
		public const int FEXTRA   = 0x4;
		public const int FNAME    = 0x8;
		public const int FCOMMENT = 0x10;
	}
}
