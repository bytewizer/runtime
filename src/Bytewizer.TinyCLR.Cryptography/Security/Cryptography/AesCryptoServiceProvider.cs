// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Bytewizer.TinyCLR.Security.Cryptography 
{
	public sealed class AesCryptoServiceProvider : Aes {
		
		public AesCryptoServiceProvider ()
		{
			FeedbackSizeValue = 8;
		}
		
		public override void GenerateIV ()
		{
			IVValue = KeyBuilder.IV (BlockSizeValue >> 3);
		}
		
		public override void GenerateKey ()
		{
			KeyValue = KeyBuilder.Key (KeySizeValue >> 3);
		}
		
		public override ICryptoTransform CreateDecryptor (byte[] key, byte[] iv) 
		{
			if ((Mode == CipherMode.CFB) && (FeedbackSize > 64))
				throw new Exception ("CFB with Feedbaack > 64 bits");
			return new AesTransform (this, false, key, iv);
		}
		
		public override ICryptoTransform CreateEncryptor (byte[] key, byte[] iv) 
		{
			if ((Mode == CipherMode.CFB) && (FeedbackSize > 64))
				throw new Exception ("CFB with Feedbaack > 64 bits");
			return new AesTransform (this, true, key, iv);
		}

		// I suppose some attributes differs ?!? because this does not look required

		public override byte[] IV {
			get { return base.IV; }
			set { base.IV = value; }
		}

		public override byte[] Key {
			get { return base.Key; }
			set { base.Key = value; }
		}

		public override int KeySize {
			get { return base.KeySize; }
			set { base.KeySize = value; }
		}

		public override int FeedbackSize {
			get { return base.FeedbackSize; }
			set { base.FeedbackSize = value; }
		}

		public override CipherMode Mode {
			get { return base.Mode; }
			set {
				switch (value) {
				case CipherMode.CTS:
					throw new Exception ("CTS is not supported");
				default:
					base.Mode = value;
					break;
				}
			}
		}

		public override PaddingMode Padding {
			get { return base.Padding; }
			set { base.Padding = value; }
		}

		public override ICryptoTransform CreateDecryptor () 
		{
			return CreateDecryptor (Key, IV);
		}

		public override ICryptoTransform CreateEncryptor() 
		{
			return CreateEncryptor (Key, IV);
		}

		protected override void Dispose (bool disposing) 
		{
			base.Dispose (disposing);
		}
	}
}
