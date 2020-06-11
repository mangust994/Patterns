using NoSQL_Yarik.Entytis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public class GunHistory
    {
        public Stack<Gun> History { get; private set; }
        public GunHistory()
        {
            History = new Stack<Gun>();
        }
    }
}
