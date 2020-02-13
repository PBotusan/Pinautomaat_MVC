using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebATM.Models;

namespace WebATM.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        /// <summary>
        /// Pakt de user dat is ingelogd, en zorgt er voor dat 
        /// verbonden wordt met checkingaccounts
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;

            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            ViewBag.Pin = user.Pin;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Heeft u problemen ? Stuur ons een bericht";

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> De contact view</returns>
        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Heeft u problemen ? Stuur ons een bericht";

            return View();
        }

        /// <summary>
        /// Contactpage geeft parameter mee van het bericht. wordt actief wanneer je submit drukt.
        /// </summary>
        /// <returns> De contact view</returns>
        [HttpPost]
        public ActionResult Contact(string bericht)
        {
           
            ViewBag.TheMessage = "Bedankt, we hebben uw bericht ontvangen";

            return PartialView("_ContactThanks");
        }

        /// <summary>
        /// Geeft de serial number door.
        /// </summary>
        /// <param name="letterCase"></param>
        /// <returns> Redirect action met index</returns>
        public ActionResult Serial(int? checkingAccountId)
        {
            //todo user uit database halen.
            var serial = db.CheckingAccounts.Where(n => n.Id == checkingAccountId).FirstOrDefault();
            if (serial == null) 
            {
                return Content("");
            }

            var serialNumber = serial.AccountNummer;
            if (serialNumber != null)
            {
                return Content(serialNumber);
            }
            return RedirectToAction("Index");
        }
    }
}