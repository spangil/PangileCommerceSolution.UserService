using Microsoft.Extensions.DependencyInjection;
using PangileCommerce.Core.ServiceContracts;
using PangileCommerce.Core.Services;
using PangileCommerce.Core.Validators;
using FluentValidation;


namespace PangileCommerce.Core
{
    /// <summary>
    /// Extension method to add core services to the dependency injection container.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //TO DO: Add services to the IoC container
            //Core services often include data access, caching and other low lovel components.
            services.AddTransient<IUsersService, UsersService>();

            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

            return services;
        }
    }
}
