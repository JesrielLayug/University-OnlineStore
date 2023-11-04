using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<int> GetById(string name);
    }
}
