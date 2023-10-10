using OnlineEcommerce.Server.Models;

namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IVariantRepository
    {
        Task<IEnumerable<Variant>> GetAllVariants();
        Task<int> AddVariant(Variant variant);
    }
}
