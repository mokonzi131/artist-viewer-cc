using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Config
{
    public class ClientCaching
    {
        public string CacheControlHeader { get; set; } = "max-age-3600";
        public string PragmaHeader { get; set; } = "cache";
        public string ExpiresHeader { get; set; } = null;
    }
}
