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
        public string NazwaCwiczenia { get; set; }
        public virtual ICollection<Seria> Serias { get; set; }
        public virtual ICollection<ZakresPowtorzen> ZakresPowtorzens { get; set; }
        public virtual ICollection<Przerwa> Przerwas { get; set; }
        public virtual ICollection<SkalaRpe> SkalaRpes { get; set; }
        public virtual ICollection<Tempo> Tempos { get; set; }
    }
}