using FunnyProject.Commands.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.EventsHandler
{
    public class HeroEventHandler
    {
        Api Api { get; init; }
        public HeroEventHandler(Api api)
        {
            Api = api;

            
        }
        public void RegisterEvents()
        {
            Api.User.PacketManager.OnHeroInit += (s, HeroInitData) =>
            {
                InitializeHero(HeroInitData);
            };

        }

        private void InitializeHero(UserInitialize e)
        {
            var stats = Api.User.Statistics;
            var position = Api.User.Position;
            stats.Uridium = e.Uridium;
            stats.Credits = e.Credits;
            stats.Experience = e.Experience;
            stats.Level = e.Level;
            stats.Honor = e.Honnor;

            position.X = e.X;
            position.Y = e.Y;
        }
    }
}
