using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
	public class FINANCE
	{
		public long CUSTOMER_ID { get; set; }
		public string HSN_CODE { get; set; }
		public string HSN_DESCRIPTION { get; set; }
		public double HSN_TAX_GROUP_ID { get; set; }
	}
    public class GSTEntities
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string ContactNo2 { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPerson2 { get; set; }

        public string CHA { get; set; }
        public string Shipper { get; set; }
        public string ShippingLine { get; set; }
        public string Importer { get; set; }
        public string Customer { get; set; }
        public string Vendor { get; set; }

    }
    public class DocList
    {
        public int DocID { get; set; }

        public string DocName { get; set; }
    }
    public class MasterEntities
    {
        public DateTime ExpireDate { get; set; }
        public DateTime AgreementDate { get; set; }
        public string IECNO { get; set; }
        public string NSDLID { get; set; }
        public Int64 AGID { get; set; }
        public string AGaID { get; set; }
        public string AGName { get; set; }
        public string AGAddress { get; set; }
        public string AGCity { get; set; }
        public string AGAuthPerson { get; set; }
        public string AGAuthPersonDesig { get; set; }
        public string AGAuthPersonDesigII { get; set; }
        public string AGTelI { get; set; }
        public string AGTelII { get; set; }
        public string AGFax { get; set; }
        public string AGCellNo { get; set; }
        public string AGAuthPersonII { get; set; }
        public string AGEMail { get; set; }
        public string AGEMailII { get; set; }
        public string AGWebsite { get; set; }
        public int CreditPeriod { get; set; }
        public string AGRemarks { get; set; }
        public bool IsActive { get; set; }
        public int Addedby { get; set; }
        public string AGGrade { get; set; }
        public string Business { get; set; }
        public bool IsContract { get; set; }

        public bool CHA { get; set; }
        public bool shippers { get; set; }
        public bool ShipLines { get; set; }
        public bool Importer { get; set; }
        public bool Customer { get; set; }
        public string TallyLedger { get; set; }
        public bool JV { get; set; }
        public bool Vendor { get; set; }
        public bool IsFreightForwarder { get; set; }
        public string LineAgentCode { get; set; }
        public string CHACode { get; set; }


        public int RunningID { get; set; }
        public string DocFileName { get; set; }
        public int srno { get; set; }


    }
    public class GST_Registration_Type
    {
        public int RGID { get; set; }

        public string RGType { get; set; }
    }
    public class Ext_location_Master
    {

        public int LocationID { get; set; }

        public string Location { get; set; }

        public int addedby { get; set; }

        public DateTime addedon { get; set; }

        public bool isactive { get; set; }

        public float Km { get; set; }

        public long GSTID { get; set; }
    }
    public class StateMaster
    {
        public long State_ID { get; set; }

        public string State_Code { get; set; }

        public string State { get; set; }

        public int AddedBy { get; set; }

        public DateTime AddedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public char TIN_Number { get; set; }
         
    }
    public class LocationMaster
    {
        public long GSTID { get; set; }

        public string GSTName { get; set; }

        public string GSTAddress { get; set; }

        public string State { get; set; }

        public string state_Code { get; set; }

        public string GSTIn_uniqID { get; set; }

        public string PANNo { get; set; }

        public string TANNo { get; set; }

        public string Partytype { get; set; }

        public long PartyTypeID { get; set; }

        public int AddedBy { get; set; }

        public DateTime AddedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string Emailid { get; set; }

        public string MobNo { get; set; }

        public DateTime RegDate { get; set; }

        public string TyepReg { get; set; }

        public bool ISRegistration { get; set; }

        public string Remarks { get; set; }

        public string LegalName { get; set; }

        public bool IsApproved { get; set; }

        public int ApprovedBy { get; set; }

        public DateTime ApprovedOn { get; set; }

        public long LedgerID { get; set; }
        public int Common_ID { get; set; }
        public string Name { get; set; }
        public int LocationID { get; set; }

        public string GSTregDate { get; set; }
        public int RGID { get; set; }
        public string Location { get; set; }

        public int IsCopy { get; set; }
        public string PINCODE { get; set; }
        public string ISActive { get; set; }
    }

    public class LocationM
    {
        public string Location { get; set; }

        public int ID { get; set; }

        public int DistanceGroupID { get; set; }
        public int LocationGroupID { get; set; }
        public string OnWayKM { get; set; }
        public string TwoWayKM { get; set; }
        public string KiloMeter { get; set; }
    }
}