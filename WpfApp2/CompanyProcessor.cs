using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class CompanyProcessor
    {
        static HttpClient client = new HttpClient();

       

        static async Task<Uri> CreateProductAsync(CatidModel product)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<CatidModel> GetProductAsync(string path)
        {
            CatidModel product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<CatidModel>();
            }
            return product;
        }

        static async Task<CatidModel> UpdateProductAsync(CatidModel product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{product.Catid}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            product = await response.Content.ReadAsAsync<CatidModel>();
            return product;
        }

        

      /* static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }*/

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://www.onecard.am/api/company/read/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                CatidModel product = new CatidModel
                {
                    Catid = 47,
                    Sessstr = "EB0522D3-0E48-392F-73EE-83685A080A92",


                };

                var url = await CreateProductAsync(product);
              

                // Get the product
                product = await GetProductAsync(url.PathAndQuery);
                

                // Update the product
                
                product.Catid = 46;
                await UpdateProductAsync(product);

                // Get the updated product
                product = await GetProductAsync(url.PathAndQuery);
              

                // Delete the product
              

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
}
