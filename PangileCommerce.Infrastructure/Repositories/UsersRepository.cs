using Dapper;
using PangileCommerce.Core.DTO;
using PangileCommerce.Core.Entities;
using PangileCommerce.Core.RepositoryContracts;
using PangileCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace PangileCommerce.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        string query = "INSERT INTO public. \"Users\"(\"UserID\", \"Email\", \"PersonName\",\"Gender\",\"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";

        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if(rowCountAffected > 0) return user;
        else return null; 
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        var parameters = new { Email = email, password = password };
        string query = "SELECT * FROM public. \"Users\" where \"Email\" = @Email and \"Password\" = @Password";
        ApplicationUser? user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        return user;

        //return new ApplicationUser
        //{
        //    UserID = Guid.NewGuid(),
        //    Email = email,
        //    Password = password,
        //    PersonName = "John Doe",
        //    Gender = GenderOptions.Male.ToString()
        //};
    }
}

