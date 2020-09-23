using Merchants.Web.Entities;
using System;

namespace Merchants.Web.Models
{
    public class MerchantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public MerchantStatus Status { get; set; }
        public Guid CountryId { get; set; }
        public string WebsiteUrl { get; set; }
        public Guid CurrencyId { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
