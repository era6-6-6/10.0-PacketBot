using FunnyProject.UserCollections.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Logic.Interface
{
    public class FollowModule : LogicInterface
    {
        public FollowModule(Api api) : base(api)
        {
            
        }


        public async Task OnStart()
        {
            while(true)
            {
                var userId = 10367;
                await Task.Delay(100);
                Player? user = null;
                while(user == null)
                {
                    user = Api.User.Players.AllyPlayers.Find(x => x.ID == userId);
                    await Task.Delay(100);
                }

                while (user != null)
                {
                   
                        Circle(user);
                    await Task.Delay(200);
                }
            }
        }
    }
}
