using FunnyProject.PacketHandlers;
using FunnyProject.UserCollections;
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
        public PacketManager? PacketManager { get; set; }
        public Position Position = new();
        public Statistics Statistics = new();
        public Boxes Boxes = new();

    }
}
