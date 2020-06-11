using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    interface IBuilder<T>
    {
        T GetResult();
    }
}
