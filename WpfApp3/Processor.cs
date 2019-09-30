using Newtonsoft.Json;
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
       
       
        public async static Task<Product> LoadIformation()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);

            using (HttpResponseMessage response = await httpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    RootObject result = await response.Content.ReadAsAsync<RootObject>();

                    return result.Response[0];
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


       /* public MainWindow()
        {
            InitializeComponent();

            string URL = "https://www.contractor.de/api/?action=getJobsList&type=undefined&keyword";

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);

            var answer = client.GetAsync(URL).Result;

            var JSON = answer.Content.ReadAsStringAsync().Result;





            var UVs = JsonConvert.DeserializeObject<RootObject>(JSON);

            this.datagrid_Uvs.ItemsSource = UVs.Response;
        }*/
    }
}

