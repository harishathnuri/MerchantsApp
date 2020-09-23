using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.Web.Profiles
{
    public class MerchantProfile : Profile
    {
        public MerchantProfile()
        {
            CreateMap<Entities.Merchant, Models.MerchantDto>();

            CreateMap<Models.MerchantForCreationDto, Entities.Merchant>();

            CreateMap<Models.MerchantForUpdateDto, Entities.Merchant>();

            CreateMap<Entities.Merchant, Models.MerchantForUpdateDto>();
        }
    }
}
