using MVC.Domain.Model;
using MVC.Repository;
using MVC.Repository.Interface;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = MVC.Domain.Model;
using MVC.DB;

namespace MVC.Services
{
    public class MasterService : IMasterService
    {
        DB.CommonService db = new DB.CommonService();

        MasterRepository masterRepository = new MasterRepository();

        public List<SelectListModel> GetContainer_Type()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();


            DataTable dt = masterRepository.GetContainerType();

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "--Select--";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["ContainerTypeID"].ToString());

                    lstModel.Name = Convert.ToString(row["ContainerType"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }


        public List<SelectListModel> GetCargo_Type()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            DataTable dt = masterRepository.GetCargoType();

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "--Select--";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["CargoTypeID"].ToString());

                    lstModel.Name = Convert.ToString(row["CargoType"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }


        public List<SelectListModel> GetImpoerterList()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            DataTable dt = masterRepository.GetImpoerterList();

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["CUSTOMER_ID"].ToString());

                    lstModel.Name = Convert.ToString(row["NAME"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }
        public List<SelectListModel> GetCHAList()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            DataTable dt = masterRepository.GetCHAList();

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["CUSTOMER_ID"].ToString());

                    lstModel.Name = Convert.ToString(row["NAME"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }

        public List<SelectListModel> GetShipperList()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            DataTable dt = masterRepository.GetShipperList();

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["CUSTOMER_ID"].ToString());

