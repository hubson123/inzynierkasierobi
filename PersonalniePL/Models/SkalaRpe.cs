using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class SkalaRpe
    {
        public int Id { get; set; }
        public double SkalaRPE { get; set; }
        public virtual Cwiczenie Cwiczenies { get; set; }
    }
}