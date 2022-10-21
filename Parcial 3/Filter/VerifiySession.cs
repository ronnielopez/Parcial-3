using Parcial_3.Controllers;
using Parcial_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parcial_3.Filter
{
    public class VerifiySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (UserModel)HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index"); //ALT +126 ~   --LOGIN
                }


            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); //ALT +126 ~   -ENTRO A MI APLICACION
                }
            }



            base.OnActionExecuting(filterContext);
        }
    }
}