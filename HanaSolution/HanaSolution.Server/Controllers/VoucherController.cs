using HanaSolution.Business.Core;
using HanaSolution.Data.ViewModels;
using HanaSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Server.Controllers
{
    [CheckLogin]
    public class VoucherController : Controller
    {

        // GET: Voucher
        IVoucherBusiness _voucherBusiness;
        IPromotionBusiness _promotionBusiness;
        IProductBusiness _productBusiness;
        public VoucherController(IVoucherBusiness voucherBusiness, IPromotionBusiness promotionBusiness, IProductBusiness productBusiness)
        {
            this._voucherBusiness = voucherBusiness;
            this._promotionBusiness = promotionBusiness;
            this._productBusiness = productBusiness;
        }

        public ActionResult List(long id)
        {
            try
            {
                ViewBag.PromotionId = id;
                var result = _voucherBusiness.GetByPromotion(id);
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Add(long id)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["VendorLoginCookie"];
                ResponseVendorLogin login = JsonConvert.DeserializeObject<ResponseVendorLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");

                var products = _productBusiness.GetAll(login.ID);
                var promotion = _promotionBusiness.GetByID(id);

                VoucherAddView view = new VoucherAddView();
                view.Promotion = id;
                view.Vendor = login.ID;
                view.PromotionCode = promotion.Code;
                if (!promotion.Type.Contains("1"))
                    view.LimitNumber = 1;
                else
                    view.LimitNumber = promotion.Limit;

                ViewBag.ProductList = products;

                return View(view);
            }
            catch (Exception)
            {
                return Redirect("/Product/List");
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(VoucherAddView model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (_voucherBusiness.Add(model))
                        return Redirect($"/Promotion/Detail/{model.Promotion}");
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}