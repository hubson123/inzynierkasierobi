using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Trener
    {
        public int ID { get; set; }
        public string Avatar { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public String UserName { get; set; }
        
        [Display(Name = "Imie")]
        [StringLength(35, MinimumLength = 2)]
        public String Imie { get; set; }
       
        [Display(Name = "Nazwisko")]
        [StringLength(35, MinimumLength = 2)]
        public String Nazwisko { get; set; }
   
        [Display(Name = "Wiek")]
        public int Wiek { get; set; }
  
        [Display(Name = "Liczba Podopiecznych")]
        public int LiczbaMaksPodopiecznych { get; set; }
        [Display(Name = "Podopieczni")]
        public virtual ICollection<Podopieczny> Podopiecznies { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<PlanKreator> PlanKreators { get; set; }
        public virtual ICollection<Cwiczenie> Cwiczenies { get; set; }
        public virtual ICollection<Wiadomosc> Wiadomosci { get; set; }
    
        [Display(Name = "Numer konta")]
        public string Numerkonta { get; set; }


    }
}