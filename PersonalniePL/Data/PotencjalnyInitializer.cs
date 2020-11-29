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
    public class PersonalnyInitializer : DropCreateDatabaseIfModelChanges<PersonalnyContext>
    {
        protected override void Seed(PersonalnyContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            roleManager.Create(new IdentityRole("Adminek"));
            roleManager.Create(new IdentityRole("Trener"));
            roleManager.Create(new IdentityRole("Podopieczny"));

            var user = new ApplicationUser { UserName = "hubert.firek@o2.pl", Email = "hubert.firek@o2.pl" };
            string pass = "zaq1@WSX";
            string pass1 = "B@rdzotrudnehaslo123";
            userManager.Create(user, pass1);
            userManager.AddToRole(user.Id, "Adminek");
            userManager.AddToRole(user.Id, "Trener");
            var user1 = new ApplicationUser { UserName = "mikoa@o34.pl", Email = "mikoa@o34.pl" };

            userManager.Create(user1, pass);
            userManager.AddToRole(user1.Id, "Podopieczny");
            var user2 = new ApplicationUser { UserName = "troll@o34.pl", Email = "troll@o34.pl" };

            userManager.Create(user2, pass);
            userManager.AddToRole(user2.Id, "Podopieczny");
            var user3 = new ApplicationUser { UserName = "fog@o34.pl", Email = "fog@o34.pl" };
    
            userManager.Create(user3, pass);
            userManager.AddToRole(user3.Id, "Podopieczny");
            var user4 = new ApplicationUser { UserName = "Balion@o34.pl", Email = "Balion@o34.pl" };
        
            userManager.Create(user4, pass);
            userManager.AddToRole(user4.Id, "Trener");
            var user5 = new ApplicationUser { UserName = "amigo@o34.pl", Email = "amigo@o34.pl" };
        
            userManager.Create(user5, pass);
            userManager.AddToRole(user5.Id, "Trener");
            context.SaveChanges();
            var user6 = new ApplicationUser {UserName = "markow@o34.pl", Email = "markow@o34.pl" };
         
            userManager.Create(user6, pass);
            userManager.AddToRole(user6.Id, "Trener");
            var user7 = new ApplicationUser { UserName = "mrio@o34.pl", Email = "mrio@o34.pl" };
            userManager.Create(user7, pass);
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
                  new Trener{UserName=user4.UserName,Imie="Adam",Nazwisko="Wiejski",Wiek=25,LiczbaMaksPodopiecznych=0,Numerkonta="30254323058471537285928523"},
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
            string datat = "Dec 23 2019";
            DateTime d = DateTime.Parse(datat);
            string datat2 = "Dec 12 2019";
            DateTime d2 = DateTime.Parse(datat2);
            var notki = new List<Notka> {
            new Notka{UserName=user2.UserName,datautworzenia=d,Tresc="Jest świetnie oby tak dalej"},
            new Notka{UserName=user1.UserName,datautworzenia=d,Tresc="Wow schudłem 3 kilo"},
            new Notka{UserName=user5.UserName,datautworzenia=d,Tresc="Kozaaaaak"},
            new Notka{UserName=user3.UserName,datautworzenia=d,Tresc="Miałem tydzięń załamania ale wracam na właściwe tory"},
            new Notka{UserName=user2.UserName,datautworzenia=d2,Tresc="Będzie dobrze jestem dobrej myśli"}
            };
            notki.ForEach(r => context.Notkas.Add(r));
            context.SaveChanges();
        }
    }
}