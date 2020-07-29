using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Wiadomosc
    {
        public int Id { get; set; }
        [Display(Name = "Trener")]
        public int TrenerID { get; set; }
        [Display(Name = "Podopieczny")]
        public int PodopiecznyID { get; set; }
        public string Tresc { get; set; }
        public virtual Trener Treners { get; set; }
        public virtual Podopieczny Podopiecznies { get; set; }

    }
}