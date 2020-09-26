using Merchants.Web.Models;
using System;
using System.Collections.Generic;

namespace Merchants.Web.Extensions
{
    public static class EnumExtensions
    {
        public static List<EnumValue> GetValues<T>()
        {
            List<EnumValue> values = new List<EnumValue>();
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                //For each value of this enumeration, add a new EnumValue instance
                values.Add(new EnumValue()
                {
                    Name = Enum.GetName(typeof(T), itemType),
                    Id = (int)itemType
                });
            }
            return values;
        }
    }
}
