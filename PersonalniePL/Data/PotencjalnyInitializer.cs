using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalniePL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonalniePL.Data
{
    public class PersonalnyInitializer : DropCreateDatabaseAlways<PersonalnyContext>
    {
        protected override void Seed(PersonalnyContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(new ApplicationDbContext()));
            roleManager.Create(new IdentityRole("Adminek"));
            roleManager.Create(new IdentityRole("Trener"));
            roleManager.Create(new IdentityRole("Podopieczny"));
            var user = new ApplicationUser { UserName = "hubert.firek@o2.pl", Email = "hubert.firek@o2.pl" };
            string pass = "B@rdzotrudnehaslo123";
            userManager.Create(user, pass);
            userManager.AddToRole(user.Id, "Adminek");
            var user1 = new ApplicationUser { UserName = "mikoa@o34.pl", Email = "mikoa@o34.pl" };
            string pass1 = "Zaq1@WSX";
            userManager.Create(user1, pass1);
            userManager.AddToRole(user1.Id, "Podopieczny");
            var user2 = new ApplicationUser { UserName = "troll@o34.pl", Email = "troll@o34.pl" };
            string pass2 = "Zaq1@WSX";
            userManager.Create(user2, pass2);
            userManager.AddToRole(user2.Id, "Podopieczny");
            var user3 = new ApplicationUser { UserName = "fog@o34.pl", Email = "fog@o34.pl" };
            string pass3 = "Zaq1@WSX";
            userManager.Create(user3, pass3);
            userManager.AddToRole(user3.Id, "Podopieczny");
            var user4 = new ApplicationUser { UserName = "Balion@o34.pl", Email = "Balion@o34.pl" };
            string pass4 = "Zaq1@WSX";
            userManager.Create(user4, pass4);
            userManager.AddToRole(user4.Id, "Trener");
            var user5 = new ApplicationUser { UserName = "amigo@o34.pl", Email = "amigo@o34.pl" };
            string pass5 = "Zaq1@WSX";
            userManager.Create(user5, pass5);
            userManager.AddToRole(user5.Id, "Trener");
            context.SaveChanges();
            var user6 = new ApplicationUser { UserName = "markow@o34.pl", Email = "markow@o34.pl" };
            string pass6 = "Zaq1@WSX";
            userManager.Create(user6, pass6);
            userManager.AddToRole(user6.Id, "Trener");
            var user7 = new ApplicationUser { UserName = "mrio@o34.pl", Email = "mrio@o34.pl" };
            string pass7 = "Zaq1@WSX";
            userManager.Create(user7, pass7);
            userManager.AddToRole(user7.Id, "Trener");

            var rodzaje = new List<RodzajPlanu> {
            new RodzajPlanu{Nazwa="Redukcja tkanki tłuszczowej"},
            new RodzajPlanu{Nazwa="Zwiększenie masy mięśniowej"},
            new RodzajPlanu{Nazwa="Poprawa sylwetki"},
            new RodzajPlanu{Nazwa="Poprawa kondycji"},
            new RodzajPlanu{Nazwa="Przygotowanie do testów funkcjonalnych"}
            };
            rodzaje.ForEach(r => context.RodzajPlanus.Add(r));
            context.SaveChanges();

            var users = new List<Trener> {
                 new Trener{UserName=user.UserName,Imie="Hubert",Nazwisko="Firek",Wiek=23,LiczbaMaksPodopiecznych=15,Numerkonta="30254323058471537285928523"},
            new Trener{UserName=user7.UserName,Imie="Jan",Nazwisko="Marecki",Wiek=32,LiczbaMaksPodopiecznych=2,Numerkonta="30254323058471537285928523"},
              new Trener{UserName=user6.UserName,Imie="Michał",Nazwisko="Wiśniewski",Wiek=46,LiczbaMaksPodopiecznych=23,Numerkonta="30254323058471537285928523"},
                new Trener{UserName=user5.UserName,Imie="Joanna",Nazwisko="Gac",Wiek=21,LiczbaMaksPodopiecznych=7,Numerkonta="30254323058471537285928523"},
                  new Trener{UserName=user4.UserName,Imie="Adam",Nazwisko="Wiejski",Wiek=25,LiczbaMaksPodopiecznych=4,Numerkonta="30254323058471537285928523"},
       };
            users.ForEach(r => context.Treners.Add(r));
            context.SaveChanges();
            var podop = new List<Podopieczny> {
            new Podopieczny{UserName=user1.UserName,Imie="Andrzej",Nazwisko="Zapała",Wiek=47,TrenerID=users[3].ID},
              new Podopieczny{UserName=user2.UserName,Imie="Adrianna",Nazwisko="Kowalska",Wiek=51, TrenerID=users[3].ID},
                new Podopieczny{UserName=user3.UserName,Imie="Tomasz",Nazwisko="Andrus",Wiek=71,TrenerID=users[0].ID}
            };
            podop.ForEach(r => context.Podopiecznies.Add(r));
            context.SaveChanges();



        }
    }
}