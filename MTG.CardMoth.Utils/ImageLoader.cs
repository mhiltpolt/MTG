using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MTG.CardMoth.Utils.Enums;

namespace MTG.CardMoth.Utils
{
    public class ImageLoader
    {
        private HttpHelper _httpHelper => new HttpHelper();

        public async Task<byte[]> LoadFromUriAsync(string uri, EImageType imageType, int retry = 0)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(uri) && imageType == EImageType.VectorGraphic)
                {
                    return await _httpHelper.LoadVectorGraphic(uri);
                }
                else if (!string.IsNullOrWhiteSpace(uri) && imageType == EImageType.Image)
                {
                    return await _httpHelper.LoadImage(uri);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                if (retry > 5)
                {
                    throw new Exception("Failed after 5th retry.", e);
                }
                else
                {
                    Thread.Sleep(new TimeSpan(0, 0, retry * 10));
                    return await LoadFromUriAsync(uri, imageType, retry + 1);
                }
            }
        }
    }
}
