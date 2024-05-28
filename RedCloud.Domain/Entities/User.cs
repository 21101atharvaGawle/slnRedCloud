using RedCloud.Domain.Comman;
using System.ComponentModel.DataAnnotations;

namespace RedCloud.Models.Account
{
        public class User : AuditableEntity
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
           
        }
}
