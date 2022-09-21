using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class RemovePlayer
    {
        public const short ID = 22038;

        public int UserID { get; set; }
        public RemovePlayer(EndianBinaryReader read) => Read(read);

        private void Read(EndianBinaryReader param1)
        {
            UserID = param1.ReadInt32();
            UserID = (int)((uint)UserID << 5 | (uint)UserID >> 27);
            var uk = param1.ReadInt32();
            uk = (int)((uint)uk << 2| (uint)uk <<30 );
        
        }
    }
}
