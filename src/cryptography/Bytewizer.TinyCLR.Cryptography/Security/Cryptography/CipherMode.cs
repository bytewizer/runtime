// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Bytewizer.TinyCLR.Security.Cryptography {

	public enum CipherMode {
		CBC = 0x1, // Cipher Block Chaining
		ECB, // Electronic Codebook
		OFB, // Output Feedback
		CFB, // Cipher Feedback
		CTS, // Cipher Text Stealing
	}
}