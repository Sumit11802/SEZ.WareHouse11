using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public partial class SelectListModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class CustomFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string MemberID { get; set; }
        public string Filter { get; set; }
    }
    public class CargoType
    {
        public int Cargotypeid { get; set; }
        public string Cargotype { get; set; }
    }
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }
    public class TariffEnt
    {
        public int entryID { get; set; }
        public string tariffID { get; set; }
        public string slabid { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public int ChargesID { get; set; }
        public string ChargesBased { get; set; }
        public string bondtype { get; set; }
        public string effectivefrom { get; set; }
        public string effectiveupto { get; set; }
        public string AccountHead { get; set; }
        public string size { get; set; }
        public float FixedAmount { get; set; }
        public bool IsTax { get; set; }
        public bool OnDelivered { get; set; }
        public bool ConsiderArea { get; set; }
        public int Location { get; set; }
        public int AddedBy { get; set; }
        public int CargoTypeID { get; set; }
        public int IsInternal { get; set; }

        public string TariffDescription { get; set; }
        public string SORF { get; set; }

        public bool IsApproved { get; set; }
        public float AgreedAmount { get; set; }
        public string CargoType { get; set; }
        public string qty { get; set; }
        public string taxID { get; set; }
        public float profomaAmount { get; set; }
        public float Rate { get; set; }
    }
    public class WorkOrderEntities
    {
        public string Wo_Type { get; set; }
        public string CHAName { get; set; }
        public int Vendor { get; set; }
        public int CHAID { get; set; }
        public int OnAccountID { get; set; }
        public int Id { get; set; }
        public int WHID { get; set; }
        public int SBEntryID { get; set; }
        public string SBNo { get; set; }
        public string Type { get; set; }
        public string GroupCode { get; set; }

        public string ShipperName { get; set; }
        public string OnAccount { get; set; }
        public string ManifestQty { get; set; }
        public string CargoDescription { get; set; }
        public decimal TotPkgs { get; set; }
        public decimal TotWeight { get; set; }
        public decimal UnitWt { get; set; }
        public decimal PrevPkgs { get; set; }
        public decimal ContPrevPkgs { get; set; }
        public int Pallets { get; set; }
        public int Shifts { get; set; }
        public bool IsStax { get; set; }


        public string StuffLocation { get; set; }
        public string ContainerNo { get; set; }
        public int WareHouseID { get; set; }
        public string VehicleNo { get; set; }
        public decimal StuffPkgs { get; set; }
        public int VendorID { get; set; }
        public int EquipmentID { get; set; }
        public string EquipmentNo { get; set; }
        public string Description { get; set; }
        public int PkgTypeID { get; set; }
        public string Weight { get; set; }
        public float Rate { get; set; }
        public float Qty { get; set; }
        public int Unit { get; set; }
        public int CartingAllowId { get; set; }
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string CargoType { get; set; }
        public string Size { get; set; }
        public int EntryId { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string RequestTo { get; set; }
        public double AcountToCollect { get; set; }
        public string Narration { get; set; }
        public string PackageType { get; set; }
        public string WoNo { get; set; }
        public string WoDate { get; set; }
        public string SrNo { get; set; }
        public string Hours { get; set; }
        public string CMB { get; set; }
        public long JoNo { get; set; }
        public string IGMNo { get; set; }
        public string ItemNo { get; set; }
        public double ExamPerc { get; set; }
        public double Amount { get; set; }

        public string OpPkgs { get; set; }
        public string OpWt { get; set; }
        public string Examine { get; set; }
        public string Surveyor { get; set; }
        public string CartingAllowNo { get; set; }
        public string RequestID { get; set; }
        public string Activity { get; set; }
        public string Close { get; set; }
        public string ItemDesc { get; set; }
        public string VendorType { get; set; }
        public string ServiceType { get; set; }
        public string VendorName { get; set; }
        public double Rate_Amt { get; set; }
        public double Amt { get; set; }
        public double Quantity { get; set; }

        public string PortalWoNo { get; set; }

        public int PortalAccountId { get; set; }

        public int ContainerTypeID { get; set; }
        public string ContainerTypeName { get; set; }



        //public WorkOrderEntities()
        //{
        //    Narration = "";
        //    WOTypeList = new List<WOTypeEntities>();
        //    WHList = new List<WarehouseEntities>();
        //    VendorWOList = new List<VendorWOEntities>();
        //    EQWOList = new List<EquipmentWOEntities>();
        //    EQWONoList = new List<EquipmentWONoEntities>();
        //    PKGList = new List<PackageWOEntities>();
        //    ExportAccountMasterList = new List<ExportAccountMaster>();
        //    VendorMasterList = new List<VendorMaster>();
        //    ImportAccountMasterList = new List<ImportAccountMaster>();
        //    BondAccountMasterList = new List<BondAccountMaster>();
        //    EmptyAccountMasterList = new List<EmptyAccountMaster>();
        //    CHAList = new List<CHA>();
        //    containerSizesList = new List<ContainerSize>();
        //    containerTypesList = new List<ContainerType>();
        //    cargoTypesList = new List<CargoType>();
        //    commodityGroupsList = new List<CommodityGroup>();

        //}
        //public List<WOTypeEntities> WOTypeList { get; set; }
        //public List<WarehouseEntities> WHList { get; set; }
        //public List<VendorWOEntities> VendorWOList { get; set; }
        //public List<EquipmentWOEntities> EQWOList { get; set; }
        //public List<EquipmentWONoEntities> EQWONoList { get; set; }
        //public List<PackageWOEntities> PKGList { get; set; }
        //public List<ExportAccountMaster> ExportAccountMasterList { get; set; }
        //public List<VendorMaster> VendorMasterList { get; set; }
        //public List<SurveyorMaster> SurveyorMasterList { get; set; }
        //public List<ImportAccountMaster> ImportAccountMasterList { get; set; }
        //public List<BondAccountMaster> BondAccountMasterList { get; set; }
        //public List<EmptyAccountMaster> EmptyAccountMasterList { get; set; }
        //public List<CHA> CHAList { get; set; }
        //public List<ContainerSize> containerSizesList { get; set; }
        //public List<ContainerType> containerTypesList { get; set; }
        //public List<CargoType> cargoTypesList { get; set; }
        //public List<CommodityGroup> commodityGroupsList { get; set; }


    }
    public class CommodityGroup
    {
        public int Commodity_Group_ID { get; set; }
        public string Commodity_Group_Name { get; set; }
    }
    public class ContainerType
    {
        public int ContainerTypeID { get; set; }
        public string ContainerTypeName { get; set; }
    }
    public class ContainerSize
    {
        public int ContainerSizeID { get; set; }
        public string ContainerSizeName { get; set; }
    }
    public class CHA
    {
        public string CHANo { get; set; }
        public string CHAName { get; set; }
    }
    public class WOTypeEntities
    {
        public string Wo_Type { get; set; }
    }
    public class WarehouseEntities
    {
        public int WHID { get; set; }

        public string WHName { get; set; }
    }
    public class VendorWOEntities
    {
        public int VendorId { get; set; }

        public string Name { get; set; }
    }
    public class EquipmentWOEntities
    {
        public int Id { get; set; }

        public string Equipment { get; set; }


    }
    public class EquipmentWONoEntities
    {
        public int Id { get; set; }

        public string Equipment { get; set; }


    }
    public class EquipmentNoEnt
    {
        public int trailerid { get; set; }
        public string EquipmentNo { get; set; }
    }
    public class VehicleWOEntities
    {
        public string CartingId { get; set; }
        public string VehicleNo { get; set; }
    }
    public class ContainerWOEntities
    {
        public string ContainerNo { get; set; }
    }
    public class PackageWOEntities
    {
        public int CodeID { get; set; }
        public string Package { get; set; }
    }
    public class ExportAccountMaster
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
    }
    public class ImportAccountMaster
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
    }

    public class BondAccountMaster
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
    }
    public class EmptyAccountMaster
    {
        public int AccountID { get; set; }
        public string AccountName { get; set; }
    }
    public class VendorMaster
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
    }
    public class SurveyorMaster
    {
        public int SurveyorID { get; set; }
        public string SurveyorName { get; set; }
    }
    public class CHAMaster
    {
        public int CHAID { get; set; }
        public string CHAName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string FaxNumber { get; set; }
        public string CellNumber { get; set; }
        public string eMailIDs { get; set; }
        public string Remarks { get; set; }
        public string Addedby { get; set; }
        public bool IsActive { get; set; }
        public string CHACode { get; set; }
        public string CHANo { get; set; }
        public string errorMessage { get; set; }
        public int AGID { get; set; }
        public string AGName { get; set; }
    }
    public class SlabDetailsEntites
    {
        public string SlabOn { get; set; }
        public string RangeFrom { get; set; }
        public string RangeTo { get; set; }
        public string Value { get; set; }
        public string SlabSize { get; set; }
        public string SlabCargoType { get; set; }
        public string SRNo { get; set; }
        public string Location { get; set; }
        public string Entryid { get; set; }
        public string FixedValue { get; set; }
        public string EffectiveFrom { get; set; }
        public string EffectiveTo { get; set; }
        public string AccountHeadName { get; set; }
        public string AccountHeadID { get; set; }
        public string DeliveryType { get; set; }
        public string RebateD { get; set; }
        public string Jotype { get; set; }
        public string InvoiceType { get; set; }

    }
    public class TariffAddDetailsEntites
    {
        public string TariffID { get; set; }
        public string DeliveryType { get; set; }
        public string From { get; set; }
        public string TO { get; set; }
        public string Accounting { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string FixedAmt { get; set; }
        public string Days { get; set; }
        public string rate { get; set; }
        public string ChargesBased { get; set; }
        public string Slabid { get; set; }
        public string ScanType { get; set; }
        public string Location { get; set; }
        public string StuffLocation { get; set; }
        public string Jotype { get; set; }
        public string Commodity { get; set; }
        public string TransType { get; set; }
        public string Port { get; set; }
        public string Ftype { get; set; }
        public string Insurance { get; set; }
        public string Tax { get; set; }
        public string InvoiceType { get; set; }
        public string CurrencyType { get; set; }
        public string Scan { get; set; }
        public string Freedays { get; set; }
        public string AccountingID { get; set; }
        public string username { get; set; }
        public string Entryid { get; set; }
        public string Approved { get; set; }
        public string DeliveryType11 { get; set; }
        public string Type1 { get; set; }
        public string Tolocation { get; set; }
        public string IsSplit { get; set; }
        public string trailertype { get; set; }

        public string RebateD { get; set; }
        public string AgreedAmt { get; set; }
        public string EditEntryID { get; set; }
        public string AccountHeadName { get; set; }

        public string SlabOn { get; set; }
        public string FromSlab { get; set; }
        public string Toslab { get; set; }
    }
    public class ImportTariffSetting
    {
        public int SrNo { get; set; }
        public int CHAID { get; set; }
        public string CHAName { get; set; }
        public string JOType { get; set; }
        public int JOTypeID { get; set; }
        public string AccountName { get; set; }
        public int AccountNameID { get; set; }
        public string size { get; set; }
        public int sizeID { get; set; }
        public string DeliveryType { get; set; }
        public int DeliveryTypeID { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public decimal LevyAmt { get; set; }
        public decimal RebateAmt { get; set; }
        public decimal AgreedRate { get; set; }
        public decimal FromSlab { get; set; }
        public decimal ToSlab { get; set; }
        public int isActive { get; set; }
        public int LineID { get; set; }
        public int CustomerID { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public DateTime AddedOn { get; set; }
        public int CommodityID { get; set; }
        public string CommodityName { get; set; }
        public decimal Rate { get; set; }
        public int EntryID { get; set; }
        public string SorF { get; set; }
        public string ContractName { get; set; }
        public string CustomerName { get; set; }
        public string ImporterName { get; set; }
        public string LineName { get; set; }
        public string SalesPerson { get; set; }
        public string TariffGroup { get; set; }
        public string DisplayEffectiveFrom { get; set; }
        public string DisplayEffectiveTo { get; set; }
        public string AnnualValue { get; set; }
        public string AnnualTueSupport { get; set; }
        public string CreditLimit { get; set; }
        public string CreditDays { get; set; }
        public int ImporterID { get; set; }
        public int SalesPersonID { get; set; }
        public int TariffGroupID { get; set; }
        public string Message { get; set; }
        public int FreeDays { get; set; }
        public int FreeRebateDays { get; set; }
        public string NotFoundHead { get; set; }
        public string SLabType { get; set; }
        public string RebatePartyName { get; set; }
        public string RebateTo { get; set; }
        public int RebatePartyID { get; set; }
        public int InvoiceTypeID { get; set; }
        public string TaxID { get; set; }
        public string TariffID { get; set; }
        public string CargoSpecification { get; set; }
        public string AttachmentLink { get; set; }
        public string NotFoundSLab { get; set; }

    }
    public class TariffDescription
    {

        public int TarifID { get; set; }
        public string TDName { get; set; }

        public string deliveryType { get; set; }
        public string containerType { get; set; }
        public string accounthead { get; set; }
        public int EntryID { get; set; }


    }
}
