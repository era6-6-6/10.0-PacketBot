using FunnyProject.Commands.Read;
using FunnyProject.UserCollections.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.EventsHandler
{
    public class ObjectsHandler
    {
        Api Api { get; init; }
        public ObjectsHandler(Api api)
        {
            Api = api;
        }

        public void RegisterEvents()
        {
            Api.User.PacketManager.OnGateInit += (s, e) =>
            {
                GateInit(e);
            };
            Api.User.PacketManager.OnBoxRemove += (s, e) =>
            {
                RemoveBox(e);
            };
        }

        private void RemoveBox(RemoveBox e)
        {
            if (e.Hash == Api.User.SelectedBox?.Hash) Api.User.SelectedBox = null;
            Api.User.Boxes.Remove(e.Hash);
        }

        private void GateInit(GateInitialize e)
        {
            var gate = new Gate(1 , e.FactionId , e.X , e.Y);
            Api.User.BasesPorts.Add(gate);
        }
    }
    
}
