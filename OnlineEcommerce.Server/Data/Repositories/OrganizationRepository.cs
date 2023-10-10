using Microsoft.EntityFrameworkCore;
using OnlineEcommerce.Server.Data.Repositories.Contracts;

namespace OnlineEcommerce.Server.Data.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _db;

        public OrganizationRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<int> GetById(string name)
        {
            var organization = await _db.Organizations.FirstOrDefaultAsync
                                                        (x => x.Name == name);

            return organization.Id;
        }
    }
}
