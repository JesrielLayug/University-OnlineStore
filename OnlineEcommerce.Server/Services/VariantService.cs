using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Models.DTOs;
using OnlineEcommerce.Server.Services.Contracts;

namespace OnlineEcommerce.Server.Services
{
    public class VariantService : IVariantService
    {
        private readonly IVariantRepository _variant;
        private readonly IVariantAttributeRepository _attribute;

        public VariantService(IVariantRepository variant, IVariantAttributeRepository attribute)
        {
            this._variant = variant;
            this._attribute = attribute;
        }

        public async Task<Response<int>> AddVariant(DTO_AddVariant variant)
        {
            var attribute = await _attribute.GetByName(variant.AttributeName);

            var domainVariant = new Variant
            {
                Value = variant.Value,
                AttributeId = attribute.Id,
            };

            var newVariant = await _variant.AddVariant(domainVariant);
            return new Response<int>
            {
                IsSuccess = true,
                StatusMessage = "Variant successfully added.",
                Data = newVariant
            };
        }
    }
}
