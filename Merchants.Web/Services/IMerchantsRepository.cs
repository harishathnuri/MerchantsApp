using Merchants.Web.Entities;
using System;
using System.Collections.Generic;

namespace Merchants.Web.Services
{
    public interface IMerchantsRepository
    {
        IEnumerable<Merchant> GetMerchants();
        Merchant GetMerchant(Guid merchantId);
        void AddMerchant(Merchant merchant);
        void UpdateMerchant(Merchant merchant);
        void DeleteMerchant(Merchant merchant);
        IEnumerable<Country> GetCountries();
        Country GetCountry(Guid countryId);
        IEnumerable<Currency> GetCurrencies();
        Currency GetCurrency(Guid currencyId);

        bool Save();
    }
}
