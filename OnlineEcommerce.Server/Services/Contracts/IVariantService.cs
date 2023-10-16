using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;

namespace OnlineEcommerce.Server.Services.Contracts
{
    public interface IVariantService
    {
        Task<Response<int>> AddVariant(DTO_Variant variant);
    }
}
