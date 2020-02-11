using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebATM.Models;

namespace WebATM.Controllers
{
    [Authorize]
    public class CheckingAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserAccounts
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserAccounts/Details/5
        /// <summary>
        /// Huidige user uit database halen doorsturen naar details view
        /// </summary>
        /// <returns> View met user</returns>
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccount = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First();
            return View(checkingAccount);
        }

        /// <summary>
        /// Custom details for admin, zoekt naar huidige checking account
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details met checkingaccount</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var checkingAccount = db.CheckingAccounts.Find(id);
            return View("Details", checkingAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List() 
        {
            return View(db.CheckingAccounts.ToList());        
        }

        // GET: UserAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccounts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserAccounts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAccounts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserAccounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAccounts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
