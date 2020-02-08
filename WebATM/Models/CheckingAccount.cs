using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebATM.Models
{
    /// <summary>
    /// Accountgegevens van user.
    /// </summary>
    [Table("Checking_Accounts")]
    public class CheckingAccount
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Nummer van account
        /// </summary>
        [Required]
        [StringLength(16)]
        [Display(Name = "Account #")]
        public string AccountNummer { get; set; }


        /// <summary>
        /// Naam van user-account
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Voornaam { get; set; }


        /// <summary>
        /// Achternaam van user-account
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Achternaam { get; set; }


        /// <summary>
        /// TelefoonNummer van user-account
        /// </summary>
        [Required]
        [StringLength(32)]
        [Display(Name = "Telefoonnummer #")]
        public string TelefoonNummer { get; set; }


        /// <summary>
        /// Dropdown volledige Voornaam + Achternaam
        /// </summary>
        public string Naam 
        {
            get
            {
                return string.Format("{0} {1}", this.Voornaam, this.Achternaam);
            }

        }


        /// <summary>
        /// in en uitgaven balans
        /// </summary>
        [DataType(DataType.Currency)]
        public decimal Balans { get; set; }
    }
}