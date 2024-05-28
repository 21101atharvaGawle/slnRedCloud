using RedCloud.Domain.Entities;

namespace RedCloud.Interface
{
    public interface IOrganizationAdminService
    {
        Task<int> CreateOrganizationAdmin(OrganizationAdmin organizationAdmin);
    }
}
