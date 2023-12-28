using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interface
{
    public interface IReportService
    {
        DataTable FetchCustomerList(int category, DateTime? from, DateTime? to);
        DataTable FetchUserList(int category, DateTime? from, DateTime? to);
    }
}
