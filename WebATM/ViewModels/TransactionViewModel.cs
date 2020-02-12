using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebATM.Models;

namespace WebATM.ViewModels
{

    public class TransactionViewModel
    {
        /// <summary>
        /// Hoeveelheid geld in transactie
        /// </summary>
        [Required]
        public decimal Amount { get; set; }


        /// <summary>
        /// Id van checking account linkt checking accout samen met transaction
        /// </summary>
        [Required]
        public int CheckingAccountId { get; set; }



        /// <summary>
        /// lijst met CheckingAccounts om je balans te vullen.
        /// </summary>
        public virtual ICollection<CheckingAccount> CheckingAccounts { get; set; }

        /// <summary>
        /// lijst met Transactions om je balans te vullen.
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}