using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.BusinessLogic.Helpers
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public int ExpireMinutes { get; set; } = 60;
    }
}

