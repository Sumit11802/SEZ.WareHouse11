using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class Godown
    {
        public int CategoryID { get; set; }
        public int EntryID { get; set; }
        public string CentreCode { get; set; }
        public string GodownCode { get; set; }
        public string Dateofposs { get; set; }
        public string Warehousecode { get; set; }
        public string Description { get; set; }
        public string conscapacity { get; set; }
        public string thumbcapacity { get; set; }
        public string Width { get; set; }
        public string len { get; set; }
        public string Height { get; set; }
        public string isActive { get; set; }
        public string Areasqm { get; set; }
        public string Areasqft { get; set; }
    }
}
