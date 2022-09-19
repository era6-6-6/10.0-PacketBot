using FunnyProject.Commands.Read.Interfaces;
using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Read
{
    public class BoxInitialize : BoxInterface
    {

        public const short ID = 18425;
        
        public string Type { get; set; }


        public BoxInitialize(EndianBinaryReader param1) : base(param1)
        {
            base.Read(param1);
            Type = param1.ReadString();
            param1.ReadInt16();
        }
        
    }
}
