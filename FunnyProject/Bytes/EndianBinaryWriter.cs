using System;
using System.Text;

namespace Krypton_Core.Packets.Bytes
{
	public class EndianBinaryWriter : IDisposable
	{
		private bool disposed;

		private byte[] buffer = new byte[16];

		private char[] charBuffer = new char[1];

		private EndianBitConverter bitConverter;

		private Encoding encoding;

		private Stream stream;

		public EndianBitConverter BitConverter => bitConverter;

		public Encoding Encoding => encoding;

		public Stream BaseStream => stream;

		public EndianBinaryWriter(EndianBitConverter bitConverter, Stream stream)
			: this(bitConverter, stream, Encoding.UTF8)
		{
		}

		public EndianBinaryWriter(EndianBitConverter bitConverter, Stream stream, Encoding encoding)
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
			if (!stream.CanWrite)
			{
				throw new ArgumentException("Stream isn't writable", "stream");
			}
			this.stream = stream;
			this.bitConverter = bitConverter;
			this.encoding = encoding;
		}

		public void Close()
		{
			Dispose();
		}

		public void Flush()
		{
			CheckDisposed();
			stream.Flush();
		}

		public void Seek(int offset, SeekOrigin origin)
		{
			CheckDisposed();
			stream.Seek(offset, origin);
		}

		public void Write(bool value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 1);
		}

		public void Write(short value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 2);
		}

		public void Write(int value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 4);
		}

		public void Write(long value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 8);
		}

		public void Write(ushort value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 2);
		}

		public void Write(uint value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 4);
		}

		public void Write(ulong value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 8);
		}

		public void Write(float value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 4);
		}

		public void Write(double value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 8);
		}

		public void Write(decimal value)
		{
			bitConverter.CopyBytes(value, buffer, 0);
			WriteInternal(buffer, 16);
		}

		public void Write(byte value)
		{
			buffer[0] = value;
			WriteInternal(buffer, 1);
		}

		public void Write(sbyte value)
		{
			buffer[0] = (byte)value;
			WriteInternal(buffer, 1);
		}

		public void Write(byte[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			WriteInternal(value, value.Length);
		}

		public void Write(byte[] value, int offset, int count)
		{
			CheckDisposed();
			stream.Write(value, offset, count);
		}

		public void Write(char value)
		{
			charBuffer[0] = value;
			Write(charBuffer);
		}

		public void Write(char[] value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			CheckDisposed();
			byte[] bytes = Encoding.GetBytes(value, 0, value.Length);
			WriteInternal(bytes, bytes.Length);
		}

		public void Write(string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			CheckDisposed();
			byte[] bytes = Encoding.GetBytes(value);
			Write7BitEncodedInt(bytes.Length);
			WriteInternal(bytes, bytes.Length);
		}

		public void Write7BitEncodedInt(int value)
		{
			CheckDisposed();
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value", "Value must be greater than or equal to 0.");
			}
			int num = 0;
			while (value >= 128)
			{
				buffer[num++] = (byte)(((uint)value & 0x7Fu) | 0x80u);
				value >>= 7;
				num++;
			}
			buffer[num++] = (byte)value;
			stream.Write(buffer, 0, num);
		}

		private void CheckDisposed()
		{
			if (disposed)
			{
				throw new ObjectDisposedException("EndianBinaryWriter");
			}
		}

		private void WriteInternal(byte[] bytes, int length)
		{
			CheckDisposed();
			stream.Write(bytes, 0, length);
		}

		public void Dispose()
		{
			if (!disposed)
			{
				Flush();
				disposed = true;
				((IDisposable)stream).Dispose();
			}
		}
	}

}

