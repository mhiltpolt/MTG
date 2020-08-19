using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MTG.CardMoth.ApiCaller.Tools
{
    internal class ImageLoader
    {
        private HttpHelper _httpHelper => new HttpHelper();

        internal Task<Byte[]> LoadFromUriAsync(string uri, EImageType imageType)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(uri) && imageType == EImageType.VectorGraphic)
                {
                    return _httpHelper.LoadVectorGraphic(uri);
                }
                else if (!string.IsNullOrWhiteSpace(uri) && imageType == EImageType.Image)
                {
                    return _httpHelper.LoadImage(uri);
                }
                else
                {
                    return new Task<byte[]>(() => { return new byte[0]; });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
