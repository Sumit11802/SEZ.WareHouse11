using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
	public class CampaignDetail
	{
		public int CampaignID { get; set; }
		public string CampaignName { get; set; }
		public int CampaignTypeID { get; set; }
		public int CampaignPriorityID { get; set; }
		public string CampaignManagerID { get; set; }
		public int CampaignAssignedUserID { get; set; }
		public int DistributionTypeID { get; set; }
		public int CampaignStatusID { get; set; }
		public DateTime? CampaignStartDate { get; set; }
		public DateTime? CampaignEndDate { get; set; }
		public int AddedBy { get; set; }
		public DateTime? AddedOn { get; set; }
		public int ModifiedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }
		public bool IsActive { get; set; }
	}
}
