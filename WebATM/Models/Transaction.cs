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
        [Display(Name = "Hoeveelheid:")]
        public decimal Hoeveelheid { get; set; }


        /// <summary>
        /// omschrijving geld in transactie
        /// </summary>
        [Display(Name = "Omschrijving:")]
        public string Omschrijving { get; set; }


        /// <summary>
        /// Plaats in transactie
        /// </summary>
        [Display(Name = "Plaats:")]
        public string Plaats { get; set; }

        /// <summary>
        /// Hoeveelheid geld in transactie
        /// </summary>
        [Display(Name = "Datum:")]
        public DateTime Datum { get; set; }


        /// <summary>
        /// Id van checking account linkt checking accout samen met transaction
        /// </summary>
        [Required]
        public int CheckingAccountId { get; set; }

    }
}