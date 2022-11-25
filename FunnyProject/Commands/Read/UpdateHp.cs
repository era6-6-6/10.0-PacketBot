using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class UpdateHp
    {
        public const short ID = 28127;

        public int UserID;
        public int maxHp;
        public int Hp;

        public UpdateHp(EndianBinaryReader param1) => Read(param1);


        private void Read(EndianBinaryReader param1)
        {
            param1.ReadBoolean();
            var uk = param1.ReadInt32();
            uk = (int)((uint)uk << 14 | (uint)uk >> 18);
            Console.WriteLine("uk:" + uk);
            var uk2 = param1.ReadInt32();
            uk2 = (int)((uint)uk2 >> 10 | (uint)uk2 << 22);
            Console.WriteLine("uk2: " + uk2);
            var uk3 = param1.ReadInt32();
            uk3 = (int)((uint)uk3 <<  10 | (uint)uk3 >> 22);
            param1.ReadBoolean();

        }


    }
}
