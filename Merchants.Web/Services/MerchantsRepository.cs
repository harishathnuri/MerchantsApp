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

        public Task<Merchant> GetMerchant(Guid merchantId)
        {
            return _context.Merchants.FirstOrDefaultAsync(a => a.Id == merchantId);
        }

        public async Task<IEnumerable<Merchant>> GetMerchants()
        {
            return await _context.Merchants.OrderBy(m => m.Name).ToListAsync();
        }

        public void UpdateMerchant(Merchant merchant)
        {
            // no code in this implementation
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountry(Guid countryId)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);
        }

        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> GetCurrency(Guid currencyId)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.Id == currencyId);
        }

        public async Task<bool> Save() => ((await _context.SaveChangesAsync()) >= 0);

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
