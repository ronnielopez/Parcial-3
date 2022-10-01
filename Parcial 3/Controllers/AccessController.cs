using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult Login(string user, string password)
        {
            try
            {
                using (Parcial3Entities db = new Parcial3Entities())
                {
                    //select * from --- >Esto es LINQ
                    // select * from MIS_DATOS as d 
                    var lst = from d in db.users
                              where d.nombre == user && d.pwd == password
                              select d;  //select * from MIS_DATOS
                    if (lst.Count() > 0)
                    {
                        user oUser = lst.First();

                        Session["User"] = oUser;

                        return Content("1");

                    }
                    else
                    {
                        return Content("Usuario sin Acceso ");
                    }

                }




            }
            catch (Exception ex)
            {
                return Content("Error de aplicativo" + ex.Message);
            }

        }


    }
}