using Merchants.Web.Entities;
using System;
using System.Collections.Generic;

namespace Merchants.Web.DbContexts
{
    public class SeedData
    {
        public static List<Country> Countries
        {
            get
            {
                return new List<Country>
                {
                    new Country
                    {
                        Id = new Guid("eef7fb91-f2a4-42d2-9c7d-e30ab7cdfd44"),
                        Name = "Australia"
                    },
                    new Country
                    {
                        Id = new Guid("2288f577-e965-4727-bd28-7a5cf2247f5d"),
                        Name = "New Zealand"
                    },
                    new Country
                    {
                        Id = new Guid("a81f1301-903b-45ca-840c-533077523af5"),
                        Name = "India"
                    },
                    new Country
                    {
                        Id = new Guid("4c0907f9-2c5f-4d3e-bc5d-ce5c49dc66b8"),
                        Name = "USA"
                    },
                    new Country
                    {
                        Id = new Guid("def5f724-7794-4299-810c-0c5b2d89c7dd"),
                        Name = "Great Britain"
                    }
                };
            }
        }

        public static List<Currency> Currencies
        {
            get 
            {
                return new List<Currency>
                {
                    new Currency
                    {
                        Id = new Guid("038e3b65-ffdf-4f23-8767-ee2f079eb160"),
                        Name = "AUD"
                    },
                    new Currency
                    {
                        Id = new Guid("aac9e06c-aa9d-4e6a-9a1a-ef7189daf38f"),
                        Name = "NZD"
                    },
                    new Currency
                    {
                        Id = new Guid("590e1142-81f9-4691-a379-c6ff97f21bbc"),
                        Name = "INR"
                    },
                    new Currency
                    {
                        Id = new Guid("a3fced19-470b-43f3-913f-b77e1abc3ae7"),
                        Name = "USD"
                    },
                    new Currency
                    {
                        Id = new Guid("d1577738-f7e4-4565-9f1d-901daf6669b6"),
                        Name = "GBP"
                    }
                };
            }
        }
    }
}
