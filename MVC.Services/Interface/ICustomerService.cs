using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interface
{
    public interface ICustomerService
    {
        int AddCustomerEntry(CUSTOMER CUSTOMER);
    }


    public interface ICustomerService1
    {
        int AddCompanyDetails(CUSTOMER CUSTOMER);
    }


    public interface ICustomerService2
    {
        int AddBankDetails(CUSTOMER CUSTOMER);
    }


    public interface ICustomerService3
    {
        int AddCustomerDetails(CUSTOMER CUSTOMER);
    }
}
