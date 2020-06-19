using HanaSolution.Business.Core;
using HanaSolution.Data.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HanaSolution.Helper.Core;

namespace HanaSolution.Server.Controllers
{
    public class SystemController : Controller
    {
        private IVendorBusiness _vendorBusiness;
        public SystemController(IVendorBusiness vendorBusiness)
        {
            this._vendorBusiness = vendorBusiness;
        }
        // GET: System
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string ReturnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _vendorBusiness.Login(model);
                    if (result != null)
                    {
                        HttpCookie VendorLoginCookie = new HttpCookie("VendorLoginCookie");
                        VendorLoginCookie.Value = JsonConvert.SerializeObject(result).UrlEncode();
                        VendorLoginCookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(VendorLoginCookie);
                        if (ReturnUrl != "" && ReturnUrl != null)
                            return Redirect(ReturnUrl.UrlDecode());
                        else
                            return Redirect("/");
                    }

                }

                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            if (Request.Cookies["VendorLoginCookie"] != null)
            {
                HttpCookie VendorLoginCookie = new HttpCookie("VendorLoginCookie");
                VendorLoginCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(VendorLoginCookie);
            }
            return Json("true", JsonRequestBehavior.AllowGet);
        }
        public ActionResult WidgetLogin()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["VendorLoginCookie"];
                ResponseVendorLogin login = JsonConvert.DeserializeObject<ResponseVendorLogin>(reqCookies.Value.ToString().UrlDecode());
                
                return PartialView(login);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        [CheckLogin]
        public ActionResult Profiles()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["VendorLoginCookie"];
                ResponseVendorLogin login = JsonConvert.DeserializeObject<ResponseVendorLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                var result = _vendorBusiness.GetById(login.ID);
                return View(result);

            }
            catch (Exception)
            {

                return View();
            }
        }
        [CheckLogin]
        public ActionResult ChangePass(string account)
        {
            try
            {
                ChangePassView view = new ChangePassView { Account = account, ConfirmPass = "", NewPass = "", OldPass = "" };
                return View(view);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [CheckLogin]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChangePass(ChangePassView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_vendorBusiness.ChangePass(model))
                    {
                        _vendorBusiness.Save();
                        return Redirect("/Dashboard/Dashboard");
                    }
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