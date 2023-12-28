using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Interface
{
    public interface IFinanceRepository
    {
        int AddBillingHeadMaster (FINANCE FINANCE);
        //int AddCompanyDetails(CUSTOMER CUSTOMER);
        //int AddBankDetails(CUSTOMER CUSTOMER);
        //int AddCustomerDetails(CUSTOMER CUSTOMER);
    }

    //public interface ICustomerRepository1
    //{
    //    int AddCompanyDetails(CUSTOMER CUSTOMER);
    //}

    //public interface ICustomerRepository2
    //{
    //    int AddBankDetails(CUSTOMER CUSTOMER);
    //}

    //public interface ICustomerRepository3
    //{
    //    int AddCustomerDetails(CUSTOMER CUSTOMER);
    //}
}
