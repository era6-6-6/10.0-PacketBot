using System.Text;

namespace Krypton_Core.Packets.Bytes
{
    public class EndianBinaryReader : IDisposable
    {
        private bool disposed;

        private Decoder decoder;

        private byte[] buffer = new byte[16];

        private char[] charBuffer = new char[1];

        private int minBytesPerChar;

        private EndianBitConverter bitConverter;

        private Encoding encoding;

        private Stream stream;

        public EndianBitConverter BitConverter => bitConverter;

        public Encoding Encoding => encoding;

        public Stream BaseStream => stream;

        public EndianBinaryReader(EndianBitConverter bitConverter, Stream stream)
            : this(bitConverter, stream, Encoding.UTF8)
        {
        }

        public EndianBinaryReader(EndianBitConverter bitConverter, Stream stream, Encoding encoding)
        {
            if (bitConverter == null)
            {
                throw new ArgumentNullException("bitConverter");
            }

            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            if (!stream.CanRead)
            {
                throw new ArgumentException("Stream isn't writable", "stream");
            }

            this.stream = stream;
            this.bitConverter = bitConverter;
            this.encoding = encoding;
            decoder = encoding.GetDecoder();
            minBytesPerChar = 1;
            if (encoding is UnicodeEncoding)
            {
                minBytesPerChar = 2;
            }
        }

        public void Close()
        {
            Dispose();
        }

        public void Seek(int offset, SeekOrigin origin)
        {
            CheckDisposed();
            stream.Seek(offset, origin);
        }

        public byte ReadByte()
        {
            ReadInternal(buffer, 1);
            return buffer[0];
        }

        public sbyte ReadSByte()
        {
            ReadInternal(buffer, 1);
            return (sbyte)buffer[0];
        }

        public bool ReadBoolean()
        {
            ReadInternal(buffer, 1);
            return bitConverter.ToBoolean(buffer, 0);
        }

        /// <summary>
        /// Retrieve short
        /// </summary>
        /// <returns></returns>
        public short ReadInt16()
        {
            ReadInternal(buffer, 2);
            return bitConverter.ToInt16(buffer, 0);
        }

        /// <summary>
        /// Retrieve int
        /// </summary>
        /// <returns></returns>
        public int ReadInt32()
        {
            ReadInternal(buffer, 4);
            return bitConverter.ToInt32(buffer, 0);
        }

        public long ReadInt64()
        {
            ReadInternal(buffer, 8);
            return bitConverter.ToInt64(buffer, 0);
        }

        public ushort ReadUInt16()
        {
            ReadInternal(buffer, 2);
            return bitConverter.ToUInt16(buffer, 0);
        }

        public uint ReadUInt32()
        {
            ReadInternal(buffer, 4);
            return bitConverter.ToUInt32(buffer, 0);
        }

        public ulong ReadUInt64()
        {
            ReadInternal(buffer, 8);
            return bitConverter.ToUInt64(buffer, 0);
        }

        /// <summary>
        /// Retrieve Float
        /// </summary>
        /// <returns></returns>
        public float ReadSingle()
        {
            ReadInternal(buffer, 4);
            return bitConverter.ToSingle(buffer, 0);
        }

        public double ReadDouble()
        {
            ReadInternal(buffer, 8);
            return bitConverter.ToDouble(buffer, 0);
        }

        public decimal ReadDecimal()
        {
            ReadInternal(buffer, 16);
            return bitConverter.ToDecimal(buffer, 0);
        }

        public int Read()
        {
            if (Read(charBuffer, 0, 1) == 0)
            {
                return -1;
            }

            return charBuffer[0];
        }

