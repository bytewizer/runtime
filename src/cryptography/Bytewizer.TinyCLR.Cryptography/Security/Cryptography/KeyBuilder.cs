using System;

namespace Bytewizer.TinyCLR.Security.Cryptography
{
	static class KeyBuilder
	{
		static public byte[] Key(int size)
		{
			Random rnd = new Random();

			byte[] buffer = new byte[size];
			rnd.NextBytes(buffer);
			
			return buffer;
		}

		static public byte[] IV(int size)
		{
			Random rnd = new Random();

			byte[] buffer = new byte[size];
			rnd.NextBytes(buffer);

			return buffer;
		}
	}
}