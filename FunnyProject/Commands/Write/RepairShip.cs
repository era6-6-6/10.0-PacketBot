using Krypton_Core.Managers;
using Krypton_Core.Packets.Bytes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.Write
{
    
    public class RepairShip: Command
    {
        public const short ID = 25971;
        public RepairShip(Api api) => Write(api);
        

        private void Write(Api api)
        {
            param1.writeShort(58);
            param1.writeShort(ID);
            param1.writeShort(1);
            param1.writeShort(20436);
            param1.writeShort(8550);
            param1.writeInt((int)((uint)69 >> 8 | (uint)69 << 24));
            param1.writeInt((int)((uint)api.User.UserData.ID >> 8 | (uint)api.User.UserData.ID << 24));
            param1.writeShort(0);
            param1.writeUTF(api.User.UserData.SID);
            param1.writeUTF("8.3.2");

        }
    }
        
    
}
