using System.Text;


namespace Krypton_Core.Packets.Bytes
{
    public class ByteArray
    {
        public List<byte> Message;
        public bool NROL;

        public ByteArray(short ID, bool NeedReverseOrLength = true)
        {
            Message = new List<byte>();
            NROL = NeedReverseOrLength;
            writeShort(ID);
        }

        public ByteArray(bool NeedReverseOrLenght = false)
        {
            Message = new List<byte>();
            NROL = NeedReverseOrLenght;
        }

        public void setNROL(bool to)
        {
            NROL = to;
        }

        public void writeInt(int Int32)
        {
            write(BitConverter.GetBytes(Int32), true);
        }
        public void writeUint(uint Uint32)
        {
            write(BitConverter.GetBytes(Uint32), true);
        }


        public void writeShort(short Short)
        {
            write(BitConverter.GetBytes(Short), true);
        }

        public void writeDouble(double num)
        {
            write(BitConverter.GetBytes(num), true);
        }

        public void writeLong(long num)
        {
            write(BitConverter.GetBytes(num));
        }

        public void writeFloat(float num)
        {
            write(BitConverter.GetBytes(num), true);
        }
        public void writeByte(byte b)
        {
            Message.Add(b);
        }

        public void writeUTF(string String)
        {
            if (String == null)
                String = "";

            writeShort((short)String.Length);
            write(Encoding.UTF8.GetBytes(String) , false);
        }
        public void writeUTF1(string String)
        {
            if (String == null)
                String = "";

            //writeShort((short)Encoding.UTF8.GetByteCount(String));
            write(Encoding.UTF8.GetBytes(String));
        }

        public void writeBoolean(bool Bool)
        {
            write(new[] { Bool ? (byte)1 : (byte)0 });
        }

        public void write(byte[] Bytes, bool IsInt = false)
        {
            if (IsInt)
                for (var i = Bytes.Length - 1; i > -1; i--)
                    Message.Add(Bytes[i]);
            else
                Message.AddRange(Bytes);
        }

        public byte[] ToByteArray()
        {
            var NewMsg = new List<byte>();
            NewMsg.AddRange(BitConverter.GetBytes((short)Message.Count));
            NewMsg.Reverse();
            NewMsg.AddRange(Message);

            return NewMsg.ToArray();
        }
    }

    public class ByteParser
    {
        public int Buffer;

        public ByteParser(byte[] bytes)
        {
            List<byte> bt = bytes.ToList();
            bt.RemoveAt(0);
            Array = bt.ToArray();
            
            

        }

        public byte[] Array { get; set; }
        public short ID { get; set; }

        public int read()
        {
            var internalCounter = Buffer;
            return internalCounter++ < Array.Length ? Array[Buffer++] : 0;
        }

        

        public short readShort()
        {
            return (short)((read() << 8) | (read() & 0xff));
        }

        public int readInt()
        {
            return ((read() & 0xff) << 24) | ((read() & 0xff) << 16) | ((read() & 0xff) << 8) | (read() & 0xff);
        }

        public long readLong()
        {
            return ((long)(read() & 0xff) << 56) | ((long)(read() & 0xff) << 48) | ((long)(read() & 0xff) << 40) |
                   ((long)(read() & 0xff) << 32) | ((long)(read() & 0xff) << 24) | ((long)(read() & 0xff) << 16) |
                   ((long)(read() & 0xff) << 8) | (read() & 0xff);
        }

        public double readDouble()
        {
            return BitConverter.Int64BitsToDouble(readLong());
        }

        public double readFloat()
        {
            return BitConverter.ToSingle(new[] { (byte)read(), (byte)read(), (byte)read(), (byte)read() }, 0);
        }

        public string readUTF()
        {
            try
            {
                var stringLength = readShort();
                var value = Encoding.UTF8.GetString(Array, Buffer, stringLength);
                Buffer += stringLength;
                return value;
            }
            catch
            {
                return "";
            }
        }

        public bool readBoolean()
        {
            return read() == 1;
        }

        internal bool ReadBoolean()
        {
            throw new NotImplementedException();
        }
    }
}
