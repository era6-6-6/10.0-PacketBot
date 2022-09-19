using FunnyProject.Commands;
using FunnyProject.EventsHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject
{
    public class Api
    {
        public User User { get; set; }

        #region packet handlers
     
        #endregion

        public Api(User user)
        {
            User = user;
            

        }

        public async Task StartSession()
        {
            User.PacketManager = new(this);
            User.PacketManager.Connect("198.50.228.28", 8080);
            
            User.PacketManager.Res.RegisterEvents();
            User.PacketManager.Hero.RegisterEvents();
            User.PacketManager.Send(new Login());
            
        }
    }
}
