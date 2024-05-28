using RedCloud.Domain.Comman;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class AdminUser : AuditableEntity
    {
        [Key]
        public int ID { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string Email { get; set; }


        public string MobileNumber { get; set; }


        public string? Password { get; set; }

        

        public bool IsActive { get; set; }

        
    }

    
}
