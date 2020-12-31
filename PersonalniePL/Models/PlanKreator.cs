using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class PlanKreator
    {
        public int Id { get; set; }
        [Display(Name = "Trener")]
        public int TrenerID { get; set; }
        [Display(Name = "Podopieczny")]
        public int PodopiecznyID { get; set; }
        [Display(Name = "Rodzaj")]
        public int RodzajPlanuID { get; set; }
        public int CwiczenieID { get; set; }
        public int Cwiczenie1ID { get; set; }
        public int Cwiczenie2ID { get; set; }
        public int Cwiczenie3ID { get; set; }
        public int Cwiczenie4ID { get; set; }
        public int Cwiczenie5ID { get; set; }
        public virtual Cwiczenie Cwiczenies { get; set; }
        public virtual Cwiczenie Cwiczenies1 { get; set; }
        public virtual Cwiczenie Cwiczenies2 { get; set; }
        public virtual Cwiczenie Cwiczenies3 { get; set; }
        public virtual Cwiczenie Cwiczenies4 { get; set; }
        public virtual Cwiczenie Cwiczenies5 { get; set; }
        public virtual RodzajPlanu RodzajPlanus { get; set; }
        public virtual Trener Trener { get; set; }
        public virtual Podopieczny Podopieczny { get; set; }
        public double Cena { get; set; }
        public bool Zablokowany { get; set; }
    }
}