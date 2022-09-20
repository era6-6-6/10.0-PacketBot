using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.GUIManagers
{
    public class RenderManager
    {
        Graphics g { get; set; }
        Api Api { get; set; }
        double ConvertX, ConvertY;
        public RenderManager(Graphics g, Api api ,  int x , int y)
        {
            Api = api;
            ConvertX = ((double)x / 21000);
            ConvertY = (double)y / 13000;
            this.g = g;
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
                    g.DrawEllipse(new Pen(Brushes.White), (float)(port.X * ConvertX), (float)(port.Y * ConvertY)-8 , 16 , 16 );
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
                    g.FillEllipse(Brushes.Yellow, (float)(box.X * ConvertX), (float)(box.Y * ConvertY) , 4, 4);
                }
            }
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
            Tasks.Add(DrawBoxes());
            Tasks.Add(DrawPorts());
            Tasks.Add(DrawNpcs());
            Tasks.Add(DrawEnemyPlayers());
            Tasks.Add(DrawAllyPlayers());

            
            Tasks.Add(DrawPlayer());


            
            await Task.WhenAll(Tasks);
        }
        
       
        private float ReturnFloat(object num)
        {
            return Convert.ToSingle(num);
        }
    }
}
