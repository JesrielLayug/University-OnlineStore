using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Services.Contracts
{
    public interface IOrganizationService
    {
        Task<IEnumerable<DTO_Organization>> GetAll();
    }
}
