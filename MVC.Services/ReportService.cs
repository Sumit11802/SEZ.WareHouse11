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

using BE = MVC.Domain.Model;

namespace MVC.Services
{
    public class ReportService : IReportService
    {
        ReportRepository  reportRepository = new ReportRepository();

        public DataTable FetchCustomerList(int category, DateTime? from , DateTime? to)
        {
            return reportRepository.FetchCustomerList(category, from, to);
        }

        public DataTable FetchRegularCustomerList(int category, DateTime? from, DateTime? to)
        {
            return reportRepository.FetchRegularCustomerList(category, from, to);
        }

        public DataTable FetchCampaignReport(int category, DateTime? from, DateTime? to)
        {
            return reportRepository.FetchCampaignList(category, from, to);
        }

        public DataTable FetchUserList(int category, DateTime? from, DateTime? to)
        {
            return reportRepository.FetchUserList(category, from, to);
        }

        public int ActionOnUserAccount(int userid, int action)
        {
            return reportRepository.ActionOnUserAccount(userid, action);
        }
    }
}
