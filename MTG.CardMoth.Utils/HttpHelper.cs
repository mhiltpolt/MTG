using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.Utils
{
    public class HttpHelper
    {
        private static HttpClient _client = new HttpClient();

        public async Task<string> GetHttpResponseStringAsync(string uri)
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
                    throw new WebException($"{response.StatusCode} {response.ReasonPhrase} {response.Content}");
                }
            }
        }

        public async Task<byte[]> LoadImage(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            using (HttpResponseMessage response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    Debug.Print(response.StatusCode.ToString());
                    throw new WebException($"{response.StatusCode} {response.ReasonPhrase} {response.Content}");
                }
            }
        }

        public async Task<byte[]> LoadVectorGraphic(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            using (HttpResponseMessage response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    return Encoding.UTF8.GetBytes(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    return new byte[0];
                    //throw new WebException($"{response.StatusCode} {response.ReasonPhrase} {response.Content}");
                }
            }
        }
    }
}
