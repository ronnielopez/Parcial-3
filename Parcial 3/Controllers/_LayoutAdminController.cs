using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parcial_3.Models;

namespace Parcial_3.Controllers
{
    public class _LayoutAdminController : Controller
    {
        // GET: _LayoutAdmin
        public ActionResult Index()
        {
            var oUser = (UserModel)System.Web.HttpContext.Current.Session["user"];
            ViewBag.Names = oUser.names;
            return View();
        }
    }
}