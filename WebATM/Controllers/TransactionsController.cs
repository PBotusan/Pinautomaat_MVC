using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebATM.Models;
using WebATM.StringArrays;
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

        // GET: Transactions
        public ActionResult DepositSpaarrekening(int checkingAccountId)
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

                OmschrijvingArray omschrijvingArray = new OmschrijvingArray();
                omschrijvingArray.KiesRandom();
                transaction.Plaats = omschrijvingArray.GekozenPlaats;
                transaction.Omschrijving = omschrijvingArray.GekozenOmschrijving;
                transaction.Datum = DateTime.Now;

                checkingAccountSaldo.Balans += transaction.Hoeveelheid;
                db.Transactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DepositSpaarrekening(Transaction model) 
        {
            if (ModelState.IsValid)
            {
                Transaction transaction = db.Transactions.Add(model);
                CheckingAccount checkingAccountSaldo = db.CheckingAccounts.Find(model.CheckingAccountId);
                if (transaction == null)
                {
                    return HttpNotFound();
                }

                if (checkingAccountSaldo.Balans > 0) 
                {
                    checkingAccountSaldo.Balans -= transaction.Hoeveelheid;

                    OmschrijvingArray omschrijvingArray = new OmschrijvingArray();
                    omschrijvingArray.KiesRandom();
                    transaction.Plaats = omschrijvingArray.GekozenPlaats;
                    transaction.Omschrijving = "Eigen rekening naar Spaarrekening";
                    transaction.Datum = DateTime.Now;

                    checkingAccountSaldo.Spaarrekening += transaction.Hoeveelheid;
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
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
                //bereken bedrag eerste model is het totaal bedrag, tweede model maakt hem 0, derde zorgt voor min bedrag.
                model.Hoeveelheid = model.Hoeveelheid - model.Hoeveelheid - model.Hoeveelheid;

                Transaction transaction = db.Transactions.Add(model);
                if (transaction == null)
                {
                    return HttpNotFound();
                }

                OmschrijvingArray omschrijvingArray = new OmschrijvingArray();
                omschrijvingArray.KiesRandom();
                transaction.Plaats = omschrijvingArray.GekozenPlaats;
                transaction.Omschrijving = omschrijvingArray.GekozenOmschrijving;
                transaction.Datum = DateTime.Now;

                checkingAccountSaldo.Balans += transaction.Hoeveelheid;
                db.Transactions.Add(transaction);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // GET: UserAccounts/Details/5
        /// <summary>
        /// Huidige user uit database halen doorsturen naar details view
        /// </summary>
        /// <returns> View met user</returns>
        public ActionResult Details(int id)
        {
            var gekozenTransaction = db.Transactions.Where(c => c.Id == id).First();
            return View(gekozenTransaction);
        }

        public PartialViewResult _ShowSaldo(int checkingAccountId) 
        {
            var gekozenTransaction = db.CheckingAccounts.Where(c => c.Id == checkingAccountId).First();
            return PartialView(gekozenTransaction);
        }
    } 
}