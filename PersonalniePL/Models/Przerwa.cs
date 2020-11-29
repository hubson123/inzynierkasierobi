using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Przerwa
    {
        public int Id { get; set; }
        public string CzasPrzerwy { get; set; }
        public virtual Cwiczenie Cwiczenies { get; set; }
    }
}