using Krypton_Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Write
{
    public class Move : Command
    {
        public const short ID = 17063;
        public Move(int FromX , int FromY , int ToX , int ToY)
        {
            param1.writeShort(18);
            param1.writeShort(ID);
            param1.writeInt((int)((uint)ToY >> 8 | (uint)ToY<< 24));
            param1.writeInt((int)((uint)FromX >> 15 | (uint)FromX << 17));
            param1.writeShort(-1667);
            param1.writeInt((int)((uint)ToX << 4 | (uint)ToX >> 28));
            param1.writeInt((int)((uint)FromY << 5 | (uint)ToX >> 27));
            
        }
    }
}
