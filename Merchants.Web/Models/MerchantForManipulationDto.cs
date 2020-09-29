using Merchants.Web.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Merchants.Web.Models
{
    public class MerchantForManipulationDto
    {
        [Required(ErrorMessage = "Please enter valid name.")]
        [MaxLength(64, ErrorMessage = "The name shouldn't have more than 64 characters.")]
        public virtual string Name { get; set; }

        public MerchantStatus Status { get; set; }

        [Required(ErrorMessage = "Please enter valid country.")]
        public virtual Guid CountryId { get; set; }

        [MaxLength(256, ErrorMessage = "The website url shouldn't have more than 256 characters.")]
        public virtual string WebsiteUrl { get; set; }

        [Required(ErrorMessage = "Please enter valid currency.")]
        public virtual Guid CurrencyId { get; set; }

        [Required(ErrorMessage = "Please fill discount percentage.")]
        [Range(0, 99.99, ErrorMessage = "Discount percentage should fall between 0 and 99.99.")]
        public virtual double DiscountPercentage { get; set; }
    }
}
