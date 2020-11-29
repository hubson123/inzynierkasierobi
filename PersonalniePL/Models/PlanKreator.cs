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
        public virtual ICollection<Cwiczenie> Cwiczenies { get; set; }
        public virtual ICollection<Cwiczenie> Cwiczenies1 { get; set; }
        public virtual ICollection<Cwiczenie> Cwiczenies2 { get; set; }
        public virtual ICollection<Cwiczenie> Cwiczenies3 { get; set; }
        public virtual ICollection<Cwiczenie> Cwiczenies4 { get; set; }
        public virtual ICollection<Cwiczenie> Cwiczenies5 { get; set; }
        public virtual RodzajPlanu RodzajPlanus { get; set; }
        public virtual Trener Trener { get; set; }
        public virtual Podopieczny Podopieczny { get; set; }
        public bool Zablokowany { get; set; }
    }
}