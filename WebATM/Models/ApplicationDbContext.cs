﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebATM.Models
{
    /// <summary>
    /// Db context praat met de database en is voor entity framework nodig om te kunnen zien welke models we gebruiken.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Db set om met database te linken
        /// </summary>
        public DbSet<CheckingAccount> CheckingAccounts { get; set; }
        /// <summary>
        /// Db set om met database te linken
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }


    }
}