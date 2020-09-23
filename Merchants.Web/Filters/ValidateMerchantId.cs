using Merchants.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace Merchants.Web.Filters
{
    public class ValidateMerchantId : ActionFilterAttribute
    {
        private readonly IMerchantsRepository _merchantsRepository;
        private readonly ILogger<ValidateMerchantId> _logger;

        public ValidateMerchantId(IMerchantsRepository merchantsRepository, ILogger<ValidateMerchantId> logger)
        {
            _merchantsRepository = merchantsRepository;
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogDebug("Start - OnActionExecuting");

            context.ActionArguments.TryGetValue("merchantId", out object primaryKey);
            Guid merchantId = Guid.Parse(primaryKey.ToString());

            var merchantFromRepo = _merchantsRepository.GetMerchant(merchantId);

            if (merchantFromRepo == null)
            {
                context.Result = new NotFoundResult();
            }

            _logger.LogDebug("End - OnActionExecuting");
        }
    }
}
