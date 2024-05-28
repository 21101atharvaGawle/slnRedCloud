using MediatR;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdmins.Command
{
    public class UpdateResellerAdminCommand : IRequest<BaseResponse<Unit>>
    {
        public int Id { get; set; }

        //  [Required(ErrorMessage = "Reseller name is required")]
        public string ResellerName { get; set; }

        //  [Required(ErrorMessage = "EIN is required")]
        //  [RegularExpression(@"^\d{2}-\d{7}$", ErrorMessage = "Please enter a valid EIN (XX-XXXXXXX)")]
        public string EIN { get; set; }

        //  [Required(ErrorMessage = "Address Line 1 is required")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        // [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        // [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        //  [Required(ErrorMessage = "Zip Code is required")]
        //  [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please enter a valid Zip Code")]
        public string ZipCode { get; set; }

        //  [Required(ErrorMessage = "Company URL is required")]
        //  [Url(ErrorMessage = "Please enter a valid URL")]
        public string CompanyURL { get; set; }

        // [Required(ErrorMessage = "Company Support Email is required")]
        //  [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string CompanySupportEmail { get; set; }

        //      [Required(ErrorMessage = "Red Cloud Admin is required")]
        public string RedCloudAdmin { get; set; }
    }
}
