using HanaSolution.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IProductCategoryBusiness _productCategory;
        IProductBusiness _productBusiness;
        IPromotionBusiness _promotionBusiness;
        INewsBusiness _newsBusiness;
        IBannerBusiness _bannerBusiness;
        public HomeController(IProductCategoryBusiness productCategoryBusiness,IProductBusiness productBusiness,IPromotionBusiness promotionBusiness,INewsBusiness newsBusiness,IBannerBusiness bannerBusiness)
        {
            this._productCategory = productCategoryBusiness;
            this._productBusiness = productBusiness;
            this._promotionBusiness = promotionBusiness;
            this._newsBusiness = newsBusiness;
            this._bannerBusiness = bannerBusiness;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category()
        {
            try
            {
                var result = _productCategory.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Product()
        {
            try
            {
                var result = _productBusiness.GetAll();
                return PartialView(result.Take(16).OrderByDescending(x=>x.Rate));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult ProductNews()
        {
            try
            {
                var result = _productBusiness.GetAll();
                return PartialView(result.Take(16).OrderByDescending(x => x.ID));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Promotion()
        {
            try
            {
                var result = _promotionBusiness.GetAll();
                return PartialView(result.Take(4));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult News()
        {
            try
            {
                var result = _newsBusiness.GetAll();
                return PartialView(result.Take(8));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Banner()
        {
            try
            {
                var result = _bannerBusiness.GetAll();
                return PartialView(result.Where(x=>x.Status==true));
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
    }
}