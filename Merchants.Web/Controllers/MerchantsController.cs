﻿using AutoMapper;
using Merchants.Web.Entities;
using Merchants.Web.Extensions;
using Merchants.Web.Filters;
using Merchants.Web.Models;
using Merchants.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Merchants.Web.Controllers
{
    [Route("api/merchants")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMerchantsRepository _merchantsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MerchantsController> _logger;

        public MerchantsController(IMerchantsRepository merchantsRepository,
            IMapper mapper, ILogger<MerchantsController> logger)
        {
            _merchantsRepository = merchantsRepository ??
                throw new ArgumentNullException(nameof(merchantsRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet()]
        [HttpHead]
        [Produces("application/json")]
        public ActionResult<IEnumerable<MerchantDto>> GetMerchants()
        {
            _logger.LogDebug("Start - GetMerchants");

            var merchantsFromRepo = _merchantsRepository.GetMerchants();

            _logger.LogDebug("End - GetMerchants");

            var merchants = new MerchantListDto
            {
                Items = _mapper.Map<IEnumerable<MerchantDto>>(merchantsFromRepo)
            };
            return Ok(merchants);
        }

        [HttpGet("{merchantId}", Name = "GetMerchant")]
        [Produces("application/json")]
        public IActionResult GetMerchant(Guid merchantId)
        {
            _logger.LogDebug($"Start - GetMerchant - {merchantId}");

            var merchantFromRepo = _merchantsRepository.GetMerchant(merchantId);

            if (merchantFromRepo == null)
            {
                _logger.LogWarning($"Couldn't find merchant - {merchantId}");
                return NotFound();
            }

            _logger.LogDebug($"End - GetMerchant - {merchantId}");

            return Ok(_mapper.Map<MerchantDto>(merchantFromRepo));
        }

        [HttpPost]
        [TypeFilter(typeof(ValidateMerchantForManipulation))]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<MerchantDto> CreateMerchant(MerchantForCreationDto merchant)
        {
            _logger.LogDebug(
                $"Start - CreateMerchant - {JsonConvert.SerializeObject(merchant, Formatting.Indented)}");

            var merchantEntity = _mapper.Map<Entities.Merchant>(merchant);
            _merchantsRepository.AddMerchant(merchantEntity);
            _merchantsRepository.Save();

            var merchantToReturn = _mapper.Map<MerchantDto>(merchantEntity);

            _logger.LogDebug($"End - CreateMerchant - {merchantToReturn.Id}");

            return CreatedAtRoute("GetMerchant",
                new { merchantId = merchantToReturn.Id },
                merchantToReturn);
        }

        [HttpPut("{merchantId}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [TypeFilter(typeof(ValidateMerchantId))]
        [TypeFilter(typeof(ValidateMerchantForManipulation))]
        public IActionResult UpdateMerchant(Guid merchantId,
            MerchantForUpdateDto merchant)
        {
            _logger.LogDebug(
                $"Start - UpdateMerchant - {merchantId}," +
                $" {JsonConvert.SerializeObject(merchant, Formatting.Indented)}");

            var merchantFromRepo = _merchantsRepository.GetMerchant(merchantId);

            _mapper.Map(merchant, merchantFromRepo);

            _merchantsRepository.UpdateMerchant(merchantFromRepo);

            _merchantsRepository.Save();

            _logger.LogDebug($"End - UpdateMerchant - {merchantId}");

            return NoContent();
        }

        [HttpDelete("{merchantId}")]
        [TypeFilter(typeof(ValidateMerchantId))]
        public ActionResult DeleteMerchant(Guid merchantId)
        {
            _logger.LogDebug($"Start - DeleteMerchant - {merchantId}");

            var merchantFromRepo = _merchantsRepository.GetMerchant(merchantId);

            _merchantsRepository.DeleteMerchant(merchantFromRepo);

            _merchantsRepository.Save();

            _logger.LogDebug($"End - DeleteMerchant - {merchantId}");

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetMerchantsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST,PUT,DELETE");
            return Ok();
        }

        [HttpGet]
        [Route("statues/all")]
        [Produces("application/json")]
        public IActionResult GetMerchantsStatues()
        {
            return Ok(EnumExtensions.GetValues<MerchantStatus>());
        }

        [HttpGet]
        [Route("countries/all")]
        [Produces("application/json")]
        public IActionResult GetCountries()
        {
            return Ok(_merchantsRepository.GetCountries());
        }

        [HttpGet]
        [Route("currencies/all")]
        [Produces("application/json")]
        public IActionResult GetCurrencies()
        {
            return Ok(_merchantsRepository.GetCurrencies());
        }
    }
}
