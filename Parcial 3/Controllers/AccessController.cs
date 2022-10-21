using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Parcial_3.Models;

namespace Parcial_3.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        string Baseurl = "http://localhost:61212/api/login/";
        public async Task<ActionResult> Login(string user, string password)
        {
            try
            {
                UserModel EmpInfo = new UserModel();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    LoginModel login = new LoginModel();
                    login.email = user;
                    login.pwd = password;
                    var myContent = JsonConvert.SerializeObject(login);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage Res = await client.PostAsync(Baseurl, byteContent);
                    if (Res.IsSuccessStatusCode)
                    {
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        EmpInfo = JsonConvert.DeserializeObject<UserModel>(EmpResponse);
                        Session["user"] = EmpInfo;
                    }
                    return Content((EmpInfo.type_user).ToString());
                }

            }
            catch (Exception ex)
            {
                return Content("Error de aplicativo" + ex.Message);
            }

        }


    }
}