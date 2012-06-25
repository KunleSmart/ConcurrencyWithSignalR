using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConcurrencySample.Models;
using SignalR;

namespace ConcurrencySample.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Bank b = new Bank();
            b.BankId = 22;
            b.CBNCode = "CBN022";
            b.Name = "New Bank";
            b.Shortname = "S NAme";
            return View(b);
        }

        [HttpPost]
        public ActionResult Index(Bank b)
        {
            //asuming concurrency is violated after some check
            bool concurrencyViolated = true;
            if (concurrencyViolated == true)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<ConcurencyHub>();
                context.Clients.itemUpdated(b, "BankId");

                return RedirectToAction("Details", new { id = b.BankId });
            }

            return View(b);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Bank b = new Bank();
            b.BankId = 22;
            b.CBNCode = "CBN022";
            b.Name = "New Bank";
            b.Shortname = "S NAme";
            return View(b);
        }
    }

}
