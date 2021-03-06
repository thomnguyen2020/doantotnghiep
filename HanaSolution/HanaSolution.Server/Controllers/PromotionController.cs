﻿using HanaSolution.Business.Core;
using HanaSolution.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using HanaSolution.Helper.Core;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Server.Controllers
{
    [CheckLogin]
    public class PromotionController : Controller
    {
        IPromotionBusiness _promotionBusiness;
        public PromotionController(IPromotionBusiness promotionBusiness)
        {
            this._promotionBusiness = promotionBusiness;
        }
        // GET: Promotion
        public ActionResult List()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["VendorLoginCookie"];
                ResponseVendorLogin login = JsonConvert.DeserializeObject<ResponseVendorLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                var result = _promotionBusiness.GetAll(login.ID);
                return View(result);
            }
            catch (Exception)
            {

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

                if (_promotionBusiness.Delete(id))
                {
                    _promotionBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        public ActionResult Add()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(PromotionActionView model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    HttpCookie reqCookies = Request.Cookies["VendorLoginCookie"];
                    ResponseVendorLogin login = JsonConvert.DeserializeObject<ResponseVendorLogin>(reqCookies.Value.ToString().UrlDecode());
                    if (login == null)
                        return Redirect("/System/Login");
                    model.Vendor = login.ID;
                    if (_promotionBusiness.Add(model))
                    {
                        _promotionBusiness.Save();
                        return RedirectToAction("List");
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult Edit(long id)
        {
            try
            {
                var item = _promotionBusiness.GetByID(id);
                return View(item);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(PromotionActionView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpCookie reqCookies = Request.Cookies["VendorLoginCookie"];
                    ResponseVendorLogin login = JsonConvert.DeserializeObject<ResponseVendorLogin>(reqCookies.Value.ToString().UrlDecode());
                    if (login == null)
                        return Redirect("/System/Login");
                    if (_promotionBusiness.Edit(model))
                    {
                        _promotionBusiness.Save();
                        return RedirectToAction("List");
                    }
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Detail(long id)
        {
            try
            {
                var item = _promotionBusiness.GetByID(id);
                return View(item);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}