using FunnyProject.Commands;
using FunnyProject.EventsHandler;
using System;
using Krypton_Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpClient = Krypton_Core.HttpClient;
using System.Text.RegularExpressions;
using System.Drawing.Text;
using System.Linq.Expressions;
using Unglide;
using System.Diagnostics;

namespace FunnyProject
{
    public class Api
    {
        public User User { get; set; }
        public HttpClient Client { get; set; }
        public Tweener Tweener;
        #region packet handlers
     
        #endregion

        public Api(User user)
        {
            User = user;
            Client = new HttpClient();
            Task.Run(async () => await UpdateTweener());
            Tweener = new();

        }

        private async Task UpdateTweener()
        {
            while (true)
            {
                try
                {
                    Stopwatch s = new Stopwatch();
                    s.Start();
                    await Task.Delay(15);
                    Tweener.Update(s.ElapsedMilliseconds);
                    s.Stop();
                }
                catch
                {

                }
            }
        }

        public async Task StartSession()
        {
            await Login();
            User.PacketManager = new(this);
            User.PacketManager.Connect("198.50.228.28", 8080);
            RegisterEvents();
            
            User.PacketManager.Send(new Login(userId: User.UserData.ID , SessionID: User.UserData.SID));
            
        }

        private void RegisterEvents()
        {
            User.PacketManager.Res.RegisterEvents();
            User.PacketManager.Hero.RegisterEvents();
            User.PacketManager.ObjHandler.RegisterEvents();
            User.PacketManager.PlHandler.RegisterEvents();
        }

        private async Task Login()
        {
            Client.Get("https://starzone.se");
            string loginString = $"username={User.Username}&password={User.Password}&action=login";
            var response = Client.Post("https://starzone.se/api" , loginString);
            if (response.Contains("{\"status\":true,\""))
            {
                Console.WriteLine("Logged in waiting 5s ");
                await Task.Delay(5000);
            }
            await GetData();
        }
        private async Task GetData()
        {
            string SID; 
            var response = Client.Get("https://starzone.se/map");
            Match match = Regex.Match(response, "\"sessionID\": \"(.*?)\",");
            if(match.Success)
            {
                User.UserData.SID = match.Groups[1].Value;
                Console.WriteLine("got sid: " + User.UserData.SID);
            }
            
            match = Regex.Match(response, "\"userID\": \"(.*?)\",");
            if(match.Success)
            {
                Console.WriteLine("got id: " + match.Groups[1].Value);
                User.UserData.ID = int.Parse(match.Groups[1].Value);
            }
        }
    }
}
