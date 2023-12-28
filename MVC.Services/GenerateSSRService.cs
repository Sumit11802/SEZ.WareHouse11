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
    public class GenerateSSRService : IGenerateSSRService
    {

        GenerateSSRRepository generatessrRepository = new GenerateSSRRepository();


        public string AddGenerateSSRDetails(GENERATESSR generatessr)
        {
            string result = "";
            try
            {
                DataTable data = new DataTable();
                data = generatessrRepository.AddGenerateSSRDetails(generatessr);
                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        result = Convert.ToString(row["WO_NO"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        int IGenerateSSRService.AddGenerateSSRDetails(GENERATESSR generatessr)
        {
            throw new NotImplementedException();
        }
    }
}
