using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class ShipInfoUpdate
    {
        public const short ID = 3758;

        public ShipInfoUpdate(EndianBinaryReader read) => Read(read);


        private void Read(EndianBinaryReader param1)
        {
            var var1201 = param1.ReadInt32();
            var1201 = (int)((uint)var1201 >> 2 | (uint)var1201 << 30);
            var name25 = param1.ReadInt32();
            name25 = (int)((uint)name25 << 13 | (uint)name25 >> 19);
            var var3975 = param1.ReadBoolean();
            param1.ReadInt16();
            var effect = param1.ReadInt16();
            param1.ReadInt16();
            var var393 = param1.ReadInt32();
            var393 = (int)((uint)var393 >> 15 | (uint)var393 << 17);
            var damage = param1.ReadInt32();
            damage = (int)((uint)damage << 2 | (uint)damage >> 30);
            var var1307 = param1.ReadInt32();
            var1307 = (int)((uint)var1307 << 15 | (uint)var1307 >> 17);
            var var1275 = param1.ReadInt32();
            var1275 = (int)((uint)var1275 >> 9 | (uint)var1275 << 23);

            //print all
            Console.WriteLine("var1201: " + var1201);
            Console.WriteLine("name25: " + name25);
            Console.WriteLine("var3975: "+ var3975);
            Console.WriteLine("effect: " + effect);
            Console.WriteLine("damage: " + damage);
            Console.WriteLine("var1307: " + var1307);
            Console.WriteLine("var1275: " + var1275);


        }
    }
}
