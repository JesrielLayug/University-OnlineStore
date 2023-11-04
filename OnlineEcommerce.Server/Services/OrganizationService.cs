using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;

namespace OnlineEcommerce.Server.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organization;

        public OrganizationService(IOrganizationRepository _organization)
        {
            organization = _organization;
        }
        public async Task<IEnumerable<DTO_Organization>> GetAll()
        {
            try
            {
                var dtoOrganizations = await organization.GetAll();

                List<DTO_Organization> domainOrganizatons = new List<DTO_Organization>();
                domainOrganizatons.Add(new DTO_Organization
                {
                    Id = 0,
                    Name = "All"
                });
                foreach (var item in dtoOrganizations)
                {
                    domainOrganizatons.Add(new DTO_Organization
                    {
                        Id = item.Id,
                        Name = item.Name,
                    });
                }

                return domainOrganizatons;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
