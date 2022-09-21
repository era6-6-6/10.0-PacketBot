using FunnyProject.Commands.Read;
using FunnyProject.UserCollections.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FunnyProject.EventsHandler
{
    public class PlayersEventHandler
    {
        Api Api { get; set; }
        public PlayersEventHandler(Api api)
        {
            Api = api;
        }
        public void RegisterEvents()
        {
            Api.User.PacketManager.OnPlayerInit += (s, e) =>
            {
                InitPlayer(e);
            };
            Api.User.PacketManager.OnPlayerRemove += (s, e) =>
            {
                RemovePlayer(e);
            };
            Api.User.PacketManager.OnPlayerRemoveFromMap += (s, e) =>
            {
                RemovePlayerFromMap(e);
            };
            Api.User.PacketManager.OnPlayerMove += (s, e) =>
            {
                TweenPlayer(e);
            };
        }

        private void TweenPlayer(PlayerMoved e)
        {
            var player = Api.User.Players.AllPlayers.Find(x => x.ID == e.UserID);

            if (player != null)
            {
                Api.Tweener.TargetCancel(player);
                Api.Tweener.Tween(player, new { X = e.ToX, Y = e.ToY }, e.Duration);
            }
            
        }

        private void RemovePlayerFromMap(RemovePlayerFromMap e)
        {
            Api.User.Players.Remove(e.UserID);
            if (e.UserID == Api.User.Target.ID) Api.User.Target = null;
        }

        private void RemovePlayer(RemovePlayer e)
        {
            
            Api.User.Players.Remove(e.UserID);
            if (e.UserID == Api.User.Target.ID) Api.User.Target = null;
        }

        private void InitPlayer(PlayerInit e)
        {
            var player = new Player();
            player.Name = e.NpcName;
            player.ID = e.PlayerID;
            player.FactionID = e.FactionId;
            player.X = e.X;
            player.Y = e.Y;
            player.IsNpc = e.IsNpc;
            bool isEnemy = Api.User.UserData.FactionId != e.FactionId;
            Api.User.Players.Add(player , isEnemy);
        }
    }
}
