using System;
using System.ComponentModel.DataAnnotations;

namespace Merchants.Web.Entities
{
    public class Merchant
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        public MerchantStatus Status { get; set; }
        [Required]
        public Guid CountryId { get; set; }
        [MaxLength(256)]
        public string WebsiteUrl { get; set; }
        [Required]
        public Guid CurrencyId { get; set; }
        [Required]
        public double DiscountPercentage { get; set; }

        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
