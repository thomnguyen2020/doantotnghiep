using HanaSolution.Business.Core;
using HanaSolution.Data.ViewModels;
using HanaSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Client.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        IMemberBusiness _memberBusiness;
        IMemberReceiptInfoBusiness _memberReceiptInfo;
        IOrderBusiness _orderBusiness;
        IOrderDetailBusiness _orderDetailBusiness;
        public MemberController(IMemberBusiness memberBusiness, IMemberReceiptInfoBusiness memberReceiptInfo,IOrderBusiness orderBusiness)
        {
            this._memberBusiness = memberBusiness;
            this._memberReceiptInfo = memberReceiptInfo;
            this._orderBusiness = orderBusiness;
        }
        public ActionResult Profiles()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null || login.ID == 0)
                    return Redirect("/dang-nhap.html");
                var result = _memberBusiness.GetDetail(login.ID);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult ReceiptWidget()
        {
            try
            {
                if (Request.Cookies["MemberLoginCookie"] != null)
                {
                    HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                    ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                    var result = _memberReceiptInfo.GetByMember(login.ID);
                    return PartialView(result);
                }
                return PartialView();
            }
            catch (Exception)
            {
                return PartialView();
            }
        }
        public ActionResult OrderWidget()
        {
            try
            {
                if (Request.Cookies["MemberLoginCookie"] != null)
                {
                    HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                    ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                    var result = _orderBusiness.GetByMember(login.ID);
                    return PartialView(result);
                }
                return PartialView();
            }
            catch (Exception)
            {
                return PartialView();
            }
        }
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
                    var result = _memberBusiness.Login(model);
                    if (result != null)
                    {
                        HttpCookie StaffLoginCookie = new HttpCookie("MemberLoginCookie");
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
        public ActionResult Logout()
        {
            if (Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie StaffLoginCookie = new HttpCookie("MemberLoginCookie");
                StaffLoginCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(StaffLoginCookie);
            }
            return Json("true", JsonRequestBehavior.AllowGet);
        }
        public ActionResult HeaderWidget()
        {
            try
            {
                if (Request.Cookies["MemberLoginCookie"] != null)
                {
                    HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                    ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                    if (login == null || login.ID == 0)
                        return PartialView();
                    var result = _memberBusiness.GetDetail(login.ID);
                    return PartialView(result);
                }
                return PartialView();
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(MemberActionView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_memberBusiness.CheckExistsAccount(model.Account, 0))
                        ModelState.AddModelError("ExistsAccountError", "Tài khoản này đã tồn tại trong hệ thống");

                    if (_memberBusiness.Register(model))
                    {
                        _memberBusiness.Save();
                        return Redirect("/dang-nhap.html");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult InfoChange()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null || login.ID == 0)
                    return Redirect("/dang-nhap.html");
                var result = _memberBusiness.GetEdit(login.ID);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult InfoChange(MemberActionView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_memberBusiness.CheckExistsAccount(model.Account, model.ID))
                        ModelState.AddModelError("ExistsAccountError", "Tài khoản này đã tồn tại trong hệ thống");

                    if (_memberBusiness.ChangeInfo(model))
                    {
                        _memberBusiness.Save();
                        return Redirect("/thong-tin-tai-khoan.html");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult ShoppingCart()
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["MemberShoppingCartCookie"];
                List<MemberShoppingCart> carts = JsonConvert.DeserializeObject<List<MemberShoppingCart>>(reqCookies.Value.ToString().UrlDecode());
                if (carts != null && carts.Count() > 0)
                    return PartialView(carts);
                else
                    return PartialView();
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult MemberReceiptAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MemberReceiptAdd(MemberReceiptInfoView model)
        {
            try
            {
                if (Request.Cookies["MemberLoginCookie"] == null)
                    return Redirect("/dang-nhap.html");

                HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                model.Member = login.ID;

                if (_memberReceiptInfo.Add(model))
                {
                    _memberReceiptInfo.Save();
                    return Redirect("/thong-tin-tai-khoan.html");
                }
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }
        [HttpPost]
        public string DeleteReceipt(int id)
        {
            try
            {
                if (id != 0)
                {
                    if (_memberReceiptInfo.DeleteV1(id))
                    {
                        _memberReceiptInfo.Save();
                        return "1";
                    }
                }
                return "-1";
            }
            catch (Exception)
            {

                return "-1";
            }
        }
    }
}