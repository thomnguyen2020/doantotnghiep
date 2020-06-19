using HanaSolution.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Admin.Controllers
{
    [CheckLogin]
    public class OrderController : Controller
    {
        // GET: Order
        IOrderBusiness _orderBusiness;
        IMemberBusiness _memberBusiness;
        public OrderController(IOrderBusiness orderBusiness, IMemberBusiness memberBusiness)
        {
            this._orderBusiness = orderBusiness;
            this._memberBusiness = memberBusiness;
        }
        public ActionResult List()
        {
            try
            {
               
                var result = _orderBusiness.GetAll();
                return View(result.OrderBy(x => x.Date));
            }
            catch (Exception)
            {

                return View();
            }
        }
        public string Update(long id, int status)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_orderBusiness.UpdateStatus(id, status))
                {
                    if (status == 3)
                    {
                        if (_memberBusiness.AddPoint(id))
                            _memberBusiness.Save();
                    }

                    _orderBusiness.Save();
                    _orderBusiness.UpdatePaymentStatus(id, 1);
                    _orderBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
    }
}