using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.ApiCaller.Tools
{
    internal class HttpHelper
    {
        private static HttpClient _client = new HttpClient();

        internal async Task<string> GetHttpResponseStringAsync(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            using (HttpResponseMessage response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"{response.StatusCode} {response.ReasonPhrase} {response.Content}");
                }
            }
        }

        internal async Task<Byte[]> LoadImage(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            using (HttpResponseMessage response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    MemoryStream imageStream = new MemoryStream();
                    await response.Content.CopyToAsync(imageStream);
                    return imageStream.ToArray();
                }
                else
                {
                    throw new Exception($"{response.StatusCode} {response.ReasonPhrase} {response.Content}");
                }
            }
        }
    }
}
