﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebATM.Models;

namespace WebATM.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transactions
        public ActionResult Deposit(int checkingAccountId)
        {
            return View();
        }

        // GET: Transactions
        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {
            if (ModelState.IsValid) 
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}