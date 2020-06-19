
using HanaSolution.Business.Core;
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
    [CheckLogin]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        IOrderBusiness _orderBusiness;
        IOrderDetailBusiness _orderDetailBusiness;
        // GET: Dashboard
        public DashboardController( IOrderBusiness orderBusiness, IOrderDetailBusiness orderDetailBusiness)
        {
            this._orderBusiness = orderBusiness;
            this._orderDetailBusiness = orderDetailBusiness;
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult WidgetTop()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                var result = _orderBusiness.GetAll();
                return PartialView(result.OrderBy(x => x.Date));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult WidgetReport()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                var result = _orderDetailBusiness.GetAll();
                List<OrderDetailView> details = new List<OrderDetailView>();
                foreach (var item in result)
                {
                    var detail = details.FirstOrDefault(x => x.Product == item.Product);
                    if (detail != null && detail.Product != 0)
                    {
                        detail.Qty += item.Qty;
                        detail.Total += item.Total;
                    }
                    else
                    {
                        details.Add(item);
                    }
                }
                return PartialView(details);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult WidgetOrder()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                var result = _orderBusiness.GetAll();
                return PartialView(result.OrderBy(x => x.Date));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }

    }
}