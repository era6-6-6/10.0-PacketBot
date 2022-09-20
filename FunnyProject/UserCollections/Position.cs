using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.UserCollections
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        public int TargetX { get; internal set; }
        public int TargetY { get; internal set; }
        public bool Moving { get; internal set; }
    }
}
