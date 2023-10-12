using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Services.Contracts
{
    public interface IVariantAttributeService
    {
        Task<IEnumerable<VariantAttribute>> GetAll(); 
    }
}
