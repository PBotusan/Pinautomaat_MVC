using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebATM.StringArrays
{
    public class OmschrijvingArray
    {
        /// <summary>
        /// Random gekozen plaats uit array
        /// </summary>
        public string GekozenPlaats { get; set; }

        /// <summary>
        /// Random gekozen uit omschrijving array
        /// </summary>
        public string GekozenOmschrijving { get; set; }


        string[] omschrijvingArray = new string[] { "Deen", "Dekamarkt", "Slager", "Vomar", "Primark", "Nintendo store", "4531554352", "4677654336", "9248785923", "Geleteken", "VUE", "12345654", "54376543", "098765432", "H&M", "Thee winkel", "Spar", "Dumpstore" };
        string[] plaatsArray = new string[] { "Wervershoof", "Hoorn", "Andijk", "Midwoud", "Amsterdam", "Rotterdam", "Morgenwoud", "Duitsland", "UK", "Urk", "Europasingel", "Alkmaar", "Hurnberg", "Zwaag", "Zwaagdijk", "Venhuizen", "Dorpshallen"  };


        /// <summary>
        /// pakt random value uit array
        /// </summary>
        public void KiesRandom() 
        {
            Random randomOmschrijving = new Random();
            Random randomPlaats = new Random();

            int r1 = randomPlaats.Next(plaatsArray.Length);
            int r2 = randomOmschrijving.Next(omschrijvingArray.Length);

            GekozenPlaats = plaatsArray[r1];
            GekozenOmschrijving = omschrijvingArray[r2];
        }
    }
}