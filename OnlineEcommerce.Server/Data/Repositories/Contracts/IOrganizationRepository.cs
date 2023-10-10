namespace OnlineEcommerce.Server.Data.Repositories.Contracts
{
    public interface IOrganizationRepository
    {
        Task<int> GetById(string name);
    }
}
