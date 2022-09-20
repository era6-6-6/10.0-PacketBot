using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class RemoveBox
    {
        public const short ID = 25477;
        public string Hash { get; set; }
        bool Collected { get; set; }

        public RemoveBox(EndianBinaryReader read) => Read(read);

        private void Read(EndianBinaryReader param1)
        {
            Hash = param1.ReadString();
            Collected = param1.ReadBoolean();
        }
            
    }
}
