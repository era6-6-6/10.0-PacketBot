using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class ShieldUpdate
    {
        public const short ID = 4550;

        public ShieldUpdate(EndianBinaryReader read) => Read(read);
        
        private void Read(EndianBinaryReader param1)
        {
            var shd = param1.ReadInt32();
            shd = (int)((uint)shd << 12 | (uint)shd >> 20);
            var maxShd = param1.ReadInt32();
            maxShd = (int)((uint)maxShd << 7 | (uint)maxShd >> 25);
            Console.WriteLine("shd: " + shd);
            Console.WriteLine("shd" + maxShd);
        }
    }
}
