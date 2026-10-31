using CarteiraDigital.Application.Validators;
using CarteiraDigital.Core.Models.ViewModel;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace CarteiraDigital.Api.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(c =>
            {
                c.OverrideDefaultResultFactoryWith<CustomResultFactory>();
            });

            services.AddValidatorsFromAssemblyContaining<CadastrarClienteValidator>();

            return services;
        }

        public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
        {
            public Task<IActionResult?> CreateActionResult(
                ActionExecutingContext context,
                ValidationProblemDetails validationProblemDetails,
                IDictionary<IValidationContext, ValidationResult> validationResults)
            {
                IActionResult result = new BadRequestObjectResult(
                    new RespostaPadraoViewModel(
                        context
                            .ModelState
                            .SelectMany(ms => ms.Value?.Errors ?? [])
                            .Select(e => e.ErrorMessage)
                    )
                );

                return Task.FromResult<IActionResult?>(result);
            }
        }
    }
}