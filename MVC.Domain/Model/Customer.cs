using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
	public class CUSTOMER
	{
		public long CUSTOMER_ID { get; set; }
		public string EMAIL_ID { get; set; }
		public int CONTACT_NO { get; set; }
		public string TYPE_OF_KYC { get; set; }
		public string REGESTRATION_TYPE { get; set; }
		public string GST_No { get; set; }
		public string COMPANY_NAME { get; set; }
		public string ADDRESS { get; set; }
		public string LOCATION { get; set; }
		public long PIN_CODE { get; set; }
		public string STATE { get; set; }
		public string PAN_NO { get; set; }
		public string TYPE_OF_ORGANISATION { get; set; }
		public string ACCOUNT_NAME { get; set; }
		public string ACCOUNT_NUMBER { get; set; }
		public string ACCOUNT_TYPE { get; set; }
		public string IFSC_CODE { get; set; }
		public string NAME { get; set; }
		public string DESIGNATION { get; set; }
		public string MOBILE_NO { get; set; }
		public string TAN_NO { get; set; }
    }
}