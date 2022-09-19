using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read.Interfaces
{
   
    public abstract class BoxInterface
    {
        private const short ID = 20331;
        public string Hash { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public BoxInterface(EndianBinaryReader param1)
        {
            
        }
        
        protected void Read(EndianBinaryReader param1)
        {
            Hash = param1.ReadString();
            Y = param1.ReadInt32();
            Y = (int)((uint)Y << 9 | (uint)Y >> 23);
            X = param1.ReadInt32();
            X = (int)((uint)X << 4 | (uint)X >> 28);
        }
    }
    
}
