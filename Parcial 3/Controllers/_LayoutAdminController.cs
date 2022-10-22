using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
        }

        public async Task<ActionResult> SignOut()
        {
            Session.Remove("user");
            return Content("1");
        }
    }
}