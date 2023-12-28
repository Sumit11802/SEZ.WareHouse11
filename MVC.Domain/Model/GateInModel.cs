using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
	public class GateInModel
	{
		public long GATE_PASS_NO { get; set; }

		public DateTime IN_DATE_TIME { get; set; }

		public string CONTATINER_NAME { get; set; }

		public string CONTATINER_NO { get; set; }

		public int SIZE { get; set; }

		public double TYPE { get; set; }

		public string CARGO_TYPE { get; set; }

		public string PKGS { get; set; }

		public string WEIGHT { get; set; }

		public string VEHICLE_NO { get; set; }

		public string TRANSPORTER { get; set; }

		public string DRIVER_NAME { get; set; }

		public DateTime EIR_DATE_TIME { get; set; }

		public string SCAN_STATUS { get; set; }

		public string SCAN_TYPE { get; set; }

		public bool REMARKS { get; set; }

		public int ADDED_BY { get; set; }
	}
}
