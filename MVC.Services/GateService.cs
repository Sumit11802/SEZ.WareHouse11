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
    public class GateService : IGateService
    {

        GateRepository gateRepository = new GateRepository();


        public int AddGateEntryDetails(GateInModel gateInModel)
        {
            int result = 0;
            try
            {
                DataTable data = new DataTable();
                data = gateRepository.AddGateEntryDetails(gateInModel);
                if (data != null)
                {
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
