using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
	public class CampaignLead
	{
		public int ID { get; set; }
		public int CampaignID { get; set; }
		public int CustomerID { get; set; }
		public string CustomerName { get; set; }
		public string CustomerFirstName { get; set; }
		public string CustomerLastName { get; set; }
		public string CustomerEmail { get; set; }
		public string ContactNumber { get; set; }
		public string MobileNumber { get; set; }
		public string WhatsappNumber { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public int Age { get; set; }
		public int FamilyCount { get; set; }
		public string Area { get; set; }
		public string Locality { get; set; }
		public string City { get; set; }
		public string PinCode { get; set; }
		public string State { get; set; }
		public string OtherDisease { get; set; }
		public string DiseaseID { get; set; }
		public string SymtompsID { get; set; }
		public int GenderID { get; set; }
		public int DeptID { get; set; }
		public int FinancialID { get; set; }
		public string TreatementAdviceID { get; set; }
		public string WorkingStyleID { get; set; }
		public int PrakrutiParikshanID { get; set; }
		public int MotherTongueID { get; set; }
		public bool IsDoctorSupport { get; set; }
		public int CampaignAssignedTo { get; set; }
		public int CampaignReassignedBy { get; set; }
		public int LeadsStatusID { get; set; }
		public int CallingStatusID { get; set; }
		public int AddedBy { get; set; }
		public DateTime? AddedOn { get; set; }
		public int ModifiedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public bool IsActive { get; set; }

		public string HealthAdvisor { get; set; }
		public string ReferenceProduct { get; set; }
	}
}
