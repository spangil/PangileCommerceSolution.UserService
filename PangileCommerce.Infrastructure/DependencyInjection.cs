using Microsoft.Extensions.DependencyInjection;
using PangileCommerce.Core.RepositoryContracts;
using PangileCommerce.Infrastructure.DbContext;
using PangileCommerce.Infrastructure.Repositories;


namespace PangileCommerce.Infrastructure
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //TO DO: Add services to th IoC container
            //Infrastructure services often include data access, caching and other low lovel components.

            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<DapperDbContext>();

            return services;
        }
    }
}
