using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class GateInitialize
    {
        public const short ID = 20288;
        public GateInitialize(EndianBinaryReader param1) => Read(param1);
        public int FactionId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        bool bool1, bool2, bool3, bool4;
        private void Read(EndianBinaryReader param1)
        {
            bool1 = param1.ReadBoolean();
            FactionId = param1.ReadInt32();
            FactionId = (int)((uint)FactionId << 9 | (uint)FactionId >> 23);
            bool2 = param1.ReadBoolean();
            int something = param1.ReadInt32();
            something = (int)((uint)something << 10 | (uint)something >> 22);
            int something2 = param1.ReadInt32();
            something2 = (int)((uint)something2 >> 15 | (uint)something2 << 17);
            X = param1.ReadInt32();
            X = (int)((uint)X << 12 | (uint)X >> 20);
            Y = param1.ReadInt32();
            Y = (int)((uint)Y >> 4 | (uint)Y << 28);

            //print all
            Console.WriteLine("bool1 " + bool1);
            Console.WriteLine("factionID: " + FactionId);
            Console.WriteLine("something: " + something);
            Console.WriteLine("something2: " + something2);
            Console.WriteLine("X: " + X);
            Console.WriteLine("Y: " + Y);

        }
    }
}
