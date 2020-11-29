using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class ZakresPowtorzen
    {
        public int Id { get; set; }
        public int IloscPowtorzen { get; set; }
        public virtual Cwiczenie Cwiczenies { get; set; }
    }
}