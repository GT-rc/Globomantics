using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobomanticsProductCatalog.Services
{
    public class OrderApiClientConfig
    {
        public string ApiUrl { get; set; }

        public int StoreId { get; set; }

        public string ApiKey { get; set; }
    }
}
