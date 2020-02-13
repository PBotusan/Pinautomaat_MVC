using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebATM.Models
{
    
    public class Transaction
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }


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

    }
}