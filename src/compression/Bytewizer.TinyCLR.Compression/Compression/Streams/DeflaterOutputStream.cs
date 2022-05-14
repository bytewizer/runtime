// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;

#if NanoCLR
using Bytewizer.NanoCLR.Checksums;

namespace Bytewizer.NanoCLR.IO.Compression.Streams
#else
using Bytewizer.TinyCLR.Checksums;

namespace Bytewizer.TinyCLR.IO.Compression.Streams
#endif
{

    /// <summary>
    /// This is a special FilterOutputStream deflating the bytes that are
    /// written through it.  It uses the Deflater for deflating.
    /// </summary>
    public class DeflaterOutputStream : Stream
    {
        /// <summary>
        /// This buffer is used temporarily to retrieve the bytes from the
        /// deflater and write them to the underlying output stream.
        /// </summary>
        protected byte[] buf;

        /// <summary>
        /// The deflater which is used to deflate the stream.
        /// </summary>
        protected Deflater def;

        /// <summary>
        /// base stream the deflater depends on.
        /// </summary>
        protected Stream baseOutputStream;

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override bool CanRead
        {
            get
            {
                return baseOutputStream.CanRead;
            }
        }

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override bool CanSeek
        {
            get
            {
                return false;
                //				return baseOutputStream.CanSeek;
            }
        }

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return baseOutputStream.CanWrite;
            }
        }

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override long Length
        {
            get
            {
                return baseOutputStream.Length;
            }
        }

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override long Position
        {
            get
            {
                return baseOutputStream.Position;
            }
            set
            {
                baseOutputStream.Position = value;
            }
        }

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException("Seek not supported");
        }

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override void SetLength(long val)
        {
            baseOutputStream.SetLength(val);
        }

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override int ReadByte()
        {
            return baseOutputStream.ReadByte();
        }

        /// <summary>
        /// I needed to implement the abstract member.
        /// </summary>
        public override int Read(byte[] b, int off, int len)
        {
            return baseOutputStream.Read(b, off, len);
        }

#if NanoCLR
        public override int Read(SpanByte buffer)
        {
            throw new NotImplementedException();
        }
