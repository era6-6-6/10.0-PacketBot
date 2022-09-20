using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class PlayerInit
    {
        public const short ID = 7270;
        public PlayerInit(EndianBinaryReader param1) => Read(param1);

        public int var359, FactionId, name10, name42, name5, var176, name2, var1216, X, Y;
        public bool var1554, IsNpc, var2826, Cloacked;
        public string name19, name7;
        public string NpcName { get; set; }
        public int PlayerID { get; set; }
        public short Type { get; set; }
        private void Read(EndianBinaryReader param1)
        {
           
            NpcName = param1.ReadString();
            var359 = param1.ReadInt32();
            var359 = (int)((uint)var359 << 13 | (uint)var359 >> 19);
            var1554 = param1.ReadBoolean();
            FactionId = param1.ReadInt32();
            FactionId = (int)((uint)FactionId << 7 | (uint)FactionId >> 25);
            name10 = param1.ReadInt32();
            name10 = (int)((uint)name10 >> 6 | (uint)name10 << 26);
            name19 = param1.ReadString();
            name42 = param1.ReadInt32();
            name42 = (int)((uint)name42 << 4 | (uint)name42 >> 28);
            IsNpc = param1.ReadBoolean();
            name5 = param1.ReadInt32();
            name5 = (int)((uint)name5 >> 3 | (uint)name5 << 29);
            param1.ReadInt16();
            Type = param1.ReadInt16();
            var2826 = param1.ReadBoolean();
            var176 = param1.ReadInt32();
            var176 = (int)((uint)var176 << 16 | (uint)var176 >> 16);
            name7 = param1.ReadString();
            var loc3 = param1.ReadInt32();
            for (int i = 0; i < loc3; i++)
            {
                param1.ReadInt16();
                var name2 = param1.ReadInt32();
                name2 = (int)((uint)name2 >> 11 | (uint)name2 << 21);
                var count = param1.ReadInt32();
                count = (int)((uint)count << 15 | (uint)count >> 17);
                var var1252 = param1.ReadString();
                var activated = param1.ReadBoolean();
                var atributte = param1.ReadInt32();
                atributte = (int)((uint)atributte << 3 | (uint)atributte >> 29);
                var var50 = param1.ReadInt16();
                param1.ReadInt16();
            }
            this.Cloacked = param1.ReadBoolean();
            name2 = param1.ReadInt32();
            PlayerID = (int)((uint)name2 << 14 | (uint)name2 >> 18);
            var1216 = param1.ReadInt32();
            var1216 = (int)((uint)var1216 >> 3 | (uint)var1216 << 29);
            X = param1.ReadInt32();
            X = (int)((uint)X >> 4 | (uint)X << 28);
            param1.ReadInt16();
            param1.ReadInt16();
            param1.ReadInt16();
            Y = param1.ReadInt32();
            Y = (int)((uint)Y >> 9 | (uint)Y << 23);

            //print all
            //Console.WriteLine("NpcName: " + NpcName);
            //Console.WriteLine("var359: " + var359);
            //Console.WriteLine("var1554: " + var1554);
            //Console.WriteLine("FactionId: " + FactionId);
            //Console.WriteLine("name10: " + name10);
            //Console.WriteLine("name19: " + name19);
            //Console.WriteLine("name42: " + name42);
            //Console.WriteLine("IsNpc: " + IsNpc);
            //Console.WriteLine("name5: " + name5);
            //Console.WriteLine("Type: " + Type);
            //Console.WriteLine("var 2826: " + var2826);
            //Console.WriteLine("var 176: " + var176);
            //Console.WriteLine("name7: " + name7);
            //Console.WriteLine("cloacked: " + Cloacked);
            //Console.WriteLine("name2: " + name2);
            //Console.WriteLine("var1216: " + var1216);
            //Console.WriteLine("X: " + X);
            //Console.WriteLine("Y: " + Y);



        }
    }
}
