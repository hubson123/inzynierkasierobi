using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Plan
    {
        public int Id { get; set; }
        [Display(Name = "Trener")]
        public int TrenerID { get; set; }
        [Display(Name = "Podopieczny")]
        public int PodopiecznyID { get; set; }
        [Display(Name = "Rodzaj")]
        public int RodzajPlanuID { get; set; }
        public double Cena { get; set; }
        public virtual Trener Trener { get; set; }
        public virtual Podopieczny Podopieczny { get; set; }
        public virtual RodzajPlanu RodzajPlanu { get; set; }
        public string Plik { get; set; }


    }
}