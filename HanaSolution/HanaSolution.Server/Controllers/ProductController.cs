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
    public class ProductController : Controller
    {
        IProductCategoryBusiness _productCategoryBusiness;
        IProductBusiness _productBusiness;
        IProductFeedbackBusiness _productFeedbackBusiness;
        public ProductController(IProductCategoryBusiness productCategoryBusiness, IProductBusiness productBusiness, IProductFeedbackBusiness productFeedbackBusiness, IVendorReplyBusiness vendorReplyBusiness)
        {
            this._productCategoryBusiness = productCategoryBusiness;
            this._productBusiness = productBusiness;
            this._productFeedbackBusiness = productFeedbackBusiness;
        }
        // GET: Product

        public ActionResult List()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                var result = _productBusiness.GetAll(login.ID);

                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult Add()
        {
            try
            {
                ViewBag.CategoryLst = _productCategoryBusiness.GetAll();
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(ProductAddView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                    ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                    if (login == null)
                        return Redirect("/System/Login");
                    
                    model.Vendor = login.ID;
                    if (_productBusiness.Add(model))
                    {
                        _productBusiness.Save();
                        return RedirectToAction("List");
                    }
                }
                ViewBag.CategoryLst = _productCategoryBusiness.GetAll();
                return View();
            }
            catch (Exception)
            {

                ViewBag.CategoryLst = _productCategoryBusiness.GetAll();
                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            try
            {
                ViewBag.CategoryLst = _productCategoryBusiness.GetAll();
                var item = _productBusiness.GetEdit(id);
                return View(item);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(ProductEditView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                    ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                    if (login == null)
                        return Redirect("/System/Login");
                    
                    model.Vendor = login.ID;
                    if (_productBusiness.Edit(model))
                    {
                        _productBusiness.Save();
                        return RedirectToAction("List");
                    }
                }
                ViewBag.CategoryLst = _productCategoryBusiness.GetAll();
                return View();
            }
            catch (Exception)
            {

                ViewBag.CategoryLst = _productCategoryBusiness.GetAll();
                return View();
            }
        }

        public string Delete(long id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_productBusiness.Delete(id))
                {
                    _productBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }

        public ActionResult FeedBack(long id = 0)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                if (id == 0)
                {
                    var result = _productFeedbackBusiness.GetAll(login.ID);

                    return View(result);
                }
                else
                {
                    var result = _productFeedbackBusiness.GetAll(login.ID, id);

                    return View(result);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult FeedBackDetail(long id)
        {
            try
            {
                if (_productFeedbackBusiness.StatusUpdate(id, 1))
                    _productFeedbackBusiness.Save();
                var item = _productFeedbackBusiness.GetById(id);
                return View(item);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult FeedbackReply(long id)
        {
            try
            {
                var result = _vendorReplyBusiness.GetAll(id);
                return PartialView(result);
            }
            catch (Exception)
            {
                return PartialView();
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddReply(ReplyView model)
        {
            try
            {


                if (_vendorReplyBusiness.Add(model))
                {
                    _vendorReplyBusiness.Save();
                    if (_productFeedbackBusiness.StatusUpdate(model.Feedback, 2))
                        _productFeedbackBusiness.Save();
                    return Json(new ReturnJsonMessage { Message = "Gửi trả lời thành công", Status = "1" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new ReturnJsonMessage { Message = "Gửi trả lời thất bại", Status = "1" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new ReturnJsonMessage { Message = "Gửi trả lời thất bại", Status = "1" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}