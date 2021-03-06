// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NanoCLR
namespace Bytewizer.NanoCLR.IO.Compression
#else
namespace Bytewizer.TinyCLR.IO.Compression
#endif
{
    /// <summary>
    /// This class stores the pending output of the Deflater.
    /// 
    /// author of the original java version : Jochen Hoenicke
    /// </summary>
    public class DeflaterPending : PendingBuffer
    {
        /// <summary>
        /// Construct instance with default buffer size
        /// </summary>
        public DeflaterPending() 
            : base(DeflaterConstants.PENDING_BUF_SIZE)
        {
        }
    }
}
