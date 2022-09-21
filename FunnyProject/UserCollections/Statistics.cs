using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.UserCollections
{
    public class Statistics
    {
        public double Experience { get; set; }
        public int Level { get; set; }
        public double Honor { get; set; }
        public double Uridium { get; set; }
        public double Credits { get; set; }
        public int CollectedUridium { get; internal set; }
    }
}
