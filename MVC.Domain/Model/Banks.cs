using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class Banks
    {
        [Key]
        public int Id { get; set; }
        public string BankName { get; set; }
        public string ShortCode { get; set; }
        public string IFSCCode { get; set; }
        public bool IsIMPS { get; set; }
        public bool IsNEFT { get; set; }
        public bool IsRTGS { get; set; }
        public bool IsCancel { get; set; }
        public bool IsActive { get; set; }
        public bool IsDown { get; set; }
        public long? AddedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
    public class Customer
    {
        public int AGID { get; set; }
        public string AGName { get; set; }
        public int GSTuniqueid { get; set; }
        public string GstuniqueName { get; set; }
        public int CHAID { get; set; }
        public string CHAName { get; set; }
        public string CHACode { get; set; }
        public int shipperID { get; set; }
        public string shippername { get; set; }
        public string PortName { get; set; }
        public string PortID { get; set; }
        public string BerthingDate { get; set; }
        public string Voyage { get; set; }
        public string Shipper_IEC_No { get; set; }
        public string balance { get; set; }
        public string entryNo { get; set; }
        public string WeighmentMachine { get; set; }


        public int ITemID { get; set; }
        public string Item_Descriptions { get; set; }
    }
}
