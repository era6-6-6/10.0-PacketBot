using FunnyProject.PacketHandlers;
using FunnyProject.UserCollections;
using FunnyProject.UserCollections.Objects;
using FunnyProject.UserCollections.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject
{
    public class User
    {
        public int Uridium { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Server { get; set; }
        public PacketManager? PacketManager { get; set; }

        public UserData UserData = new();
        public Position Position = new();
        public Statistics Statistics = new();
        public Boxes Boxes = new();
        public BasesPorts BasesPorts = new();
        public Players Players = new();
        public ShipInfo ShipInfo = new();
        

        public Box? SelectedBox { get; set; }
        public Player? Target { get; set; }


        public User(string name , string password , string server)
        {
            Username = name;
            Password = password;
            Server = server;

        }

    }
}
