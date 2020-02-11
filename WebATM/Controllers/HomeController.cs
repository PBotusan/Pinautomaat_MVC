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
        /// Pakt de user dat is ingelogd, en zorgt er voor dat userid verbonden wordt met checkingaccounts
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

            return View();
        }

        /// <summary>
        /// Geeft de serial number door.
        /// </summary>
        /// <param name="letterCase"></param>
        /// <returns> Redirect action met index</returns>
        public ActionResult Serial(string letterCase)
        {
            //todo user uit database halen
            var serial = "testnumber12345";
            if (letterCase == "lower")
            {

                return Content(serial.ToLower());
            }
            return RedirectToAction("Index");
        }
    }
}