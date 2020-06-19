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
    public class NewsController : Controller
    {
        // GET: News
        INewsBusiness _newsBusiness;
        public NewsController(INewsBusiness newsBusiness)
        {
            this._newsBusiness = newsBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _newsBusiness.GetAll();
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
        public ActionResult Add(NewsAction model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_newsBusiness.Add(model))
                    {
                        _newsBusiness.Save();
                        return Redirect("/News/List");
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
                var result = _newsBusiness.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsAction model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_newsBusiness.Edit(model))
                    {
                        _newsBusiness.Save();
                        return Redirect("/News/List");
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

                if (_newsBusiness.StatusDelete(id))
                {
                    _newsBusiness.Save();
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