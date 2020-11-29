using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Tempo
    {
        public int Id { get; set; }
        public int TempoPracy { get; set; }
        public virtual Cwiczenie Cwiczenies { get; set; }

    }
}