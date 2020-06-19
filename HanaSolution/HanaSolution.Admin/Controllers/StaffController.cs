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
    public class StaffController : Controller
    {
        // GET: Staff
        IStaffBusiness _staffBusiness;
        IDepartmentBusiness _departmentBusiness;
        IPositionBusiness _positionBusiness;
        IAssignPositionBusiness _assignPosition;
        public StaffController(IStaffBusiness staffBusiness,IDepartmentBusiness departmentBusiness,IPositionBusiness positionBusiness,IAssignPositionBusiness assignPosition)
        {
            this._staffBusiness = staffBusiness;
            this._departmentBusiness = departmentBusiness;
            this._positionBusiness = positionBusiness;
            this._assignPosition = assignPosition;
        }
        public ActionResult List()
        {
            try
            {
                var result = _staffBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(StaffActionView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());

                if (ModelState.IsValid)
                {
                    if (_staffBusiness.CheckExistsAccount(model.Account,0))
                    {
                        ModelState.AddModelError("ExistsAccountError", "Tài khoản này đã tồn tại trong hệ thống");
                        return View(model);
                    }
                    model.CreateBy = login.Account;
                    if (_staffBusiness.Add(model))
                    {
                        _staffBusiness.Save();
                        return Redirect("/Staff/List");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                var result = _staffBusiness.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(StaffActionView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (ModelState.IsValid)
                {
                    if (_staffBusiness.CheckExistsAccount(model.Account,model.ID))
                    {
                        ModelState.AddModelError("ExistsAccountError", "Tài khoản này đã tồn tại trong hệ thống");
                        return View(model);
                    }
                    model.CreateBy = login.Account;
                    if (_staffBusiness.Edit(model))
                    {
                        _staffBusiness.Save();
                        return Redirect("/Staff/List");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_staffBusiness.StatusDelete(id))
                {
                    _staffBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        #region Department
        public ActionResult Department()
        {
            try
            {
                var result = _departmentBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult DepartmentAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DepartmentAdd(DepartmentActionView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());

                if (ModelState.IsValid)
                {
                    
                    model.ActionBy = login.Account;
                    if (_departmentBusiness.Add(model))
                    {
                        _departmentBusiness.Save();
                        return Redirect("/Staff/Department");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult DepartmentEdit(int id)
        {
            try
            {
                var result = _departmentBusiness.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DepartmentEdit(DepartmentActionView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (ModelState.IsValid)
                {
                    
                    model.ActionBy = login.Account;
                    if (_departmentBusiness.Edit(model))
                    {
                        _departmentBusiness.Save();
                        return Redirect("/Staff/Department");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string DepartmentDelete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_departmentBusiness.StatusDelete(id))
                {
                    _departmentBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        #endregion
        #region Position
        public ActionResult Position()
        {
            try
            {
                var result = _positionBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult PositionAdd()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PositionAdd(PositionActionView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());

                if (ModelState.IsValid)
                {

                    model.ActionBy = login.Account;
                    if (_positionBusiness.Add(model))
                    {
                        _positionBusiness.Save();
                        return Redirect("/Staff/Position");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult PositionEdit(int id)
        {
            try
            {
                var result = _positionBusiness.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PositionEdit(PositionActionView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());
                if (ModelState.IsValid)
                {

                    model.ActionBy = login.Account;
                    if (_positionBusiness.Edit(model))
                    {
                        _positionBusiness.Save();
                        return Redirect("/Staff/Position");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string PositionDelete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_positionBusiness.StatusDelete(id))
                {
                    _positionBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
        #endregion
        #region AssignPosition
        public ActionResult AssignPosition()
        {
            try
            {
                var result = _assignPosition.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult AssignPositionAdd()
        {
            try
            {
                ViewBag.PositionList = _positionBusiness.GetAll();
                ViewBag.StaffList = _staffBusiness.GetAll();
                ViewBag.DepartmentList = _departmentBusiness.GetAll();
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AssignPositionAdd(AssignPositionActionView model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["StaffLoginCookie"];
                ResponseStaffLogin login = JsonConvert.DeserializeObject<ResponseStaffLogin>(reqCookies.Value.ToString().UrlDecode());

                if (ModelState.IsValid)
                {

                    model.ActionBy = login.Account;
                    if (_assignPosition.Add(model))
                    {
                        _assignPosition.Save();
                        return Redirect("/Staff/AssignPosition");
                    }
                }
                ViewBag.PositionList = _positionBusiness.GetAll();
                ViewBag.StaffList = _staffBusiness.GetAll();
                ViewBag.DepartmentList = _departmentBusiness.GetAll();
                return View(model);
            }
            catch (Exception)
            {
                ViewBag.PositionList = _positionBusiness.GetAll();
                ViewBag.StaffList = _staffBusiness.GetAll();
                ViewBag.DepartmentList = _departmentBusiness.GetAll();
                return View(model);
            }
        }
        
        public string AssignPositionDelete(int id,long sid,int dId)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_assignPosition.Delete(id,sid,dId))
                {
                    _assignPosition.Save();
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