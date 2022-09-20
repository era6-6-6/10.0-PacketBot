using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class PlayerMoved
    {
        public const short ID = 29819;
        public PlayerMoved(EndianBinaryReader read) => Read(read);
        public int UserID { get; set; }
        public int ToX { get; set; }
        public int ToY { get; set; }
        public int Duration{ get; set; }

        private void Read(EndianBinaryReader param1)
        {
            param1.ReadInt16();
            ToY = param1.ReadInt32();
            ToY = (int)((uint)ToY << 13 | (uint)ToY >> 19);
            UserID = param1.ReadInt32();
            UserID = (int)((uint)UserID << 12 | (uint)UserID >> 20);
            ToX = param1.ReadInt32();
            ToX = (int)((uint)ToX << 4 | (uint)ToX >> 28);
            Duration = param1.ReadInt32();
            Duration = (int)((uint)Duration << 13 | (uint)Duration >> 19);
        }
       
    }
}
