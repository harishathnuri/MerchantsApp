using Merchants.Web.DbContexts;
using Merchants.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.Web.Services
{
    public class MerchantsRepository : IMerchantsRepository, IDisposable
    {
        private readonly MerchantContext _context;

        public MerchantsRepository(MerchantContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddMerchant(Merchant merchant)
        {
            if (merchant == null)
            {
                throw new ArgumentNullException(nameof(merchant));
            }
            // the repository fills the id (instead of using identity columns)
            merchant.Id = Guid.NewGuid();

            _context.Merchants.Add(merchant);
        }

        public void DeleteMerchant(Merchant merchant)
        {
            _context.Merchants.Remove(merchant);
        }

        public void UpdateMerchant(Merchant merchant)
        {
            // no code in this implementation
        }

        public Merchant GetMerchant(Guid merchantId)
        {
            return _context.Merchants.FirstOrDefault(a => a.Id == merchantId);
        }

        public Merchant GetMerchant(string name)
        {
            return _context.Merchants.FirstOrDefault(a => a.Name == name);
        }

        public IEnumerable<Merchant> GetMerchants()
        {
            return _context.Merchants.OrderBy(m => m.Name).ToList();
        }

        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountry(Guid countryId)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == countryId);
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            return _context.Currencies.ToList();
        }

        public Currency GetCurrency(Guid currencyId)
        {
            return _context.Currencies.FirstOrDefault(c => c.Id == currencyId);
        }

        public bool Save() => _context.SaveChanges() >= 0;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
