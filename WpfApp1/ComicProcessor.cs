using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ComicProcessor

    {
        //public int MaxComicNumber { get; set; }

        public async static Task<ComicModel> LoadCimic(int comicNumber = 0)
        {
            string url = "";
            if (comicNumber>0)
            {
                url = $"https://xkcd.com/ {comicNumber} /info.0.json"; 
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }

            using (HttpResponseMessage response=await APIHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();

                   /* if (comicNumber==0)
                    {
                        MaxComicNumber = comic.Num;
                        
                    }*/
                    return comic;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }  
    }
}
