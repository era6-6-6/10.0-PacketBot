using FunnyProject.Commands.Write;
using FunnyProject.Logic.Interface;
using FunnyProject.UserCollections.Objects;
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
                    if((double)Api.User.ShipInfo.Hp / Api.User.ShipInfo.MaxHp * 100 < 30)
                    {
                        var port = Api.User.BasesPorts.Ports.OrderBy(x => CalculateDistance(x.X, x.Y)).FirstOrDefault();
                        FlyToCorndinates(port.X, port.Y);
                        while(Api.User.ShipInfo.Hp < Api.User.ShipInfo.MaxHp)
                        {
                            await Task.Delay(300);
                        }
                    }
                    Player? npc = ClosestNpc();
                   
                    if (npc == null) continue;
                    Api.User.Target = npc;
                    await Task.Delay(210);
                    FlyToCorndinates(npc.X, npc.Y);

                    while (CalculateDistance(npc.X, npc.Y) > 1000)
                    {
                        await Task.Delay(200);
                        FlyToCorndinates(Api.User.Target.X, Api.User.Target.Y);
                    }
                    SendPacket(new SelectShip(npc.ID, npc.X, npc.Y, Api.User.Position.X, Api.User.Position.Y));
                    SellectAmmo();
                    
               
                    while (Api.User.Target != null)
                    {
                      
                        SellectAmmo();
                        
                            Circle(Api.User.Target.X, Api.User.Target.Y);


                        if ((double)Api.User.ShipInfo.Hp / Api.User.ShipInfo.MaxHp * 100 < 30)
                        {
                            Radius = 3000;
                            await Task.Delay(500);
                        }
                        else if ((double)Api.User.ShipInfo.Hp / Api.User.ShipInfo.MaxHp * 100 >= 90)
                        {
                            Radius = 500;
                            
                        }
                        await Task.Delay(200);
                       
                        
                        
                    }


                }
                catch(Exception ex)
                {
                    
                }
                await Task.Delay(20);
            }
        }

        private void CheckHp()
        {
            
        }
    }
}