                    lstModel.Name = Convert.ToString(row["NAME"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }

        public List<SelectListModel> GetForwarderList()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();

            DataTable dt = masterRepository.GetForwarderList();

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    lstModel.ID = Convert.ToInt32(row["CUSTOMER_ID"].ToString());

                    lstModel.Name = Convert.ToString(row["NAME"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }

        public List<EN.Customer> getAutoExporter(string Prefix, string PayFrom)
        {
            List<EN.Customer> CustomerDL = new List<EN.Customer>();
            DataTable CustomerDT = new DataTable();

            CustomerDT = masterRepository.getAutoExporter(Prefix, PayFrom);
            if (CustomerDT != null)
            {
                if (CustomerDT.Rows.Count > 0)
                {
                    foreach (DataRow row in CustomerDT.Rows)
                    {
                        EN.Customer CustomerList = new EN.Customer();
                        CustomerList.AGID = Convert.ToInt32(row["AGID"]);
                        CustomerList.AGName = Convert.ToString(row["AGName"]);

                        CustomerDL.Add(CustomerList);
                    }
                }
                else
                {
                    EN.Customer CustomerList = new EN.Customer();
                    CustomerList.AGID = 0;
                    CustomerList.AGName = "No Data Found";

                    CustomerDL.Add(CustomerList);
                }

            }
            return CustomerDL;
        }

        public List<SelectListModel> GetWo_Type()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();


            DataTable dt = masterRepository.GetWo_Type();

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();

                    

                    lstModel.Name = Convert.ToString(row["Wo_Type"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }
        public List<EN.TariffEnt> GetTariff()
        {
            List<EN.TariffEnt> TrailerList = new List<EN.TariffEnt>();
            DataTable CustomerDT = new DataTable();
            string Table = "Contract_Master";
            string Column = "ContractID,ContractID";
            string Condition = "";
            string OrderBy = "";

            CustomerDT = masterRepository.GetDropdownList(Table, Column, Condition, OrderBy);
            if (CustomerDT != null)
            {
                foreach (DataRow row in CustomerDT.Rows)
                {
                    EN.TariffEnt Trailers = new EN.TariffEnt();
                    Trailers.entryID = Convert.ToInt32(row["ContractID"]);
                    Trailers.tariffID = Convert.ToString(row["ContractID"]);

                    TrailerList.Add(Trailers);
                }
            }
            return TrailerList;
        }
        public List<EN.TariffEnt> GetSlabID()
        {
            List<EN.TariffEnt> TrailerList = new List<EN.TariffEnt>();
            DataTable CustomerDT = new DataTable();
            string Table = "Contract_SLABS";
            string Column = "entryID,slabid";
            string Condition = "";
            string OrderBy = "slabid";

            CustomerDT = masterRepository.GetDropdownList(Table, Column, Condition, OrderBy);
            if (CustomerDT != null)
            {
                foreach (DataRow row in CustomerDT.Rows)
                {
                    EN.TariffEnt Trailers = new EN.TariffEnt();
                    Trailers.entryID = Convert.ToInt32(row["entryID"]);
                    Trailers.slabid = Convert.ToString(row["slabid"]);

                    TrailerList.Add(Trailers);
                }
            }
            return TrailerList;
        }
        public List<EN.TariffEnt> GetBondCharges()
        {
            List<EN.TariffEnt> TrailerList = new List<EN.TariffEnt>();
            DataTable CustomerDT = new DataTable();
            string Table = "Contract_ChargesMaster";
            string Column = "ChargesID,ChargesBased";
            string Condition = "IsActive =1";
            string OrderBy = "ChargesBased";

            CustomerDT = masterRepository.GetDropdownList(Table, Column, Condition, OrderBy);
            if (CustomerDT != null)
            {
                foreach (DataRow row in CustomerDT.Rows)
                {
                    EN.TariffEnt Trailers = new EN.TariffEnt();
                    Trailers.ChargesID = Convert.ToInt32(row["ChargesID"]);
                    Trailers.ChargesBased = Convert.ToString(row["ChargesBased"]);

                    TrailerList.Add(Trailers);
                }
            }
            return TrailerList;
        }
        public List<EN.TariffEnt> GetBondAccountList()
        {
            List<EN.TariffEnt> TrailerList = new List<EN.TariffEnt>();
            DataTable CustomerDT = new DataTable();
            string Table = "FINANCE_BILLING_HEAD_MASTER";
            string Column = "Charges_Head_ID,Charges_Head";
            string Condition = "";
            string OrderBy = "Charges_Head";

            CustomerDT = masterRepository.GetDropdownList(Table, Column, Condition, OrderBy);
            if (CustomerDT != null)
            {
                foreach (DataRow row in CustomerDT.Rows)
                {
                    EN.TariffEnt Trailers = new EN.TariffEnt();
                    Trailers.AccountID = Convert.ToInt32(row["Charges_Head_ID"]);
                    Trailers.AccountName = Convert.ToString(row["Charges_Head"]);

                    TrailerList.Add(Trailers);
                }
            }
            return TrailerList;
        }
        public List<EN.Location> LocationList()
        {
            List<EN.Location> TrailerList = new List<EN.Location>();
            DataTable CustomerDT = new DataTable();
            string Table = "Ext_Location_M";
            string Column = "LocationID,Location";
            string Condition = "";
            string OrderBy = "Location";

            CustomerDT = masterRepository.GetDropdownList(Table, Column, Condition, OrderBy);
            if (CustomerDT != null)
            {
                foreach (DataRow row in CustomerDT.Rows)
                {
                    EN.Location Trailers = new EN.Location();
                    Trailers.LocationID = Convert.ToInt32(row["LocationID"]);
                    Trailers.LocationName = Convert.ToString(row["Location"]);

                    TrailerList.Add(Trailers);
                }
            }
            return TrailerList;
        }
        public List<EN.CargoType> getCargoType()
        {
            List<EN.CargoType> CargoTypeDL = new List<EN.CargoType>();
            DataTable CargoTypeDT = new DataTable();
            string Table = "CARGO_TYPE";
            string Column = "Cargotypeid,Cargotype";
            string Condition = "";
            string OrderBy = "Cargotype";

            CargoTypeDT = masterRepository.GetDropdownList(Table, Column, Condition, OrderBy);
            if (CargoTypeDT != null)
            {
                foreach (DataRow row in CargoTypeDT.Rows)
                {
                    EN.CargoType CargoTypeList = new EN.CargoType();
                    CargoTypeList.Cargotypeid = Convert.ToInt32(row["Cargotypeid"]);
                    CargoTypeList.Cargotype = Convert.ToString(row["Cargotype"]);
                    CargoTypeDL.Add(CargoTypeList);
                }
            }
            return CargoTypeDL;
        }
        public string SaveBondSlabBL(DataTable dataTable, long UserID, string tariffID)
        {
            string Message = "";
            int id = 0;

         
            Dictionary<object, object> parameterList = new Dictionary<object, object>();

            DataTable dt = new DataTable();
            DataTable dtget = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            string strSQL = "";

            strSQL = "";
            strSQL = "USP_Get_slabid";
            dt = db.getData(strSQL);
            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0]["slabID"]);
            }
            for (int k = 0; k < dataTable.Rows.Count; k++)
            {



                strSQL = "";
                strSQL = "Exec USP_SAVE_BOND_SLAB '" + id + "','" + dataTable.Rows[k].Field<string>("SlabOn") + "','" + dataTable.Rows[k].Field<string>("RangeFrom") + "','" + dataTable.Rows[k].Field<string>("RangeTo") + "','" + dataTable.Rows[k].Field<string>("Value") + "','" + tariffID + "','" + UserID + "'";
                dt1 = db.getData(strSQL);
                if (dt1.Rows.Count > 0)
                {
                    Message = Convert.ToString(dt1.Rows[0]["message"]);
                }
            }
            return Message;
        }
        public List<EN.WareHouse> GetWarehouseData(int WHID, int userId)
        {
            //string message = "";
            int count = 1;
            DataTable Labour = new DataTable();
            DataTable dt1 = new DataTable();
        
            //EN.LabourBillVerification Labourdetails = new EN.LabourBillVerification();
            List<EN.WareHouse> warehousedet = new List<EN.WareHouse>();


            DataTable PortsDS = new DataTable();
            // do like this samjha meko isliye prblm tha thanks
            PortsDS = db.getData("USP_Edit_Warehouse " + WHID + "," + userId + "");
            if (PortsDS.Rows.Count > 0)
            {
                foreach (DataRow row in PortsDS.Rows)
                {
                   WareHouse WHDet = new WareHouse();


                    //EN.WhMasterEnt wHDet = WHDet;
                    WHDet.WHID = Convert.ToInt64(row["WHID"]);
                    WHDet.WHName = Convert.ToString(row["WHName"]);
                    WHDet.Warehouse_Code = Convert.ToString(row["Warehouse_Code"]);
                    WHDet.Series_Code = Convert.ToString(row["Series_Code"]);
                    WHDet.IsActive = Convert.ToString(row["IsActive"]);
                    WHDet.Warehouseadd = Convert.ToString(row["Warehouseadd"]);
                    WHDet.ContactNo = Convert.ToString(row["ContactNo"]);
                    WHDet.Executive = Convert.ToString(row["ExecutiveTitle"]);

                    warehousedet.Add(WHDet);

                }

            }

            return warehousedet;
        }
        public List<Godown> getGodownListForBond()
        {
            List<Godown> warehousedet = new List<Godown>();
            DataTable PortsDT = new DataTable();
            string Table = "GodownM";
            string Column = "EntryID,GodownCode";
            string Condition = "IsActive = 1";
            string OrderBy = "GodownCode";

            PortsDT = masterRepository.GetDropdownList(Table, Column, Condition, OrderBy);
            if (PortsDT != null)
            {
                foreach (DataRow row in PortsDT.Rows)
                {
                    Godown PortsList = new Godown();
                    PortsList.EntryID = Convert.ToInt16(row["EntryID"]);
                    PortsList.GodownCode = Convert.ToString(row["GodownCode"]);

                    warehousedet.Add(PortsList);
                }
            }
            return warehousedet;
        }

