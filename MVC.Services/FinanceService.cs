using MVC.Domain.Model;
using MVC.Repository;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MVC.Services
{
    public class FinanceService : IFinanceService
    {
        FinanceRepository financeRepository = new FinanceRepository();

        public int AddBillingHeadMaster(FINANCE FINANCE)
        {
            throw new NotImplementedException();
        }

        public int AddHSNDetails(FINANCE FINANCE)
        {
            int result = 0;
            try
            {
                DataTable data = new DataTable();
                data = financeRepository.AddBillingHeadMaster (FINANCE );
                if (data != null)
                {
                    result = Convert.ToInt32(data.Rows[0][0].ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //    public int AddCompanyDetails(CUSTOMER CUSTOMER)
        //    {
        //        int result = 0;
        //        try
        //        {
        //            DataTable data = new DataTable();
        //            data = customerRepository.AddCompanyDetails(CUSTOMER);
        //            if (data != null)
        //            {
        //                result = Convert.ToInt32(data.Rows[0][0].ToString());
        //            }
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    public int AddBankDetails(CUSTOMER CUSTOMER)
        //    {
        //        int result = 0;
        //        try
        //        {
        //            DataTable data = new DataTable();
        //            data = customerRepository.AddBankDetails(CUSTOMER);
        //            if (data != null)
        //            {
        //                result = Convert.ToInt32(data.Rows[0][0].ToString());
        //            }
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    public int AddCustomerDetails(CUSTOMER CUSTOMER)
        //    {
        //        int result = 0;
        //        try
        //        {
        //            DataTable data = new DataTable();
        //            data = customerRepository.AddCustomerDetails(CUSTOMER);
        //            if (data != null)
        //            {
        //                result = Convert.ToInt32(data.Rows[0][0].ToString());
        //            }
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}
    }
}
