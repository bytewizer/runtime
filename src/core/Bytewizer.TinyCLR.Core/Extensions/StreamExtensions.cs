﻿using System;
using System.IO;

#if NanoCLR
namespace Bytewizer.NanoCLR
#else
namespace Bytewizer.TinyCLR
#endif
{
    /// <summary>
    /// Contains extension methods for <see cref="Stream"/> and <see cref="MemoryStream"/>.
    /// </summary>
    public static class StreamExtensions
    {

#if !NanoCLR

    /// <summary>
    /// Reads the bytes from the current stream and writes them to another stream.
    /// </summary>
    /// <param name="source">The source <see cref="MemoryStream"/> to read from.</param>
    /// <param name="destination">The <see cref="Stream"/> to which the contents of the current stream will be copied.</param>
    public static void CopyTo(this MemoryStream source, Stream destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            destination.Write(source.GetBuffer(), (int)source.Position, (int)(source.Length - source.Position));
        }

        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream.
        /// </summary>
        /// <param name="source">The source <see cref="Stream"/> to read from.</param>
        /// <param name="destination">The <see cref="MemoryStream"/> to which the contents of the current stream will be copied.</param>
        public static void CopyTo(this Stream source, MemoryStream destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (source.CanSeek)
            {
                int position = (int)destination.Position;
                int length = (int)(source.Length - source.Position) + position;
                destination.SetLength(length);

                while (position < length)
                {
                    position += source.Read(destination.GetBuffer(), position, length - position);
                }
            }
            else
            {
                source.CopyTo((Stream)destination);
            }
        }

#endif


        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream. The default buffer size is 8192.
        /// </summary>
        /// <param name="source">The source <see cref="Stream"/> to read from.</param>
        /// <param name="destination">The <see cref="Stream"/> to which the contents of the current stream will be copied.</param>
        public static void CopyTo(this Stream source, Stream destination)
        {
            CopyTo(source, destination, 8192);
        }

        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream.
        /// </summary>
        /// <param name="source">The source <see cref="Stream"/> to read from.</param>
        /// <param name="destination">The <see cref="Stream"/> to which the contents of the current stream will be copied.</param>
        /// <param name="bufferSize">The size of the buffer. This value must be greater than zero.</param>
        public static void CopyTo(this Stream source, Stream destination, int bufferSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            int size = (source.CanSeek) ? Math.Min((int)(source.Length - source.Position), bufferSize) : bufferSize;

            var buffer = new byte[size];

            int read;
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                destination.Write(buffer, 0, read);
            }
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="source">The source <see cref="Stream"/> to read from.</param>
        /// <param name="buffer">An array of bytes.</param>
        public static void Write(this Stream source, byte[] buffer)
        {
            source.Write(buffer, 0, buffer.Length);
        }
    }
}