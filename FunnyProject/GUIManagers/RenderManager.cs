using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.GUIManagers
{
    public class RenderManager : IDisposable
    {
        Graphics g { get; set; }
        Api Api { get; set; }
        double ConvertX, ConvertY;
        private int X;
        private int Y;
        public RenderManager(Graphics g, Api api ,  int x , int y)
        {
            Api = api;
            ConvertX = ((double)x / 21000);
            ConvertY = (double)y / 13000;
            this.g = g;
            X = x;
            Y = y;
            
        }
        private async Task DrawTarget()
        {
            if (Api.User.Target == null) return;

            g.FillEllipse(Brushes.OrangeRed,ReturnFloat(Api.User.Target.X * ConvertX), ReturnFloat(Api.User.Target.Y * ConvertY), 10, 10);
            await Task.CompletedTask;


        }

        private async Task DrawPlayer()
        {
            g.FillEllipse(Brushes.White , ReturnFloat(Api.User.Position.X * ConvertX) , ReturnFloat(Api.User.Position.Y * ConvertY) - 10 , 10 , 10);
            await Task.CompletedTask;
        }
        private async Task DrawPorts()
        {
            lock(Api.User.BasesPorts.Ports)
            {
                foreach (var port in Api.User.BasesPorts.Ports)
                {
                    g.DrawEllipse(new Pen(Brushes.White), (float)(port.X * ConvertX), (float)(port.Y * ConvertY) - 8 , 16 , 16 );
                 
                }
            }
            await Task.CompletedTask;
        }
        private async Task DrawBoxes()
        {
            lock(Api.User.Boxes)
            {
                foreach (var box in Api.User.Boxes._Boxes)
                {
                    if(box.Type.Contains("BONUS"))
                        g.FillEllipse(Brushes.Yellow, (float)(box.X * ConvertX) + 2, (float)(box.Y * ConvertY) -6 , 4, 4);
                }
            }
            await Task.CompletedTask;
        }
        private async Task RenderPlayerHp()
        {
            g.DrawLine(new Pen(Brushes.DarkGreen, 15), 10, Y - 40, 210, Y - 40);
            var hp = (int)((double)Api.User.ShipInfo.Hp / Api.User.ShipInfo.MaxHp * 100);
            g.DrawLine(new Pen(Brushes.LightGreen , 15) , 210 ,Y-40 , 210 - (2 * (100 - hp)),Y-40);
            g.DrawLine(new Pen(Brushes.DarkBlue, 15), 10, Y - 18 , 210 , Y-18);
            int shd = 0;
            if(Api.User.ShipInfo.Shield == 0 || Api.User.ShipInfo.MaxShield == 0)
            {
                shd = 100;
            }
            else
            {
                shd= (int)((double)Api.User.ShipInfo.Shield / Api.User.ShipInfo.MaxShield * 100);
            }
            g.DrawLine(new Pen(Brushes.LightBlue, 15), 210, Y - 18, 210 - (2 * (100 - shd)), Y - 18);
            await Task.CompletedTask;
        }
        private async Task DrawTrajectory()
        {
            g.DrawLine(new Pen(Brushes.White) , (float)(Api.User.Position.X * ConvertX) + 5 , (float)(Api.User.Position.Y *ConvertY) -5,(float)(Api.User.Position.TargetX * ConvertX) +5 ,(float)(Api.User.Position.TargetY * ConvertY)-5);
           
            await Task.CompletedTask;
        }

        
        private async Task DrawNpcs()
        {
            lock(Api.User.Players.Npcs)
            {
                foreach (var npc in Api.User.Players.Npcs)
                {
                    g.FillEllipse(Brushes.Red,(float)(npc.X * ConvertX) , (float)(npc.Y * ConvertY), 4, 4);
                }
            }
            await Task.CompletedTask;
        }
        private async Task DrawEnemyPlayers()
        {
            lock (Api.User.Players.EnemyPlayers)
            {
                foreach (var enemy in Api.User.Players.EnemyPlayers)
                {
                    g.FillEllipse(Brushes.Red, (float)(enemy.X * ConvertX), (float)(enemy.Y * ConvertY) , 7 , 7);
                }
            }
            await Task.CompletedTask;
        }
        private async Task DrawUri()
        {
            g.DrawString($"Uri:{Api.User.Statistics.CollectedUridium:n00}", new Font("helvetica" , 10) , Brushes.White , new PointF(0 , 0));
            await Task.CompletedTask;
        }
        private async Task DrawAllyPlayers()
        {
            lock (Api.User.Players.AllyPlayers)
            {
                foreach (var ally in Api.User.Players.AllyPlayers)
                {
                    g.FillEllipse(Brushes.Blue, (float)(ally.X *ConvertX), (float)(ally.Y * ConvertY), 4, 4);
                }
            }
            await Task.CompletedTask;
        }

        private List<Task> Tasks = new();
        public async Task Draw()
        {
            if(Api.User.Position.Moving)
            {
                Tasks.Add(DrawTrajectory());
            }
            Tasks.Add(RenderPlayerHp());
            Tasks.Add(DrawBoxes());
            Tasks.Add(DrawPorts());
            Tasks.Add(DrawNpcs());
            Tasks.Add(DrawEnemyPlayers());
            Tasks.Add(DrawAllyPlayers());
            Tasks.Add(DrawTarget());
            Tasks.Add(DrawUri());
            
            Tasks.Add(DrawPlayer());


            
            await Task.WhenAll(Tasks);
        }
        
       
        private float ReturnFloat(object num)
        {
            return Convert.ToSingle(num);
        }

        public  void Dispose()
        {
            g.Dispose();
        }
    }
}
