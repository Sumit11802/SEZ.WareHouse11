using DB = MVC.DB;
using MVC.Domain.Model;
using MVC.Repository;
using MVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
 
 
namespace MVC.Services
{
    public class InboundService 
    {
 
        InBoundRepository inBoundRepository = new InBoundRepository();
 

        private object _commonService;
        public int AddInboundEntry(InboundModel inboundModel)
        {

            string strSQL = "";
            DataTable InsertDL = new DataTable();
            int result = 0;
            try
            {
                DataTable data = new DataTable();
                data = inBoundRepository.AddInboundEntry(inboundModel);

                

                if (data != null)
                {
                    result = 1;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
