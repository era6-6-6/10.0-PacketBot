using FunnyProject.Commands.Write;
using FunnyProject.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.Logic
{
    public class NpcKillerModule : LogicInterface
    {
        public bool Running { get; set; }
        public NpcKillerModule(Api api): base(api)
        {
            
        }
        public async Task StartMethod()
        {
            while(Running)
            {
                try
                {
                    //while (!NpcAround())
                    //{
                    if (Api.User.Position.Moving == false)
                    {
                        Random r = new Random();
                        FlyToCorndinates(r.Next(0, 21000), r.Next(0, 13000));
                    }
                    //    await Task.Delay(50);
                    //    Api.User.SelectedBox = ClosestBox();
                    //    if (Api.User.SelectedBox == null) continue;
                    //    FlyToCorndinates(Api.User.SelectedBox.X, Api.User.SelectedBox.Y);
                    //    if (Api.User.SelectedBox == null) continue;
                    //    while (CalculateDistance(Api.User.SelectedBox.X, Api.User.SelectedBox.Y) > 50)
                    //    {

                    //        await Task.Delay(100);

                    //    }
                    //    Api.User.PacketManager.Send(new CollectBox(Api.User.SelectedBox.Hash, Api.User.Position.X, Api.User.Position.Y, Api.User.SelectedBox.X, Api.User.SelectedBox.Y));
                    //    int i = 0;
                    //    while (Api.User.SelectedBox != null && i < 10)
                    //    {
                    //        await Task.Delay(50);
                    //        i++;
                    //    }

                    //    Api.User.Boxes.Remove(Api.User.SelectedBox?.Hash);


                    //}
                    Api.User.Target = ClosestNpc();
                    if (Api.User.Target == null) continue;
                    SendPacket(new SelectShip(Api.User.Target.ID , Api.User.Position.X , Api.User.Position.Y, Api.User.Target.X, Api.User.Target.Y));
                    await Task.Delay(100);
                    FlyToCorndinates(Api.User.Target.X, Api.User.Target.Y);

                    
                    
                    SellectAmmo();
                    bool init = true;
                    while (Api.User.Target != null)
                    {
                         
                        if (init)
                        {
                            AssignAngle();
                            init = false;
                        }
                        if(!Api.User.Position.Moving)
                        {
                            FlyToCorndinates(Api.User.Target.X + 500, Api.User.Target.Y);
                        }
                        await Task.Delay(250);

                    }


                }
                catch
                {
                    
                }
            }
        }
    }
}