#endif

        /// <summary>
        /// Deflates everything in the def's input buffers.  This will call
        /// <code>def.deflate()</code> until all bytes from the input buffers
        /// are processed.
        /// </summary>
        protected void Deflate()
        {
            while (!def.IsNeedingInput)
            {
                int len = def.Deflate(buf, 0, buf.Length);

                //	System.err.println("DOS deflated " + len + " baseOutputStream of " + buf.length);
                if (len <= 0)
                {
                    break;
                }
                baseOutputStream.Write(buf, 0, len);
            }

            if (!def.IsNeedingInput)
            {
                throw new ApplicationException("Can't deflate all input?");
            }
        }

        /// <summary>
        /// Creates a new DeflaterOutputStream with a default Deflater and default buffer size.
        /// </summary>
        /// <param name="baseOutputStream">
        /// the output stream where deflated output should be written.
        /// </param>
        public DeflaterOutputStream(Stream baseOutputStream) : this(baseOutputStream, new Deflater(), 512)
        {
        }

        /// <summary>
        /// Creates a new DeflaterOutputStream with the given Deflater and
        /// default buffer size.
        /// </summary>
        /// <param name="baseOutputStream">
        /// the output stream where deflated output should be written.
        /// </param>
        /// <param name="defl">
        /// the underlying deflater.
        /// </param>
        public DeflaterOutputStream(Stream baseOutputStream, Deflater defl) : this(baseOutputStream, defl, 512)
        {
        }

        /// <summary>
        /// Creates a new DeflaterOutputStream with the given Deflater and
        /// buffer size.
        /// </summary>
        /// <param name="baseOutputStream">
        /// the output stream where deflated output should be written.
        /// </param>
        /// <param name="defl">
        /// the underlying deflater.
        /// </param>
        /// <param name="bufsize">
        /// the buffer size.
        /// </param>
        /// <exception cref="System.InvalidOperationException">
        /// if bufsize isn't positive.
        /// </exception>
        public DeflaterOutputStream(Stream baseOutputStream, Deflater defl, int bufsize)
        {
            this.baseOutputStream = baseOutputStream;
            if (bufsize <= 0)
            {
                throw new InvalidOperationException("bufsize <= 0");
            }
            buf = new byte[bufsize];
            def = defl;
        }

        /// <summary>
        /// Flushes the stream by calling flush() on the deflater and then
        /// on the underlying stream.  This ensures that all bytes are
        /// flushed.
        /// </summary>
        public override void Flush()
        {
            def.Flush();
            Deflate();
            baseOutputStream.Flush();
        }

        /// <summary>
        /// Finishes the stream by calling finish() on the deflater. 
        /// </summary>
        public virtual void Finish()
        {
            def.Finish();
            while (!def.IsFinished)
            {
                int len = def.Deflate(buf, 0, buf.Length);
                if (len <= 0)
                {
                    break;
                }

                // kidnthrain encryption alteration
                if (this.Password != null)
                {
                    // plain data has been deflated. Now encrypt result
                    this.EncryptBlock(buf, 0, len);
                }

                baseOutputStream.Write(buf, 0, len);
            }
            if (!def.IsFinished)
            {
                throw new ApplicationException("Can't deflate all input?");
            }
            baseOutputStream.Flush();
        }

        /// <summary>
        /// Calls finish () and closes the stream.
        /// </summary>
        public override void Close()
        {
            Finish();
            baseOutputStream.Close();
        }

        /// <summary>
        /// Writes a single byte to the compressed output stream.
        /// </summary>
        /// <param name="bval">
        /// the byte value.
        /// </param>
        public override void WriteByte(byte bval)
        {
            byte[] b = new byte[1];
            b[0] = (byte)bval;
            Write(b, 0, 1);
        }

        /// <summary>
        /// Writes a len bytes from an array to the compressed stream.
        /// </summary>
        /// <param name="buf">
        /// the byte array.
        /// </param>
        /// <param name="off">
        /// the offset into the byte array where to start.
        /// </param>
        /// <param name="len">
        /// the number of bytes to write.
        /// </param>
        public override void Write(byte[] buf, int off, int len)
        {
            //    System.err.println("DOS with off " + off + " and len " + len);
            def.SetInput(buf, off, len);
            Deflate();
        }

        #region Encryption

        string password = null;
        uint[] keys = null;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }


        //The beauty of xor-ing bits is that
        //plain ^ key = enc
        //and enc ^ key = plain
        //accordingly, this is the exact same as the decrypt byte
        //function in InflaterInputStream
        protected byte EncryptByte()
        {
            uint temp = ((keys[2] & 0xFFFF) | 2);
            return (byte)((temp * (temp ^ 1)) >> 8);
        }


        /// <summary>
        /// Takes a buffer of data and uses the keys
        /// that have been previously initialized from a
        /// password and then updated via a random encryption header
        /// to encrypt that data
        /// </summary>
        protected void EncryptBlock(byte[] buf, int off, int len)
        {
            for (int i = off; i < off + len; ++i)
            {
                byte oldbyte = buf[i];
                buf[i] ^= EncryptByte();
                UpdateKeys(oldbyte);
            }
        }

        /// <summary>
        /// Initializes our encryption keys using a given password
        /// </summary>
        protected void InitializePassword(string password)
        {
            keys = new uint[] {
                0x12345678,
                0x23456789,
                0x34567890
            };

            for (int i = 0; i < password.Length; ++i)
            {
                UpdateKeys((byte)password[i]);
            }
        }

        protected void UpdateKeys(byte ch)
        {
            keys[0] = Crc32.ComputeCrc32(keys[0], ch);
            keys[1] = keys[1] + (byte)keys[0];
            keys[1] = keys[1] * 134775813 + 1;
            keys[2] = Crc32.ComputeCrc32(keys[2], (byte)(keys[1] >> 24));
        }
        #endregion
    }
}
