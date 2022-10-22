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
    public class UserController : Controller
    {
        // GET: User
        string Baseurl = "http://localhost:61212/api/user/";
        public async Task<ActionResult> Index()
        {
            List<UserModel> userList = new List<UserModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userList = JsonConvert.DeserializeObject<List<UserModel>>(EmpResponse);

                }
                return View(userList);
            }
        }

        public async Task<ActionResult> Create()
        {
            string departmentURL = "http://localhost:61212/api/usertype/";
            List<UserTypeModel> departmentList = new List<UserTypeModel>();
            using (var department = new HttpClient())
            {
                department.BaseAddress = new Uri(departmentURL);
                department.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await department.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    departmentList = JsonConvert.DeserializeObject<List<UserTypeModel>>(EmpResponse);
                    ViewBag.UserType = departmentList;
                }
            }
            return View();
        }

        public async Task<ActionResult> CreatePost(string names, string email, string pwd, int active, int type_user)
        {
            try
            {
                UserModel EmpInfo = new UserModel();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    UserModel usuario = new UserModel();
                    usuario.names = names;
                    usuario.email = email;
                    usuario.pwd = pwd;
                    usuario.type_user = type_user;
                    usuario.active = active;
                    var myContent = JsonConvert.SerializeObject(usuario);
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
            string departmentURL = "http://localhost:61212/api/usertype/";
            List<UserTypeModel> departmentList = new List<UserTypeModel>();
            using (var department = new HttpClient())
            {
                department.BaseAddress = new Uri(departmentURL);
                department.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await department.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    departmentList = JsonConvert.DeserializeObject<List<UserTypeModel>>(EmpResponse);
                    ViewBag.UserType = departmentList;
                }
            }

            UserModel sucursal = new UserModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + id);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync("");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    sucursal = JsonConvert.DeserializeObject<UserModel>(EmpResponse);
                    ViewBag.name = sucursal.names;
                    ViewBag.id = id;
                    ViewBag.active = sucursal.active;
                    ViewBag.idType= sucursal.type_user;
                    ViewBag.Email = sucursal.email;
                }
                return View();
            }
        }


    }
}