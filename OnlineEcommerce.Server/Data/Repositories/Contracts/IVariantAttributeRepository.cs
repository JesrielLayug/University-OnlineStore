using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IVariantAttributeRepository
    {
        Task<IEnumerable<VariantAttribute>> GetAttributes();
        Task<VariantAttribute> GetByName(string name);
        Task<int> AddAttribute(VariantAttribute variantAttribute);
    }
}
