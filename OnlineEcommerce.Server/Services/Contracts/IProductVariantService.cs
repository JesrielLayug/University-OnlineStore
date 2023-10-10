using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Services.Contracts
{
    public interface IProductVariantService
    {
        Task<bool> AddProductVariant(DTO_AddProductVariant productVariant);
    }
}
