using Microsoft.AspNet.Identity.EntityFramework;
using P4GPayment.Domain;
using P4GPayment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace P4GPayment.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, NetRole, int, NetUserLogin, NetUserRole, NetUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<StreetNumber> StreetNumbers { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}