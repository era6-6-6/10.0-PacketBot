using Krypton_Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Write
{
    public class AttackCommand : Command
    {
        public AttackCommand(int id , int x , int y) => Write(id, x , y);
        public const short ID = 31106;
        private void Write( int id , int x , int y)
        {
            param1.writeShort(14);
            param1.writeShort(ID);
            param1.writeInt((int)((uint)x >>11 | (uint) x <<21));
            param1.writeInt((int)((uint)y >> 4 | (uint)y << 28));
            param1.writeInt((int)((uint)id >> 6 | (uint)id << 26));
        }
    }
}
