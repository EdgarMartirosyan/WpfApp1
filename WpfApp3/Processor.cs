using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Processor
    {
        static HttpClient client = new HttpClient();


       /* static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }*/

        public static async Task<Product> LoadInfo()
        {
            HttpResponseMessage response = await client.GetAsync("https://www.contractor.de/api/?action=getJobsList&type=undefined&keyword");
            RootObject result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<RootObject>();
                //
                //   return result.Response[0];
                return result.Response[0];
                
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
            
        }
    }
}
