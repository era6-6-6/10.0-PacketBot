using FunnyProject.Commands.Read;
using FunnyProject.EventsHandler;
using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.PacketHandlers
{
    public class PacketManager : Client
    {
        public Api Api { get; set; }
        public EventHandlerResources Res { get; set; }
        public HeroEventHandler Hero { get; set; }
        public PacketManager(Api api)
        {
            Api = api;
            Res = new(Api);
            Hero = new(Api);
        }
        #region handlers
        //hero
        public event EventHandler<UserInitialize>? OnHeroInit;

        //resources
        public event EventHandler<BoxInitialize>? OnBoxInit;
        #endregion

        public override void Parse(EndianBinaryReader read)
        {
            var id = read.ReadInt16();
            Console.WriteLine("id: " + id);
            switch(id)
            {
                case UserInitialize.ID:
                    {
                        var hero = new UserInitialize(read);
                        OnHeroInit?.Invoke(this, hero);
                        break;
                    }
                case BoxInitialize.ID:
                    {
                        var box = new BoxInitialize(read);
                        OnBoxInit?.Invoke(this, box);
                        break;
                    }
            }
        }
    }
}
