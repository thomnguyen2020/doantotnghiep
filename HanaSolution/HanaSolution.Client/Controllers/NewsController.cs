using HanaSolution.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanaSolution.Client.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        private INewsBusiness _newsBusiness;
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
        public ActionResult Detail(long id)
        {
            try
            {
                var result = _newsBusiness.GetView(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}