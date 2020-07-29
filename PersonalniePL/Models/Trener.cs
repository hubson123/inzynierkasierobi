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
        [Required]
        [Display(Name = "Imie")]
        [StringLength(35, MinimumLength = 2)]
        public String Imie { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        [StringLength(35, MinimumLength = 2)]
        public String Nazwisko { get; set; }
        [Required]
        [Display(Name = "Wiek")]
        public int Wiek { get; set; }
        [Required]
        [Display(Name = "Liczba Podopiecznych")]
        public int LiczbaMaksPodopiecznych { get; set; }
        [Display(Name = "Podopieczni")]
        public virtual ICollection<Podopieczny> Podopiecznies { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<Wiadomosc> Wiadomosci { get; set; }
        [Required]
        [Display(Name = "Numer konta")]
        public string Numerkonta { get; set; }


    }
}