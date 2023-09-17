using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntercambioAdmin.Shared
{
    public static class RestHelper
    {
        private static readonly string baseURL = "https://reqres.in/api/";
        public static async Task<string> GetAll()
        {
            using(HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage res = await client.GetAsync(baseURL + "users"))
                {
                    using(HttpContent contet = res.Content)
                    {
                        string data = await contet.ReadAsStringAsync();
                        if(data != null)
                        {
                            return data;
                        }
                    }
                }
            }

            return string.Empty;

        }
    }
}
