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

        /// <summary>
        /// Saldo toevoegen aan aan ingelogde user, toevoegen aan ingelogde user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Deposit(Transaction model)
        {
            if (ModelState.IsValid)
            {
                CheckingAccount checkingAccountSaldo = db.CheckingAccounts.Find(model.CheckingAccountId);
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


        // GET: Transactions
        public ActionResult Withdrawl(int checkingAccountId)
        {
            return View();
        }

        /// <summary>
        /// Saldo toevoegen aan aan ingelogde user, toevoegen aan ingelogde user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Withdrawl(Transaction model)
        {
            if (ModelState.IsValid)
            {
                CheckingAccount checkingAccountSaldo = db.CheckingAccounts.Find(model.CheckingAccountId);
                Transaction transaction = db.Transactions.Add(model);
                if (transaction == null)
                {
                    return HttpNotFound();
                }

                checkingAccountSaldo.Balans -= transaction.Amount;
                db.Transactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    } 
}