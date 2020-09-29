using Merchants.Web.Models;
using Merchants.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace Merchants.Web.Filters
{
    public class ValidateMerchantForManipulation : ActionFilterAttribute
    {
        private readonly IMerchantsRepository _merchantsRepository;
        private readonly ProblemDetailsFactory _problemDetailsFactory;
        private readonly ILogger<ValidateMerchantForManipulation> _logger;

        public ValidateMerchantForManipulation(
            IMerchantsRepository merchantsRepository,
            ProblemDetailsFactory problemDetailsFactory,
            ILogger<ValidateMerchantForManipulation> logger)
        {
            _merchantsRepository = merchantsRepository;
            _problemDetailsFactory = problemDetailsFactory;
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogDebug("Start - OnActionExecuting");

            context.ActionArguments.TryGetValue("merchant", out object merchant);

            var name = (merchant as MerchantForManipulationDto).Name;
            var countryId = (merchant as MerchantForManipulationDto).CountryId;
            var currencyId = (merchant as MerchantForManipulationDto).CurrencyId;

            var merchantFromRepo = _merchantsRepository.GetMerchant(name);
            var country = _merchantsRepository.GetCountry(countryId);
            var currency = _merchantsRepository.GetCurrency(currencyId);

            if (country == null || currency == null 
                || (merchantFromRepo != null && merchantFromRepo.Name == name))
            {
                var modelState = new ModelStateDictionary();
                if ((merchantFromRepo != null && merchantFromRepo.Name == name))
                {
                    modelState.AddModelError("Name", $"Duplicate merchant {name}");
                }
                if (country == null)
                {
                    modelState.AddModelError("CountryId", $"Invalid country id {countryId}");
                }
                if (currency == null)
                {
                    modelState.AddModelError("CurrencyId", $"Invalid currency id {currencyId}");
                }
                var problemDetails = _problemDetailsFactory.CreateValidationProblemDetails(
                                context.HttpContext,
                                modelState);
                problemDetails.Detail = "See the errors field for details.";
                problemDetails.Instance = context.HttpContext.Request.Path;
                problemDetails.Type = "https://merchants.com/modelvalidationproblem";
                problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                problemDetails.Title = "One or more validation errors occurred.";

                context.Result = new UnprocessableEntityObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json" }
                };
            }

            _logger.LogDebug("End - OnActionExecuting");
        }
    }
}
