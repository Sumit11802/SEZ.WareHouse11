using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class Bin
    {
        public int EntryID { get; set; }
        public string CentreCode { get; set; }
        public string GodownCode { get; set; }
        public string Warehousecode { get; set; }
        public string Warehousedesc { get; set; }
        public string LotNo { get; set; }
        public float Area { get; set; }
        public float Lenghth { get; set; }
        public float Height { get; set; }
        public string IsActive { get; set; }
    }
}
