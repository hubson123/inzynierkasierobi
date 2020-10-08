using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Notka
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Tresc { get; set; }
        public DateTime? datautworzenia { get; set; }
    }
}