using OnlineEcommerce.Server.Data.Repositories.Contracts;
using OnlineEcommerce.Server.Models;
using OnlineEcommerce.Server.Services.Contracts;

namespace OnlineEcommerce.Server.Services
{
    public class VariantAttributeService : IVariantAttributeService
    {
        private readonly IVariantAttributeRepository _attribute;

        public VariantAttributeService(IVariantAttributeRepository attribute)
        {
            this._attribute = attribute;
        }

        public async Task<IEnumerable<VariantAttribute>> GetAll()
        {
            var attributes = await _attribute.GetAttributes();
            return attributes;
        }
    }
}
