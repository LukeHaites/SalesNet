using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesNet.Models;
using System.Xml.Linq;
using System.Net.Http;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace SalesNet.Helpers
{
    public class APIReader
    {
        private const string BASE_URL = "http://luke7/wholesaleapi/";
        private const string ENDPOINT = "orders";
        private const string QUERYPARAMS = "?requestpersonid=101031&pageRows=2&startrow=1";

        public static Orders GetOrders()
        {
            var XmlStreamTask = ReadXmlAsync();
            XmlStreamTask.Wait();
            return ParseOrders(XmlStreamTask.Result);
        }

        private static async Task<System.IO.Stream> ReadXmlAsync()
        {
            string Url = string.Concat(BASE_URL, ENDPOINT, QUERYPARAMS);

            try
            {
                var Client = new HttpClient();
                System.IO.Stream UrlContents = await Client.GetStreamAsync(Url);
            }
            catch { }
            return null;
        }

        private static Orders ParseOrders(System.IO.Stream XmlStream)
        {
            if (XmlStream == null) return null;

            XmlSerializer Serializer = new XmlSerializer(typeof(Orders));
            return (Orders)Serializer.Deserialize(XmlStream);
        }
    }
}