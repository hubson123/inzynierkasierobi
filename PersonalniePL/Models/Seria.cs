using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Seria
    {
        public int Id { get; set; }
        public int IloscSerii { get; set; }
        public virtual Cwiczenie Cwiczenies { get; set; }
    }
}