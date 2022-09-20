using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.UserCollections.Objects
{
    public class Player
    {
        public string? Name { get; set; }
        public int ID { get; set; }
        public int FactionID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public bool IsNpc { get; set; }

    }
}
