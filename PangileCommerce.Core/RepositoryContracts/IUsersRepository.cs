using PangileCommerce.Core.Entities;


namespace PangileCommerce.Core.RepositoryContracts;

    public interface IUsersRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }

