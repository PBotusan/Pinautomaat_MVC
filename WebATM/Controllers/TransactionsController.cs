using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebATM.Models;
using WebATM.ViewModels;

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

        //// GET: Transactions
        //[HttpPost]
        //public ActionResult Deposit(Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Transactions.Add(transaction);

        //       // var saldo = db.CheckingAccounts.Where();
        //     //   db.Transactions.Where(c => c.CheckingAccountId == .);


        //        db.SaveChanges();

        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult Deposit(Transaction model)
        {
            if (ModelState.IsValid)
            {
                CheckingAccount checkingAccountSaldo = db.CheckingAccounts.Find(model.CheckingAccountId);
                //Transaction transaction = db.Transactions.Find(model.Id);
                Transaction transaction = db.Transactions.Add(model);
                if (transaction == null)
                {
                    return HttpNotFound();
                }

                checkingAccountSaldo.Balans += transaction.Amount;

                db.Transactions.Add(transaction);


                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }

    }
}