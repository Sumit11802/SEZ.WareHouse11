using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string ISOCode { get; set; }
        public string CountryName { get; set; }
        public string Capital { get; set; }
        public bool IsCance { get; set; }
    }
}