        public List<Godown> GetGodownsummary(string search)
        {
            //string message = "";
            int count = 1;
            DataTable Labour = new DataTable();
            DataTable dt1 = new DataTable();
        
            List<Godown> GodownList = new List<Godown>();


            DataTable PortsDS = new DataTable();
            // do like this samjha meko isliye prblm tha thanks
            PortsDS = db.getData("USP_Godown_Summary '" + search + "'");
            if (PortsDS.Rows.Count > 0)
            {
                foreach (DataRow row in PortsDS.Rows)
                {
                    Godown godowndet = new Godown();


                    //EN.WhMasterEnt wHDet = WHDet;
                    godowndet.EntryID = Convert.ToInt32(row["EntryID"]);
                    //godowndet.CentreCode = Convert.ToString(row["CentreCode"]);
                    godowndet.GodownCode = Convert.ToString(row["GodownCode"]);
                    godowndet.Warehousecode = Convert.ToString(row["Warehousecode"]);
                    godowndet.Description = Convert.ToString(row["Warehousedesc"]);

                    godowndet.conscapacity = Convert.ToString(row["conscapacity"]);
                    godowndet.thumbcapacity = Convert.ToString(row["thumbcapacity"]);
                    godowndet.Width = Convert.ToString(row["width"]);
                    godowndet.len = Convert.ToString(row["Lenght"]);
                    godowndet.Height = Convert.ToString(row["height"]);
                    godowndet.Areasqm = Convert.ToString(row["Area_In_SQM"]);
                    godowndet.Areasqft = Convert.ToString(row["Area_In_SQFT"]);
                    godowndet.isActive = Convert.ToString(row["IsActive"]);


                    GodownList.Add(godowndet);

                }

            }



            return GodownList;
        }
        public List<Godown> GetGodwonMasterView(int EntryID, int userId)
        {
            //string message = "";
            int count = 1;
            DataTable Labour = new DataTable();
            DataTable dt1 = new DataTable();
          
            //EN.LabourBillVerification Labourdetails = new EN.LabourBillVerification();
            List<Godown> warehousedet = new List<Godown>();


            DataTable PortsDS = new DataTable();
            // do like this samjha meko isliye prblm tha thanks
            PortsDS = db.getData("USP_Edit_GodownM " + EntryID + "," + userId + "");
            if (PortsDS.Rows.Count > 0)
            {
                foreach (DataRow row in PortsDS.Rows)
                {
                    Godown WHDet = new Godown();


                    //EN.WhMasterEnt wHDet = WHDet;
                    WHDet.EntryID = Convert.ToInt32(row["EntryID"]);
                    WHDet.CentreCode = Convert.ToString(row["CentreCode"]);
                    WHDet.GodownCode = Convert.ToString(row["GodownCode"]);
                    WHDet.Warehousecode = Convert.ToString(row["Warehousecode"]);
                    WHDet.Description = Convert.ToString(row["Warehousedesc"]);
                    WHDet.conscapacity = Convert.ToString(row["conscapacity"]);
                    WHDet.thumbcapacity = Convert.ToString(row["thumbcapacity"]);
                    WHDet.Width = Convert.ToString(row["Width"]);
                    WHDet.Height = Convert.ToString(row["Height"]);
                    WHDet.len = Convert.ToString(row["Lenght"]);
                    WHDet.Areasqm = Convert.ToString(row["Area_In_SQM"]);
                    WHDet.Areasqft = Convert.ToString(row["Area_In_SQFT"]);
                    WHDet.Dateofposs = Convert.ToString(row["Data"]);
                    WHDet.isActive = Convert.ToString(row["IsActive"]);


                    warehousedet.Add(WHDet);

                }

            }


            return warehousedet;
        }
        public EN.Packages GetUpdatePackageMaster(int CodeID)
        {
            EN.Packages data = new EN.Packages();
            DataTable dt = new DataTable();
            dt = masterRepository.GetUpdatePackageMaster(CodeID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.EntryID = Convert.ToInt32(row["CodeID"]);
                    data.PKGCode = Convert.ToString(row["scmtrcode"]);
                    data.PKGSName = Convert.ToString(row["Package"]);
                    data.IsActive = Convert.ToBoolean(row["IsActive"]);
                }
            }
            return data;
        }

        public EN.ResponseMessage SavePKGSDetails(Packages element)
        {
            EN.ResponseMessage message = new EN.ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = masterRepository.SavePKGSDetails(element.EntryID, element.PKGCode, element.PKGSName, element.IsActive, element.AddedBy);
                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.Message = Convert.ToString(row["Message"]);
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }

        public List<EN.WareHouse> GetWarehouseDataForSummary(string search)
        {
            //string message = "";
            int count = 1;
            DataTable Labour = new DataTable();
            DataTable dt1 = new DataTable();
         
            //EN.LabourBillVerification Labourdetails = new EN.LabourBillVerification();
            List<EN.WareHouse> warehousedet = new List<EN.WareHouse>();


            DataTable PortsDS = new DataTable();

            PortsDS = db.getData("USP_search_warehousename '" + search + "'");
            if (PortsDS.Rows.Count > 0)
            {
                foreach (DataRow row in PortsDS.Rows)
                {
                    WareHouse WHDet = new WareHouse();


                    //EN.WhMasterEnt wHDet = WHDet;
                    WHDet.WHID = Convert.ToInt64(row["WHID"]);
                    WHDet.WHName = Convert.ToString(row["WHName"]);
                    WHDet.Warehouse_Code = Convert.ToString(row["Warehouse_Code"]);
                    WHDet.Series_Code = Convert.ToString(row["Series_Code"]);
                    WHDet.IsActive = Convert.ToString(row["IsActive"]);

                    warehousedet.Add(WHDet);

                }
            }

            return warehousedet;
        }



        public List<SelectListModel> EquipmentNoList()
        {
            List<SelectListModel> CustomerDL = new List<SelectListModel>();
            DataTable CustomerDT = new DataTable();

            CustomerDT = masterRepository.EquipmentNoList();
            if (CustomerDT != null)
            {
                if (CustomerDT.Rows.Count > 0)
                {
                    foreach (DataRow row in CustomerDT.Rows)
                    {
                        SelectListModel CustomerList = new SelectListModel();
                        CustomerList.ID = Convert.ToInt32(row["trailerId"]);
                        CustomerList.Name = Convert.ToString(row["trailername"]);

                        CustomerDL.Add(CustomerList);
                    }
                }
                else
                {
                    SelectListModel CustomerList = new SelectListModel();
                    CustomerList.ID = 0;
                    CustomerList.Name = "No Data Found";

                    CustomerDL.Add(CustomerList);
                }

            }
            return CustomerDL;
        }



        public string SaveBinDet(DataTable dataTable, string GodownCode, string CenterCode, string WarehouseCode, string WarehouseD, string chkIsActive, int UserID)
        {
            string Message = "";

            Dictionary<object, object> parameterList = new Dictionary<object, object>();

            DataTable dt = new DataTable();
            DataTable dtget = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();


            for (int k = 0; k < dataTable.Rows.Count; k++)
            {



                string strSQL = "";
                //'"+ GodownCode + "','"+ CenterCode + "','"+ WarehouseCode + "','"+ WarehouseD + "','" + TableData.LotNo + "','" + TableData.Area + "','" + TableData.Height + "','" + TableData.Lenghth + "','" + chkIsActive + "','"+userId+"'
                strSQL = "Exec USP_INSERT_Lot_Save  '" + GodownCode + "','" + CenterCode + "','" + WarehouseCode + "','" + WarehouseD + "' ," + dataTable.Rows[k].Field<string>("LotNo") + "," + dataTable.Rows[k].Field<float>("Area") + ",'" + dataTable.Rows[k].Field<float>("Height") + "','" + dataTable.Rows[k].Field<float>("Lenghth") + "'," + chkIsActive + "," + UserID + "";
                dt = db.getData(strSQL);


                //if (Message == "")
                //{
                //    Message = "Record Saved Successfully!";
                //}


                //Message = Messageget;

            }


            return Message;
        }
        public List<Bin> GetBinSummary(string search)
        {
            //string message = "";
            int count = 1;
            DataTable Labour = new DataTable();
            DataTable dt1 = new DataTable();

            List<Bin> GodownList = new List<Bin>();


            DataTable PortsDS = new DataTable();
            // do like this samjha meko isliye prblm tha thanks
            PortsDS = db.getData("USP_Lot_Summary '" + search + "'");
            if (PortsDS.Rows.Count > 0)
            {
                foreach (DataRow row in PortsDS.Rows)
                {
                    Bin godowndet = new Bin();


                    //EN.WhMasterEnt wHDet = WHDet;
                    godowndet.EntryID = Convert.ToInt32(row["EntryID"]);
                    godowndet.CentreCode = Convert.ToString(row["CentreCode"]);
                    godowndet.GodownCode = Convert.ToString(row["GodownCode"]);
                    godowndet.Warehousecode = Convert.ToString(row["Warehousecode"]);
                    godowndet.Warehousedesc = Convert.ToString(row["Warehousedesc"]);
                    godowndet.LotNo = Convert.ToString(row["LotNo"]);
                    godowndet.Area = Convert.ToInt32(row["Area"]);
                    godowndet.Height = Convert.ToInt32(row["Height"]);
                    godowndet.Lenghth = Convert.ToInt32(row["Lenght"]);
                    godowndet.IsActive = Convert.ToString(row["IsActive"]);


                    GodownList.Add(godowndet);

                }

            }



            return GodownList;
        }


        public List<Bin> GetBinMasterView(int EntryID, int userId)
        {
            //string message = "";
            int count = 1;
            DataTable Labour = new DataTable();
            DataTable dt1 = new DataTable();
        
            //EN.LabourBillVerification Labourdetails = new EN.LabourBillVerification();
            List<Bin> warehousedet = new List<Bin>();


            DataTable PortsDS = new DataTable();
            // do like this samjha meko isliye prblm tha thanks
            PortsDS = db.getData("USP_View_LotM " + EntryID + "," + userId + "");
            if (PortsDS.Rows.Count > 0)
            {
                foreach (DataRow row in PortsDS.Rows)
                {
                    Bin WHDet = new Bin();


                    //EN.WhMasterEnt wHDet = WHDet;
                    WHDet.EntryID = Convert.ToInt32(row["EntryID"]);
                    WHDet.LotNo = Convert.ToString(row["LotNo"]);
                    WHDet.Area = Convert.ToInt64(row["Area"]);
                    WHDet.Lenghth = Convert.ToInt64(row["Lenght"]);
                    WHDet.Height = Convert.ToInt64(row["Height"]);
                    WHDet.CentreCode = Convert.ToString(row["CentreCode"]);
                    WHDet.GodownCode = Convert.ToString(row["GodownCode"]);
                    WHDet.Warehousecode = Convert.ToString(row["Warehousecode"]);
                    WHDet.Warehousedesc = Convert.ToString(row["Warehousedesc"]);
                    WHDet.IsActive = Convert.ToString(row["IsActive"]);

                    warehousedet.Add(WHDet);

                }

            }


            return warehousedet;
        }


        public List<EN.TariffAddDetailsEntites> GetCustomerTariffDetails(DataTable DriverPaymentDT, string TariffID, string AccountingName, Int32 userId)
        {
            //EN.DriverPaymentReco objdriverpaymententities = new EN.DriverPaymentReco();
            List<EN.TariffAddDetailsEntites> DriverPaymentList = new List<EN.TariffAddDetailsEntites>();
            if (DriverPaymentDT != null)
            {
                int count = 1;
                foreach (DataRow row in DriverPaymentDT.Rows)
                {

                    EN.TariffAddDetailsEntites DPDTList = new EN.TariffAddDetailsEntites();
                    DPDTList.TariffID = Convert.ToString(row["Tariff"]);
                    DPDTList.DeliveryType = Convert.ToString(row["Activity"]);
                    DPDTList.From = Convert.ToDateTime(row["From"]).ToString("dd MMM yyyy HH:mm");
                    DPDTList.TO = Convert.ToDateTime(row["To"]).ToString("dd MMM yyyy HH:mm");
                    DPDTList.Accounting = Convert.ToString(row["Account Name"]);
                    DPDTList.Size = Convert.ToString(row["Size"]);
                    DPDTList.Type = Convert.ToString(row["Type"]);
                    DPDTList.Ftype = Convert.ToString("");
                    DPDTList.Slabid = Convert.ToString("");
                    DPDTList.FixedAmt = Convert.ToString(row["Amount"]);
                    DPDTList.Insurance = Convert.ToString(row["Insurance"]);
                    DPDTList.rate = Convert.ToString(row["rate"]);
                    DPDTList.Location = Convert.ToString(row["From Location"]);
                    DPDTList.Tolocation = Convert.ToString(row["To Location"]);

                    DPDTList.Days = Convert.ToString("");

                    DPDTList.Tax = Convert.ToString(row["Tax"]);
                    DPDTList.InvoiceType = Convert.ToString("");
                    DPDTList.CurrencyType = Convert.ToString("");
                    DPDTList.TransType = Convert.ToString("");
                    DPDTList.Port = Convert.ToString("");
                    DPDTList.Freedays = Convert.ToString(row["Free Days"]);

                    DPDTList.Jotype = Convert.ToString("");
                    DPDTList.ScanType = Convert.ToString("");
                    DPDTList.AccountingID = Convert.ToString("");
                    DPDTList.Entryid = Convert.ToString(count++);

                    DriverPaymentList.Add(DPDTList);


                }
            }
            return DriverPaymentList;
        }

        public List<SelectListModel> GetWo_Type1()
        {
            List<SelectListModel> selectListModels = new List<SelectListModel>();


            DataTable dt = masterRepository.GetWo_Type1();

            if (dt != null && dt.Rows.Count > 0)
            {
                SelectListModel lstModel1 = new SelectListModel();
                lstModel1.ID = 0;
                lstModel1.Name = "";
                selectListModels.Add(lstModel1);


                foreach (DataRow row in dt.Rows)
                {
                    SelectListModel lstModel = new SelectListModel();



                    lstModel.Name = Convert.ToString(row["Wo_Type"]);

                    selectListModels.Add(lstModel);

                }
            }
            return selectListModels;
        }
        public string CancelBondTariffBL(DataTable dataTable, long UserID, int type)
        {
            string Message = "";


             
            DataTable dt = new DataTable();
            DataTable dtget = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            string strSQL = "";


            for (int k = 0; k < dataTable.Rows.Count; k++)
            {



                strSQL = "";
                strSQL = "Exec USP_UPDATE_DELETE_TARIFF_DET '" + type + "','" + dataTable.Rows[k].Field<string>("Entryid") + "','" + UserID + "'";
                dt1 = db.getData(strSQL);
                if (dt1.Rows.Count > 0)
                {
                    Message = Convert.ToString(dt1.Rows[0]["message"]);
                }
            }
            return Message;
        }

        public List<WareHouse> getwarehusename()
        {
            List<WareHouse> warehousedet = new List<WareHouse>();
            DataTable PortsDT = new DataTable();
            string Table = "WarehouseM";
            string Column = "WHID,WHName,Warehouse_Code";
            string Condition = "";
            string OrderBy = "WHID";

            PortsDT = masterRepository.GetDropdownList(Table, Column, Condition, OrderBy);
            if (PortsDT != null)
            {
                foreach (DataRow row in PortsDT.Rows)
                {
                    WareHouse PortsList = new WareHouse();
                    PortsList.WHID = Convert.ToInt64(row["WHID"]);
                    PortsList.WHName = Convert.ToString(row["Warehouse_Code"]) + " - " + Convert.ToString(row["WHName"]);

                    warehousedet.Add(PortsList);
                }
            }
            return warehousedet;
        }

        public string AddLocationDetails(EN.LocationMaster MasterData, int userId)
        {
            string Message = "";
            DataTable dt = new DataTable();


         
            Dictionary<object, object> parameterList = new Dictionary<object, object>();


            parameterList.Add("Common_ID", MasterData.Common_ID);
            parameterList.Add("Name", MasterData.Name);
            parameterList.Add("GSTIn_uniqID", MasterData.GSTIn_uniqID);
            parameterList.Add("RegistrationType", MasterData.TyepReg);
            parameterList.Add("RegDate", MasterData.RegDate);
            parameterList.Add("PANNo", MasterData.PANNo);
            parameterList.Add("LocationID", MasterData.LocationID);
            parameterList.Add("State", MasterData.State);
            parameterList.Add("state_Code", MasterData.state_Code);
            parameterList.Add("GSTAddress", MasterData.GSTAddress);
            parameterList.Add("Emailid", MasterData.Emailid);
            parameterList.Add("MobNo", MasterData.MobNo);
            parameterList.Add("userId", userId);
            parameterList.Add("IsCopyID", MasterData.IsCopy);
            parameterList.Add("GSTID", MasterData.GSTID);
            parameterList.Add("PINCODE", MasterData.PINCODE);
            parameterList.Add("Is_Active", MasterData.ISActive);

            int i = db.SaveLocationDetails("USP_LocationGSTInsertDetails", parameterList);


            if (i == 0)
            {
                Message = "Record not save, Please try again!";

            }
            else
            {
                Message = "Recode saved successfully!";
            }
            return Message;
        }

        public string SaveBinDetA(DataTable dataTable, string GridSize, int UserID, string CenterCode, string warehouse, string WD, string tax)
        {
            string Message = "";

            Dictionary<object, object> parameterList = new Dictionary<object, object>();

            DataTable dt = new DataTable();
            DataTable dtget = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();


            for (int k = 0; k < dataTable.Rows.Count; k++)
            {



                string strSQL = "";
                //'"+ GodownCode + "','"+ CenterCode + "','"+ WarehouseCode + "','"+ WarehouseD + "','" + TableData.LotNo + "','" + TableData.Area + "','" + TableData.Height + "','" + TableData.Lenghth + "','" + chkIsActive + "','"+userId+"'
                strSQL = "Exec USP_INSERT_Lot_Save  '','" + tax + "','" + CenterCode + "','" + warehouse + "','" + WD + "','" + dataTable.Rows[k].Field<string>("LotNo") + "','" + dataTable.Rows[k].Field<float>("Area") + "','" + dataTable.Rows[k].Field<float>("Lenghth") + "','" + dataTable.Rows[k].Field<float>("Height") + "','','" + GridSize + "','" + UserID + "'";
                dt = db.getData(strSQL);


                if (Message == "")
                {
                    Message = "Record Saved Successfully!";
                }


                //Message = Messageget;

            }


            return Message;
        }
    }
}
