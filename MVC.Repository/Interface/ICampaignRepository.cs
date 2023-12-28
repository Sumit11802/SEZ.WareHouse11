using MVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Interface
{
    public interface ICampaignRepository
    {
        DataTable AddCampaignDetails(CampaignDetail campaign);
        DataTable AddCampaignLeadDetails(CampaignLead campaign);
    }
}
