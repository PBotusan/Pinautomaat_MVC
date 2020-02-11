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
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Accountnummer kan alleen tussen 6 en 10 cijfers bevatten.")]
        [Column(TypeName ="varchar")]
        [Display(Name = "Account:")]
        public string AccountNummer { get; set; }


        /// <summary>
        /// Naam van CheckAccount
        /// </summary>
        [Required]
        [StringLength(32)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Alleen characters zijn toegestaan")]
        public string Voornaam { get; set; }


        /// <summary>
        /// Achternaam van user-account
        /// </summary>
        [Required]
        [StringLength(32)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Alleen characters zijn toegestaan")]
        public string Achternaam { get; set; }


        /// <summary>
        /// TelefoonNummer van user-account
        /// </summary>
        [Required]
        [StringLength(32)]
        [RegularExpression(@"\d{1,15}", ErrorMessage = "Telefoonnummer moet tussen 1 en 15 cijfers bevatten.")]
        [Display(Name = "Telefoonnummer: ")]
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
        //[RegularExpression("",ErrorMessage = "Kan alleen valuta bevatten")]
        public decimal Balans { get; set; }

        /// <summary>
        /// Hele gebruiker
        /// </summary>
        public virtual  ApplicationUser User { get; set; }
        /// <summary>
        /// key voor gebruikers
        /// </summary>
        [Required]
        public string ApplicationUserId { get; set; }
    }
}