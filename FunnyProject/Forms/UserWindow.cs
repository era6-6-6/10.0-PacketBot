using FunnyProject.GUIManagers;
using FunnyProject.Logic;
using FunnyProject.Logic.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunnyProject.Forms
{
    public partial class UserWindow : Form
    {
        Api Api { get; init; }
        LogicInterface Move { get; set; }

        public UserWindow(Api api)
        {
            InitializeComponent();
            Form1.SetDoubleBuffered(MinimapPanel);
            Api = api;
            Task.Run(() => Api.StartSession());
            
            Move = new LogicInterface(Api);
            Task.Run(async () => await Render());
        }
        private async Task Render()
        {
            while (true)
            {
                try
                {
                    var bit = new Bitmap(MinimapPanel.Width, MinimapPanel.Height);
                    using (Graphics g = Graphics.FromImage(bit))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        RenderManager rd = new RenderManager(g, Api, MinimapPanel.Width, MinimapPanel.Height);
                        await rd.Draw();
                        var oldimage = MinimapPanel.BackgroundImage;


                        if (MinimapPanel.InvokeRequired)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                MinimapPanel.BackgroundImage = bit;
                            });
                        }
                        else
                        {
                            MinimapPanel.BackgroundImage = bit;
                        }

                        await Task.Delay(50);
                        if (oldimage != null)
                        {
                            oldimage.Dispose();
                            rd.Dispose();
                        }
                        if (UriLbl.InvokeRequired)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                UriLbl.Text = $"Uri: {Api.User.Statistics.CollectedUridium}/{Api.User.Statistics.Uridium}";
                            });
                        }
                        else
                        {
                            UriLbl.Text = $"Uri: {Api.User.Statistics.CollectedUridium}/{Api.User.Statistics.Uridium}";
                        }

                    }
                }
                catch (Exception ex)
                {
                    await Task.Delay(50);
                   
                }

            }



        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            NpcKillerModule npc = new NpcKillerModule(Api);
            FollowModule follow = new FollowModule(Api);
            npc.Running = true;
            BoxLogic box = new BoxLogic(Api);
            box.Running = true;
            Task.Run(async () => await npc.StartMethod());
        }

        private void MinimapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (Move == null) return;
            var ConvertX = ((double)MinimapPanel.Width / 21000);
            var ConvertY = (double)MinimapPanel.Height / 13000;

            Move.FlyToCorndinates((int)((double)e.X / ConvertX), (int)((double)e.Y / ConvertY));
            
        }
    }
}
