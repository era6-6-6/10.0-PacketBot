using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.UserCollections.Resources
{
    public class Box
    {
        public string Hash { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }
        
        public Box(string hash , int x , int y , string type)
        {
            Hash = hash;
            X = x;
            Y = y;
            Type = type;
           
            
        }
    }
}
