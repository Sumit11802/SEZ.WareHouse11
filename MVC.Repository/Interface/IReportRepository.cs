using MVC.Domain.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Interface
{
    public interface IReportRepository
    {

        DataTable FetchCustomerList(int category, DateTime? fromdate, DateTime? todate);
        DataTable FetchUserList(int category, DateTime? fromdate, DateTime? todate);
    }
}
