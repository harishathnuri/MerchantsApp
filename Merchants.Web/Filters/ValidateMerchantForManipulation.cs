using Merchants.Web.Models;
using Merchants.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace Merchants.Web.Filters
{
    public class ValidateMerchantForManipulation : ActionFilterAttribute
    {
        private readonly IMerchantsRepository _merchantsRepository;
        private readonly ILogger<ValidateMerchantForManipulation> _logger;

        public ValidateMerchantForManipulation(
            IMerchantsRepository merchantsRepository, ILogger<ValidateMerchantForManipulation> logger)
        {
            _merchantsRepository = merchantsRepository;
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogDebug("Start - OnActionExecuting");

            context.ActionArguments.TryGetValue("merchant", out object merchant);

            var countryId = (merchant as MerchantForManipulationDto).CountryId;
            var currencyId = (merchant as MerchantForManipulationDto).CurrencyId;

            var country = _merchantsRepository.GetCountry(countryId);
            var currency = _merchantsRepository.GetCurrency(currencyId);

            if (country == null || currency == null)
            {
                var modelState = new ModelStateDictionary();
                if (country == null)
                {
                    modelState.AddModelError("CountryId", $"Invalid country id {countryId}");
                }
                if (currency == null)
                {
                    modelState.AddModelError("CurrencyId", $"Invalid currency id {currencyId}");
                }
                var badRequestResult = new BadRequestObjectResult(modelState);
                context.Result = badRequestResult;
            }
            
            _logger.LogDebug("End - OnActionExecuting");
        }
    }
}
