using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Parcial_3.Models.player;
using Parcial_3.Models.LaravelApi;

namespace Parcial_3.Controllers
{
    public class HomeController : Controller
    {

        string Baseurl = "http://localhost:3000/leagues";
        public async Task<ActionResult> Index()
        {
            Root EmpInfo = new Root();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<Root>(EmpResponse);

                }
                return View(EmpInfo);
            }
        }

        string Baseurl2 = "http://ec2-15-223-48-152.ca-central-1.compute.amazonaws.com/api/players";
        public async Task<ActionResult> About()
        {
            List<Playerapi> EmpInfo = new List<Playerapi>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl2);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<List<Playerapi>>(EmpResponse);

                }
                return View(EmpInfo);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}