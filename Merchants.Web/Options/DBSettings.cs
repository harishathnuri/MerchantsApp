using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchants.Web.Options
{
    public class DBSettings
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }

        public override string ToString()
        {
            return $"Server={Server},{Port};Initial Catalog={Database};User ID={User};Password={Password}";
        }
    }
}
