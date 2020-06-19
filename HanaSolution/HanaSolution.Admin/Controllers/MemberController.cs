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
    public class MemberController : Controller
    {
        // GET: Member
        IMemberBusiness _memberBusiness;
        IMemberLevelBusiness _memberLevel;
        public MemberController(IMemberBusiness memberBusiness,IMemberLevelBusiness memberLevelBusiness)
        {
            this._memberBusiness = memberBusiness;
            this._memberLevel = memberLevelBusiness;
        }
        public ActionResult List()
        {
            var result = _memberBusiness.GetAll();
            return View(result);
        }
        public string Lock(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_memberBusiness.ChangeStatus(id, false))
                {
                    _memberBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        public string UnLock(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_memberBusiness.ChangeStatus(id, true))
                {
                    _memberBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        #region MemberLevel
        public ActionResult MemberLevel()
        {
            try
            {
                var result = _memberLevel.GetAll();
                return View(result.OrderByDescending(x=>x.Rank));
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult MemberLevelAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MemberLevelAdd(MemberLevelView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());

                if (ModelState.IsValid)
                {

                    model.ActionBy = login.Account;
                    if (_memberLevel.Add(model))
                    {
                        _memberLevel.Save();
                        return Redirect("/Member/MemberLevel");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult MemberLevelEdit(int id)
        {
            try
            {
                var result = _memberLevel.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MemberLevelEdit(MemberLevelView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (ModelState.IsValid)
                {

                    model.ActionBy = login.Account;
                    if (_memberLevel.Edit(model))
                    {
                        _memberLevel.Save();
                        return Redirect("/Member/MemberLevel");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string MemberLevelDelete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_memberLevel.StatusDelete(id))
                {
                    _memberLevel.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        #endregion
    }
}