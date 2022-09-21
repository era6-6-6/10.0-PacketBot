using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Commands.PacketSorter
{
    public class SortPacket
    {
        Api Api { get; set; }

        public SortPacket(Api api)
        {
            Api = api;
        }
        
        public void Sort(string message)
        {
            if(message.Contains("URI"))
            {
                try
                {
                    var str = message.Split('|');
                    Api.User.Statistics.CollectedUridium += int.Parse(str[4]);
                    Api.User.Statistics.Uridium = int.Parse(str[5]);
                    Console.WriteLine("Uridium: " + Api.User.Statistics.Uridium);
                    Console.WriteLine("Collected Uridium: " + Api.User.Statistics.CollectedUridium);
                }catch
                {
                    
                }
            }
        }
    }
}
