using FunnyProject.UserCollections.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.UserCollections
{
    public class BasesPorts
    {
        public List<Gate> Ports = new();

        public void Add(Gate gate)
        {
            lock(Ports)
            {
                Ports.Add(gate);
            }
        }

        public void Remove(Gate gate)
        {
            lock (Ports)
            {
                Ports.Remove(gate);
            }
        }
    }
}
