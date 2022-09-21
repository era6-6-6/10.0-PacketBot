using Krypton_Core.Managers;
using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Write
{
    public class SelectShip : Command
    {

        public SelectShip(int id , int X , int Y , int pX , int py) => Write(id , X , Y , pX , py);
        public const short ID = 18091;

        private void Write(int id , int x , int y , int px , int py)
        {
          
            param1.writeShort(24);
            param1.writeShort(ID);
            param1.writeShort(-19609);
            param1.writeInt((int)((uint)px << 5 | (uint)px >> 27));
            param1.writeInt((int)((uint)x << 12 | (uint)x >> 20));
            param1.writeInt((int)((uint)y << 14 | (uint)y >> 18));
            param1.writeInt((int)((uint)id << 14 | (uint)id >> 18));
            param1.writeInt((int)((uint)py << 7 | (uint)py >> 25));
        }
    }
}
