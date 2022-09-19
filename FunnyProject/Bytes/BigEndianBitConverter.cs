namespace Krypton_Core.Packets.Bytes
{
    public sealed class BigEndianBitConverter : EndianBitConverter
    {
        public sealed override Endianness Endianness => Endianness.BigEndian;

        public sealed override bool IsLittleEndian()
        {
            return false;
        }

        protected override void CopyBytesImpl(long value, int bytes, byte[] buffer, int index)
        {
            int num = index + bytes - 1;
            for (int i = 0; i < bytes; i++)
            {
                buffer[num - i] = (byte)(value & 0xFF);
                value >>= 8;
            }
        }
       

        protected override long FromBytes(byte[] buffer, int startIndex, int bytesToConvert)
        {
            long num = 0L;
            for (int i = 0; i < bytesToConvert; i++)
            {
                num = ((num << 8) | buffer[startIndex + i]);
            }

            return num;
        }
    }
}
