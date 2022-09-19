using Krypton_Core.Packets.Bytes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton_Core.Managers
{
    public abstract class Command
    {
        protected MemoryStream memoryStream;

        public ByteArray param1;

        protected Command()
        {
            memoryStream = new MemoryStream();
            param1 = new ByteArray();
        }

        public byte[] ToArray()
        {
            return memoryStream.ToArray();
        }

      
    }
}
