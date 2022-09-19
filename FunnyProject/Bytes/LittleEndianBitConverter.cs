using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton_Core.Packets.Bytes
{
    public sealed class LittleEndianBitConverter : EndianBitConverter
    {
       
        public sealed override Endianness Endianness => Endianness.LittleEndian;

        public sealed override bool IsLittleEndian()
        {
            return true;
        }

        protected override void CopyBytesImpl(long value, int bytes, byte[] buffer, int index)
        {
            for (int i = 0; i < bytes; i++)
            {
                buffer[i + index] = (byte)(value & 0xFF);
                value >>= 8;
            }
        }

        protected override long FromBytes(byte[] buffer, int startIndex, int bytesToConvert)
        {
            long num = 0L;
            for (int i = 0; i < bytesToConvert; i++)
            {
                num = ((num << 8) | buffer[startIndex + bytesToConvert - 1 - i]);
            }

            return num;
        }
    }
}
