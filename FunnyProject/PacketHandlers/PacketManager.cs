using FunnyProject.Commands.PacketSorter;
using FunnyProject.Commands.Read;
using FunnyProject.Commands.Write;
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
        public ObjectsHandler ObjHandler { get; set; }
        public PlayersEventHandler PlHandler { get; set; }
        private SortPacket SortClass { get; set; }
        public PacketManager(Api api)
        {
            Api = api;
            Res = new(Api);
            Hero = new(Api);
            PlHandler = new(Api); 
            ObjHandler = new(Api);
            SortClass = new(Api);
        }
        #region handlers
        //hero
        public event EventHandler<UserInitialize>? OnHeroInit;
        public event EventHandler<HpUpdate>? OnHpUpdate;

        //resources
        public event EventHandler<BoxInitialize>? OnBoxInit;

        //objects
        public event EventHandler<GateInitialize>? OnGateInit;
        public event EventHandler<RemoveBox>? OnBoxRemove;

        //players
        public event EventHandler<PlayerInit>? OnPlayerInit;
        public event EventHandler<RemovePlayer>? OnPlayerRemove;
        public event EventHandler<RemovePlayerFromMap>? OnPlayerRemoveFromMap;
        public event EventHandler<PlayerMoved>? OnPlayerMove;
        #endregion

        public override void Parse(EndianBinaryReader read)
        {
            var id = read.ReadInt16();
          
            switch(id)
            {
                case UserInitialize.ID:
                    {
                        var hero = new UserInitialize(read);
                        OnHeroInit?.Invoke(this, hero);
                        break;
                    }
                case 4224:
                    {
                        var message = read.ReadString();
                        if(!message.Contains("0|n|s|end"))
                        {
                            SortClass.Sort(message);
                            Console.WriteLine(message);
                        }
                        break;
                    }
                case BoxInitialize.ID:
                    {
                        var box = new BoxInitialize(read);
                        OnBoxInit?.Invoke(this, box);
                        break;
                    }
                case GateInitialize.ID:
                    {
                        var gate = new GateInitialize(read);
                        OnGateInit?.Invoke(this, gate);
                        break;
                    }
                case RemoveBox.ID:
                    {
                        var box = new RemoveBox(read);
                        OnBoxRemove?.Invoke(this , box);
                        break;
                    }
                case PlayerInit.ID:
                    {
                        var player = new PlayerInit(read);
                        OnPlayerInit?.Invoke(this,player);
                        break;
                    }
                case RemovePlayer.ID:
                    {
                        var player = new RemovePlayer(read);
                        OnPlayerRemove?.Invoke(this, player);
                        break;
                    }
                case RemovePlayerFromMap.ID:
                    {
                        var player = new RemovePlayerFromMap(read);
                        OnPlayerRemoveFromMap?.Invoke(this, player);
                        break;
                    }
                case PlayerMoved.ID:
                    {
                        var player = new PlayerMoved(read);
                        OnPlayerMove?.Invoke(this, player);
                        break;
                    }
                case ShieldUpdate.ID:
                    {
                        ShieldUpdate shd = new(read);
                        break;
                    }
                case HpUpdate.ID:
                    {
                        HpUpdate hp = new(read);
                        OnHpUpdate?.Invoke(this, hp);
                        break;
                    }
                case ShipInfoUpdate.ID:
                    {
                        ShipInfoUpdate ship = new(read);
                        break;
                    }
                case 10114:
                    {
                        var repair = new RepairShip(Api);
                        Send(repair);
                        break;
                    }
                default:
                    {
                        if (id != 4224)
                        {
                            Console.WriteLine("id: " + id);
                        }
                        break;
                    }
            }
        }
    }
}
