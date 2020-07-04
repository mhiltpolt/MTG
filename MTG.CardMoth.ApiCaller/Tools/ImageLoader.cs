using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.ApiCaller.Tools
{
    internal class ImageLoader
    {
        internal async Task<Byte[]> LoadFromUriAsync(string uri)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    return string.IsNullOrWhiteSpace(uri) ? new Byte[0] : await client.DownloadDataTaskAsync(uri);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
