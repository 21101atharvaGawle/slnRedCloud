using RedCloud.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Comman
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Role> Roles { get; set;}
    }
}
