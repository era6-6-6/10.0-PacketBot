using FunnyProject.UserCollections.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyProject.UserCollections
{
    public class Boxes
    {
        public List<Box> _Boxes = new();
        public void Add(Box box)
        {
            lock(_Boxes)
            {
                _Boxes.Add(box);
            }

        }
        public void Remove(string hash)
        {
            lock(_Boxes)
            {
                if(_Boxes.Find(x => x.Hash == hash) != null)
                {
                    _Boxes.RemoveAll(x => x.Hash == hash);
                }
            }
        }


    }
}
