using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Domain.Model
{
    public class UserRights
    {
        public long UserId { get; set; }
        public string MenuId { get; set; }
        public Boolean IsAccess { get; set; }
        public Boolean CanAdd { get; set; }
        public Boolean CanUpdate { get; set; }
        public Boolean CanCancel { get; set; }
        public Boolean CanView { get; set; }
        public Boolean CanMail { get; set; }
        public string AddedBy { get; set; }
        public string AddedOn { get; set; }

    }
}
