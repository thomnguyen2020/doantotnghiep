using HanaSolution.Business.Core;
using HanaSolution.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Admin.Controllers
{
    [CheckLogin]
    public class BannerController : Controller
    {
        // GET: Banner
        IBannerBusiness _bannerBusiness;
        public BannerController(IBannerBusiness bannerBusiness)
        {
            this._bannerBusiness = bannerBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _bannerBusiness.GetAll();
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
        public ActionResult Add(BannerActionView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_bannerBusiness.Add(model))
                    {
                        _bannerBusiness.Save();
                        return Redirect("/Banner/List");
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
                var result = _bannerBusiness.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(BannerActionView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_bannerBusiness.Edit(model))
                    {
                        _bannerBusiness.Save();
                        return Redirect("/Banner/List");
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

                if (_bannerBusiness.StatusDelete(id))
                {
                    _bannerBusiness.Save();
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