using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.LicenseManager
{
    public class LicenseManager
    {
        TcpClient Client = new();
        

        public LicenseManager()
        {
            
        }

        public bool CanLogin(int id)
        {
            Client.Connect("202.61.228.149" , 35000);
            NetworkStream stream = Client.GetStream();
            var idLog = Encoding.UTF8.GetBytes(id.ToString());
            stream.Write(idLog);
            var buffer = new byte[10];
            stream.Read(buffer, 0, 10);
            Client.Close();
            return Encoding.UTF8.GetString(buffer).Contains("true");
        }
    }
}
