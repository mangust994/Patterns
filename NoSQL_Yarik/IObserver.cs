using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public interface IObserver
    {
        IActionResult Create(Object ob);

        IActionResult Update(Object ob);

        IActionResult Delete(Object ob);
    }
}
