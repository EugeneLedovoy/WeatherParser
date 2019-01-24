using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parsing
{
    class HtmlLoader
    {
        public string BaseUrl { get; } = "https://www.gismeteo.ru";
        public string Prefix { get; } = "tomorrow/";
        public string FinalLink { get; private set; }
        public string Source { get; private set; }

        public HtmlLoader(string hrefSublink)
        {
            if (!string.IsNullOrEmpty(hrefSublink))
                FinalLink = BaseUrl + hrefSublink + Prefix;
            else
                FinalLink = BaseUrl;
        }

        public async Task<string> GetSourceAsync()
        {
            using (HttpClient client = new HttpClient())
            {


                try
                {
                    HttpResponseMessage response = await client.GetAsync(FinalLink);
                    response.EnsureSuccessStatusCode();

                    if (response != null && response.StatusCode == HttpStatusCode.OK)
                    {
                        Source = await response.Content.ReadAsStringAsync();
                    }
                }

                catch(HttpRequestException h)
                {
                    Console.WriteLine($"Ошибка запроса. \n {h.Message}");
                }
                
                return Source;
            }
        }

    }
}
