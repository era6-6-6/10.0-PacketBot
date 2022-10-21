using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class BaseInit
    {

        public BaseInit(EndianBinaryReader read) => Read(read);

        private void Read(EndianBinaryReader reader)
        {
            var uk1 = reader.ReadInt32();
            uk1 = (int)((uint)uk1 << 10 | (uint)uk1 >> 22);
            var uk2 = reader.ReadInt32();
            uk2 = (int)((uint)uk2 << 1 | (uint)uk2 >> 31);
            Console.WriteLine("uk1: " + uk1);
            Console.WriteLine("uk2: " + uk2);
            var name = reader.ReadString();
            Console.WriteLine("name: " + name);
            var loc3 = reader.ReadInt32();
            for (int i = 0; i < loc3; i++)
            {

            }
        }
    }
}
