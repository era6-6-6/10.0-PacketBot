using Krypton_Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands
{
    public class Login : Command
    {
        public const short ID = 10996;
        public Login(int instanceID = 563, int userId = 1469, short FactionId = 0, string SessionID = "hGmwf36gLobdrNMLOAMuYOfk97h5LAwz", string version = "8.3.2")
        {
            param1.writeShort(53);
            param1.writeShort(ID);
            param1.writeInt((int)((uint)instanceID >> 8 | (uint)instanceID << 24));
            param1.writeInt((int)((uint)userId >> 8 | (uint)userId << 24));
            param1.writeShort(FactionId);
            param1.writeUTF(SessionID);
            param1.writeUTF(version);
        }
        
    }
        
    
}
