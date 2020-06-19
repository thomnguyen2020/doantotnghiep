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
    public class ProductCategoryController : Controller
    {
        // GET: Product
        IProductCategoryBusiness _categoryBusiness;
        public ProductCategoryController(IProductCategoryBusiness producCategoryBusiness)
        {
            this._categoryBusiness = producCategoryBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _categoryBusiness.GetAll();
                return View(result.OrderBy(x=>x.Rank));
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
        public ActionResult Add(ProductCategoryAction model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_categoryBusiness.Add(model) != null)
                    {
                        _categoryBusiness.Save();
                        return Redirect("/ProductCategory/List");
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
                var result = _categoryBusiness.GetEdit(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ProductCategoryAction model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_categoryBusiness.Edit(model))
                    {
                        _categoryBusiness.Save();
                        return Redirect("/ProductCategory/List");
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

                if (_categoryBusiness.StatusDelete(id))
                {
                    _categoryBusiness.Save();
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