using Merchants.Web.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Merchants.Web.Services
{
    public interface IMerchantsRepository
    {
        Task<IEnumerable<Merchant>> GetMerchants();
        Task<Merchant> GetMerchant(Guid merchantId);
        void AddMerchant(Merchant merchant);
        void UpdateMerchant(Merchant merchant);
        void DeleteMerchant(Merchant merchant);
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(Guid countryId);
        Task<IEnumerable<Currency>> GetCurrencies();
        Task<Currency> GetCurrency(Guid currencyId);

        Task<bool> Save();
    }
}