        public int Read(char[] data, int index, int count)
        {
            CheckDisposed();
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (count + index > data.Length)
            {
                throw new ArgumentException("Not enough space in buffer for specified number of characters starting at specified index");
            }

            int num = 0;
            bool flag = true;
            byte[] array = buffer;
            if (array.Length < count * minBytesPerChar)
            {
                array = new byte[4096];
            }

            while (num < count)
            {
                int num2;
                if (flag)
                {
                    num2 = count * minBytesPerChar;
                    flag = false;
                }
                else
                {
                    num2 = (count - num - 1) * minBytesPerChar + 1;
                }

                if (num2 > array.Length)
                {
                    num2 = array.Length;
                }

                int num3 = TryReadInternal(array, num2);
                if (num3 == 0)
                {
                    return num;
                }

                int chars = decoder.GetChars(array, 0, num3, data, index);
                num += chars;
                index += chars;
            }

            return num;
        }

        public int Read(byte[] buffer, int index, int count)
        {
            CheckDisposed();
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (count + index > buffer.Length)
            {
                throw new ArgumentException("Not enough space in buffer for specified number of bytes starting at specified index");
            }

            int num = 0;
            while (count > 0)
            {
                var num2 = stream.Read(buffer, index, count);
                
                if (num2 == 0)
                {
                    return num;
                }

                index += num2;
                num += num2;
                count -= num2;
            }

            return num;
        }

        public byte[] ReadBytes(int count)
        {
            CheckDisposed();
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            byte[] array = new byte[count];
            int num;
            for (int i = 0; i < count; i += num)
            {
                num = stream.Read(array, i, count - i );
                if (num == 0)
                {
                    byte[] array2 = new byte[i];
                    Buffer.BlockCopy(array, 0, array2, 0, i);
                    return array2;
                }
            }
            

            return array;
        }
        private void AsyncResult(IAsyncResult result)
        {

        }

        public byte[] ReadBytesOrThrow(int count)
        {
            byte[] array = new byte[count];
            ReadInternal(array, count);
            return array;
        }

        public int Read7BitEncodedInt()
        {
            CheckDisposed();
            int num = 0;
            for (int i = 0; i < 35; i += 7)
            {
                int num2 = stream.ReadByte();
                if (num2 == -1)
                {
                    throw new EndOfStreamException();
                }

                num |= (num2 & 0x7F) << i;
                if ((num2 & 0x80) == 0)
                {
                    return num;
                }
            }

            throw new IOException("Invalid 7-bit encoded integer in stream.");
        }

        public int ReadBigEndian7BitEncodedInt()
        {
            CheckDisposed();
            int num = 0;
            for (int i = 0; i < 5; i++)
            {
                int num2 = stream.ReadByte();
                if (num2 == -1)
                {
                    throw new EndOfStreamException();
                }

                num = ((num << 7) | (num2 & 0x7F));
                if ((num2 & 0x80) == 0)
                {
                    return num;
                }
            }

            throw new IOException("Invalid 7-bit encoded integer in stream.");
        }

        public string ReadString()
        {
            int num = ReadUInt16();
            byte[] array = new byte[num];
            ReadInternal(array, num);
            return Encoding.UTF8.GetString(array, 0, array.Length);
        }

        private void CheckDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException("EndianBinaryReader");
            }
        }

        private void ReadInternal(byte[] data, int size)
        {
            try
            {
                CheckDisposed();
                int num;
                for (int i = 0; i < size; i += num)
                {
                    num = stream.Read(data, i, size - i);

                    if (num == 0)
                    {
                        //throw new EndOfStreamException(string.Format("End of stream reached with {0} byte{1} left to read.", size - i, (size - i == 1) ? "s" : ""));
                        return;
                    }
                }
            }
            catch
            { 
            }
        }


        private int TryReadInternal(byte[] data, int size)
        {
            CheckDisposed();
            int i;
            int num;
            for (i = 0; i < size; i += num)
            {
                num = stream.Read(data, i, size - i);
                if (num == 0)
                {
                    return i;
                }
            }

            return i;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                ((IDisposable)stream).Dispose();
            }
        }
    }
}
