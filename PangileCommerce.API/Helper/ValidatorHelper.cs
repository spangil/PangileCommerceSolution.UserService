// PSEUDOCODE / PLAN:
// 1. Create a static helper class `ValidatorHelper` inside `HelperFolder` namespace.
// 2. Expose a public async method `ValidateAsync<T>` that accepts:
//    - IServiceProvider serviceProvider  (to resolve the validator)
//    - T model                           (the model to validate)
//    - ControllerBase controller         (to return IActionResult helpers like BadRequest)
// 3. Inside the method:
//    - Resolve IValidator<T> from the service provider.
//    - If no validator is registered, return null (signal "no validation performed").
//    - Run validator.ValidateAsync(model).
//    - If validation fails, return controller.BadRequest(result.Errors).
//    - If validation succeeds, return null.
// 4. This helper centralizes validation logic so controllers can call it and return the IActionResult if non-null.

using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace PangileCommerce.API.Helper
{
    public static class ValidatorHelper
    {
        /// <summary>
        /// Validates a model using an IValidator{T} resolved from the provided service provider.
        /// Returns an IActionResult (BadRequest) when validation fails, otherwise returns null.
        /// </summary>
        public static async Task<IActionResult?> ValidateAsync<T>(IServiceProvider serviceProvider, T model, ControllerBase controller)
        {
            if (serviceProvider is null) throw new ArgumentNullException(nameof(serviceProvider));
            if (controller is null) throw new ArgumentNullException(nameof(controller));

            var validator = serviceProvider.GetService<IValidator<T>>();
            if (validator is null) return null;

            var result = await validator.ValidateAsync(model);
            if (!result.IsValid) return controller.BadRequest(result.Errors);

            return null;
        }
    }
}