using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Cwiczenie
    {
        public int Id { get; set; }
        public int TrenerID { get; set; }
       public virtual Trener Trener { get; set; }
        public virtual ICollection<PlanKreator> PlanKreator { get; set; }
        public string NazwaCwiczenia { get; set; }
        public int IloscSerii { get; set; }
        public  int ZakresPowtorzen { get; set; }
        public  string CzasPrzerwy { get; set; }
        public double SkalaRpes { get; set; }
        public int TempoPracy { get; set; }
    }
}