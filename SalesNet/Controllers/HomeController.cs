using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesNet.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SalesNet.Helpers;

namespace SalesNet.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Persons model = null;
            var Client = new HttpClient();
            var GetTask = Client.GetAsync("http://luke7/wholesaleapi/persons")
                .ContinueWith((TaskWithResponse) =>
                {
                    XmlSerializer Serializer = new XmlSerializer(typeof(Persons));

                    var Response = TaskWithResponse.Result;
                    var ReadTask = Response.Content.ReadAsStreamAsync();
                    ReadTask.Wait();
                    model = (Persons)Serializer.Deserialize(ReadTask.Result);
                });
            GetTask.Wait();
            return View(model.PersonList);
        }

        public ActionResult Orders()
        {
            Orders model = APIReader.GetOrders();
            return View(model);
        }
        
        public ActionResult PickCustomer()
        {
            return View();
        }

        public async Task<ActionResult> Person()
        {
            ViewBag.url = "http://v-iis64-test/CI_WholesaleAPI2014_V2.3_Latest/persons?email=salesnetagent1@apparel21.com";
            
            using (HttpClient httpClient = new HttpClient())
            {
                ViewBag.persondata = await httpClient.GetStringAsync(ViewBag.url);
            }

            return View();
        }
    }
}
