using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NoSQL_Yarik.DataBase;
using NoSQL_Yarik.Entitys;
using NoSQL_Yarik.Entytis;
using NoSQL_Yarik.Models;

namespace NoSQL_Yarik.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Gun> gunRepo;
        private readonly IRepository<Order> orderRepo;
        static GunHistory gunHistory = new GunHistory();
        public HomeController()
        {
            this.gunRepo = MyFactory.ReturnGunRepository();
            this.orderRepo = MyFactory.ReturnOrderRepository();
        }

        public IActionResult Index()
        {
            ViewBag.Guns = gunRepo.Find(null);
            return View();
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.GunId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            orderRepo.Create(order);
            return "Спасибо, за покупку!";
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.Gun = gunRepo.Get(id.Value);
            return View();
        }
        [HttpPost]
        public IActionResult Update(Gun gun)
        {
            GunOrganizator gunOrganizator = new GunOrganizator(gun);
            gunHistory.History.Push(gunOrganizator.SaveState());
            return RedirectToAction("Index");
        }

        public IActionResult Updat2(Gun gun)
        {
            GunOrganizator gunOrganizator = new GunOrganizator(gun);
            gunOrganizator.RestoreState(gunHistory.History.Pop());
            gun = gunOrganizator.SaveState();
            gunRepo.Update(gun);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            GunObservable observable = new GunObservable();
            DbObserver dbObserver = new DbObserver(observable);
            observable.DeleteModel(id.Value);
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Orders = orderRepo.Find(null);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
