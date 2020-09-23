using System;
using System.ComponentModel.DataAnnotations;

namespace Merchants.Web.Entities
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
