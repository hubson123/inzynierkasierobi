using PersonalniePL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonalniePL.Data
{
    public class PersonalnyContext : DbContext
    {
        public PersonalnyContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Podopieczny> Podopiecznies { get; set; }
        public DbSet<Trener> Treners { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<RodzajPlanu> RodzajPlanus { get; set; }
        public DbSet<Wiadomosc> Wiadomoscs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wiadomosc>().HasRequired<Trener>(w => w.Treners)
                 .WithMany(t => t.Wiadomosci)
                 .HasForeignKey(w => w.TrenerID)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Podopieczny>().HasRequired<Trener>(w => w.Trener)
                .WithMany(t => t.Podopiecznies)
                .HasForeignKey(w => w.TrenerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Plan>().HasRequired<Trener>(w => w.Trener)
               .WithMany(t => t.Plans)
               .HasForeignKey(w => w.TrenerID)
               .WillCascadeOnDelete(false);



        }

        public System.Data.Entity.DbSet<PersonalniePL.Models.Notka> Notkas { get; set; }
    }
}
