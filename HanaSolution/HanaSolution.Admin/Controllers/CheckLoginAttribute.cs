using HanaSolution.Data.ViewModels;
using HanaSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Admin.Controllers
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Controller controller = filterContext.Controller as Controller;
            HttpCookie reqCookies = HttpContext.Current.Request.Cookies["StaffLoginCookie"];
            if (reqCookies != null )
            {
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                {
                    controller.Response.Redirect("/System/login");
                }

                if (login.ID <= 0)
                {
                    controller.Response.Redirect("/System/login");
                }
            }
            else
            {
                controller.Response.Redirect("/System/login");
            }

        }
    }
}