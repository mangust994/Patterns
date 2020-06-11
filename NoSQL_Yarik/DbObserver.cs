using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using NoSQL_Yarik.Entytis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSQL_Yarik
{
    public class DbObserver : ControllerBase,  IObserver
    {
        IObservable model;

        public DbObserver(IObservable obs)
        {
            model = obs;
            model.RegisterObserver(this);
        }

        public IActionResult Create(object ob)
        {
            return RedirectToAction("Index", "Home", null);
        }

        public IActionResult Delete(object ob)
        {
            return RedirectToAction("Index","Home", null);
        }

        public IActionResult Update(object ob)
        {
            return RedirectToAction("Index", "Home", null);
        }
    }
}
