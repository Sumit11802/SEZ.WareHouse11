using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class Cities
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public bool IsCancel { get; set; }
    }
}
