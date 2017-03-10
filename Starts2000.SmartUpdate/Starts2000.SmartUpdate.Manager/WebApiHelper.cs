using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Starts2000.SmartUpdate.Manager
{
    internal static class WebApiHelper
    {
        const string ParamFormater = "&{0}={1}";
        const string FirstParamFormater = "?{0}={1}";

        public static Task<string> GetString(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));
                return client.GetStringAsync(url);
            }
        }

        public static Task<T> GetJsonModel<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = client.GetAsync(url).Result;
                responseMsg.EnsureSuccessStatusCode();
                return responseMsg.Content.ReadAsAsync<T>();
            }
        }

        public static Task<TResult> Post<TModel, TResult>(string url, TModel model)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var responseMsg = client.PostAsJsonAsync<TModel>(url, model).Result;
                responseMsg.EnsureSuccessStatusCode();
                return responseMsg.Content.ReadAsAsync<TResult>();
            }
        }

        static string GetUrl(string url, params KeyValuePair<string, string>[] urlParams)
        {
            StringBuilder urlBuilder = new StringBuilder(512);
            urlBuilder.Append(url);
            bool firstParam = true;

            foreach (var param in urlParams)
            {
                var encodeParam = HttpUtility.UrlEncode(param.Value);
                if (firstParam)
                {
                    urlBuilder.AppendFormat(FirstParamFormater, param.Key, encodeParam);
                    firstParam = false;
                }
                else
                {
                    urlBuilder.AppendFormat(ParamFormater, param.Key, encodeParam);
                }
            }

            return urlBuilder.ToString();
        }
    }
}