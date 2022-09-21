using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class HpUpdate
    {
        public const short ID = 15997;
        public HpUpdate(EndianBinaryReader read) => Read(read);
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        
        public void Read(EndianBinaryReader param1)
        {
            /*
             *  this.name_24 = param1.readInt();
         this.name_24 = this.name_24 << 3 | this.name_24 >>> 29;
         this.name_15 = param1.readInt();
         this.name_15 = this.name_15 >>> 6 | this.name_15 << 26;
         this.var_90 = param1.readInt();
         this.var_90 = this.var_90 << 8 | this.var_90 >>> 24;
         this.var_280 = param1.readInt();
         this.var_280 = this.var_280 >>> 6 | this.var_280 << 26;
              */

            var name24 = param1.ReadInt32();
            Hp = (int)((uint)name24 << 3 | (uint)name24 >> 29);
            var name15 = param1.ReadInt32();
            MaxHp = (int)((uint)name15 >> 6 | (uint)name15 << 26);
            var var90 = param1.ReadInt32();
            var90 = (int)((uint)var90 << 8 | (uint)var90 >> 24);
            var var280 = param1.ReadInt32();
            var280 = (int)((uint)var280 >> 6 | (uint)var280 << 26);

            //print
            //Console.WriteLine("name24: " + name24);
            //Console.WriteLine("name15: " + name15);
            //Console.WriteLine("var90: " + var90);
            //Console.WriteLine("var280: " + var280);
            


        }
    }
}
