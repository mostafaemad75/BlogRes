using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCulturalBlog.Options
{
    public class ConnectionStringOptions
    {
        public Uri ServiceEndpoint { get; set; }
        public string AuthKey { get; set; }

        public void Deconstruct(out Uri serviceEndpoint, out string authKey)
        {
            serviceEndpoint = ServiceEndpoint;
            authKey = AuthKey;
        }
    }
}
