using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Podopieczny
    {
        public int ID { get; set; }
        public int TrenerID { get; set; }

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
        public virtual ICollection<Plan> Plan { get; set; }
        public virtual Trener Trener { get; set; }
        public virtual ICollection<Wiadomosc> Wiadomosc { get; set; }

    }
}