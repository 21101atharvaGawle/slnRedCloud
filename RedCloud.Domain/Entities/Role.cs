using RedCloud.Domain.Comman;
using System.ComponentModel.DataAnnotations;

namespace RedCloud.Models.Account
{
    public class Role : AuditableEntity
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }  

    }
}
