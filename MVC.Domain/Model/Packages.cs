using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class Packages
    {
        public int EntryID { get; set; }
        public string PKGSName { get; set; }
        public string PKGCode { get; set; }
        public bool IsActive { get; set; }
        public int AddedBy { get; set; }

    }
   
}
