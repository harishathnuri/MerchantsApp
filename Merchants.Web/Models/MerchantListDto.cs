using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.Web.Models
{
    public class MerchantListDto
    {
        public IEnumerable<MerchantDto> Items { get; set; }
    }
}
