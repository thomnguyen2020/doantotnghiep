using HanaSolution.Business.Core;
using HanaSolution.Data.ViewModels;
using HanaSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HanaSolution.Admin.Controllers
{
    public class SystemController : Controller
    {
        // GET: System
        IStaffBusiness _staffBusiness;
        public SystemController(IStaffBusiness staffBusiness)
        {
            this._staffBusiness = staffBusiness;
        }
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
                    var result = _staffBusiness.Login(model);
                    if (result != null)
                    {
                        HttpCookie StaffLoginCookie = new HttpCookie("StaffLoginCookie");
                        StaffLoginCookie.Value = JsonConvert.SerializeObject(result).UrlEncode();
                        StaffLoginCookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(StaffLoginCookie);
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
        [CheckLogin]
        public ActionResult Logout()
        {
            if (Request.Cookies["StaffLoginCookie"] != null)
            {
                HttpCookie StaffLoginCookie = new HttpCookie("StaffLoginCookie");
                StaffLoginCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(StaffLoginCookie);
            }
            return Json("true", JsonRequestBehavior.AllowGet);
        }
        public ActionResult WidgetLogin()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());

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
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null)
                    return Redirect("/System/Login");
                return View(login);

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
        [HttpPost]
        [ValidateInput(false)]
        [CheckLogin]
        public ActionResult ChangePass(ChangePassView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_staffBusiness.ChangePass(model))
                    {
                        _staffBusiness.Save();
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