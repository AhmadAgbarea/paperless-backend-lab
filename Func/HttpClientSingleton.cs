using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Func
{
    public static class HttpClientSingleton
    {
        public static readonly HttpClient Instance;

        static HttpClientSingleton()
        {
            Instance = new HttpClient();
        }
    }
}
