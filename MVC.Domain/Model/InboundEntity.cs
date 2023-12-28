using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
	public class InboundModel
	{
		public long RUNNING_NO { get; set; }
		public string WORK_YEAR { get; set; }
		public string SHIPMENT_NUMBER { get; set; }
		public int INBOUND_TYPE_ID { get; set; }
		public string MODE_CATEGORY { get; set; }
		public string ACTIVITY_TYPE { get; set; }
		public string REQUEST_NO { get; set; }
		public string BOE_NO { get; set; }
		public DateTime BOE_DATE { get; set; }
		public string INVOICE_NO { get; set; }
		public DateTime INVOICE_DATE { get; set; }
		public string TP_NO { get; set; }
		public DateTime TP_DATE { get; set; }
		public string POL { get; set; }
		public string COUNTRY_OF_ORIGIN { get; set; }
		public string BL_NO { get; set; }
		public string HBL_NO { get; set; }
		public string CARGO_DESC { get; set; }
		public double QTY { get; set; }
		public string PACKAGE_TYPE { get; set; }
		public double WEIGHT { get; set; }
		public double DUTY { get; set; }
		public double VALUE { get; set; }
		public long IMPORTER_ID { get; set; }
		public long CHA_ID { get; set; }
		public long CUSTOMER_ID { get; set; }
		public long EXPORTER_ID { get; set; }
		public string IGM_NO { get; set; }
		public DateTime IGM_DATE { get; set; }
		public string ITEM_NO { get; set; }
		public string REMARKS { get; set; }
		 public int ADDED_BY { get; set; }
	}

	public class ContainerDetails
	{
		public long RUNNING_NO { get; set; }
		public string ContainerNo { get; set; }
		public string ContainerSize { get; set; }
		public string ContainerType { get; set; }
		public string CargoType { get; set; }
		public string SealNo { get; set; }
		public string Qty { get; set; }
		public string Weight { get; set; }
		public string TotalAmount { get; set; }
		public string Amount { get; set; }

		public string VehicleNo { get; set; }
		public string EquipmentType { get; set; }
		public string EquipmentNo { get; set; }
	}

}
