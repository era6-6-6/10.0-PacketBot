using FunnyProject.UserCollections.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.EventsHandler
{
    public class EventHandlerResources
    {
        Api Api { get; init; }
                
        
        public EventHandlerResources(Api api)
        {
            Api = api;
            
        }
        public void RegisterEvents()
        {
            Api.User.PacketManager.OnBoxInit += (s, e) =>
            {
                OnBoxInit(e);
            };
        }

        private void OnBoxInit(Commands.Read.BoxInitialize e)
        {
            Api.User.Boxes.Add(new Box(e.Hash, e.X, e.Y, e.Type));
            
        }
    }
}
