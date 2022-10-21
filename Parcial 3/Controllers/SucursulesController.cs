using Newtonsoft.Json;
using Parcial_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Parcial_3.Controllers
{
    public class SucursulesController : Controller
    {
        // GET: Sucursules
        string Baseurl = "http://localhost:61212/api/branchoffice/";
        public async Task<ActionResult> Index()
        {
            List<SucursalesModel> sucursales = new List<SucursalesModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    sucursales = JsonConvert.DeserializeObject<List<SucursalesModel>>(EmpResponse);

                }
                return View(sucursales);
            }
        }

        public ActionResult Create() {
            return View();
        }
        public async Task<ActionResult> CreatePost(string name_branch, int active)
        {
            try
            {
                SucursalesModel EmpInfo = new SucursalesModel();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    SucursalesModel sucursal = new SucursalesModel();
                    sucursal.name_branch = name_branch;
                    sucursal.active = active;
                    var myContent = JsonConvert.SerializeObject(sucursal);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage Res = await client.PostAsync(Baseurl, byteContent);
                    if (Res.IsSuccessStatusCode)
                    {
                        return Content("1");
                    }
                    return Content("0");
                }

            }
            catch (Exception ex)
            {
                return Content("Error de aplicativo" + ex.Message);
            }

        }

        public async Task<ActionResult> Update(int id)
        {
            SucursalesModel sucursal = new SucursalesModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + id);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    sucursal = JsonConvert.DeserializeObject<SucursalesModel>(EmpResponse);
                    ViewBag.name = sucursal.name_branch;
                    ViewBag.id = id;
                    ViewBag.active = sucursal.active;
                }
                return View();
            }
        }
        public async Task<ActionResult> UpdatePost(string name_branch, int active, int id)
        {
            try
            {
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl + id);
                    client.DefaultRequestHeaders.Clear();
                    SucursalesModel sucursal = new SucursalesModel();
                    sucursal.name_branch = name_branch;
                    sucursal.active = active;
                    sucursal.id_branch = id;
                    var myContent = JsonConvert.SerializeObject(sucursal);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpResponseMessage Res = await client.PutAsync(Baseurl, byteContent);
                    if (Res.IsSuccessStatusCode)
                    {
                        return Content("1");
                    }
                    return Content("0 * " + Res);
                }

            }
            catch (Exception ex)
            {
                return Content("Error de aplicativo" + ex.Message);
            }

        }
    }
}