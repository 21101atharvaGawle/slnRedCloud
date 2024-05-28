using RedCloud.Domain.Comman;
using RedCloud.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class RoleMapper: AuditableEntity
    {
        public int RoleMapperId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual User User { get; set; }  
        public virtual Role Role { get; set; }  


    }
}
