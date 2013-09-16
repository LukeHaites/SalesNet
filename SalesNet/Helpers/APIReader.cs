using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesNet.Models;
using System.Xml.Linq;
using System.Net.Http;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace SalesNet.Helpers
{
    public class APIReader
    {
        private const string BASE_URL = "http://luke7/wholesaleapi/";
        private const string ENDPOINT = "orders";
        private const string QUERYPARAMS = "?requestpersonid=101031";

        public static IEnumerable<Order> GetOrders(OrderFilters Filter)
        {
            string FilterString = "&pageRows=" + Filter.PageRows + "&startrow=" + Filter.StartRow;
            Orders model = null;
            XmlSerializer Serializer = new XmlSerializer(typeof(Orders));

            foreach (PropertyInfo prop in typeof(OrderFilters).GetProperties())
            {
                FilterString = (Attribute.IsDefined(prop, typeof(FilterField)) && prop.GetValue(Filter) != null) ? FilterString + "&" + prop.Name + "=" + prop.GetValue(Filter) : FilterString;
            }

            string Url = string.Concat(BASE_URL, ENDPOINT, QUERYPARAMS, FilterString);
            
            //If using Http based
            var Client = new HttpClient();
            var GetTask = Client.GetAsync(Url)
                .ContinueWith((TaskWithResponse) =>
                {
                    var Response = TaskWithResponse.Result;
                    var ReadTask = Response.Content.ReadAsStreamAsync();
                    ReadTask.Wait();
                    model = (Orders)Serializer.Deserialize(ReadTask.Result);
                });
            GetTask.Wait();
            return model.OrderList;
        }
    }
}