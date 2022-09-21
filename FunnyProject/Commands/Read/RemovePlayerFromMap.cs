using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    //if is far away
    public class RemovePlayerFromMap
    {

        public const short ID = 19797;

        public RemovePlayerFromMap(EndianBinaryReader read) => Read(read);
        public int UserID { get; set; }
        private void Read(EndianBinaryReader param1)
        {
            //this.name_2 = param1.readInt();
            //this.name_2 = this.name_2 >>> 2 | this.name_2 << 30;
            //param1.readShort()

            UserID = param1.ReadInt32();
            UserID = (int)((uint)UserID >> 2 | (uint)UserID << 30);
            param1.ReadInt16();
           
        }


        
    }
}
