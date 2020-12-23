using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalniePL.Models
{
    public class Notka
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Tresc { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? datautworzenia { get; set; }
        public int MyProperty { get; set; }
    }
}