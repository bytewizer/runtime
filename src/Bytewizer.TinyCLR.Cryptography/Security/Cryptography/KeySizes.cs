// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Bytewizer.TinyCLR.Security.Cryptography {
	

	public sealed class KeySizes {
		private int _maxSize;
		private int _minSize;
		private int _skipSize;

		public KeySizes (int minSize, int maxSize, int skipSize) 
		{
			_maxSize = maxSize;
			_minSize = minSize;
			_skipSize = skipSize;
		}
		
		public int MaxSize {
			get { return _maxSize; }
		}
		
		public int MinSize {
			get { return _minSize; }
		}
		
		public int SkipSize {
			get { return _skipSize; }
		}
	
		internal bool IsLegal (int keySize) 
		{
			int ks = keySize - MinSize;
			bool result = ((ks >= 0) && (keySize <= MaxSize));
			return ((SkipSize == 0) ? result : (result && (ks % SkipSize == 0)));
		}

		internal static bool IsLegalKeySize (KeySizes[] legalKeys, int size) 
		{
			foreach (KeySizes legalKeySize in legalKeys) {
				if (legalKeySize.IsLegal (size)) 
					return true;
			}
			return false;
		}
	}
}