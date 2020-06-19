using HanaSolution.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Client.Controllers
{
    public class PromotionController : Controller
    {
        // GET: Promotion
        IPromotionBusiness _promotionBusiness;
        public PromotionController(IPromotionBusiness promotionBusiness)
        {
            this._promotionBusiness = promotionBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _promotionBusiness.Gets();
                return View(result);
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
                var result = _promotionBusiness.GetDetail(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}