using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using HanaSolution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HanaSolution.Business.Core
{
    public interface IBannerBusiness
    {
        IEnumerable<Banner> GetAlls(string[] includes, Expression<Func<Banner, bool>> filter);
        IEnumerable<Banner> GetAlls();
        Banner Add(Banner entity);
        Banner Update(Banner entity, List<Expression<Func<Banner, object>>> update = null, List<Expression<Func<Banner, object>>> exclude = null);
        Banner Delete(int id);
        Banner Delete(Banner entity);
        IEnumerable<BannerActionView> GetAll();
        BannerActionView GetEdit(int id);
        bool Edit(BannerActionView model);
        bool Add(BannerActionView model);
        bool StatusDelete(int id);
        void Save();
    }
   public class BannerBusiness : IBannerBusiness
    {
        private IBannerRepository _banner;
        private IUnitOfWork _unitOfWork;
        public BannerBusiness(IBannerRepository banner,IUnitOfWork unitOfWork)
        {
            _banner = banner;
            _unitOfWork = unitOfWork;
        }

        public Banner Add(Banner entity)
        {
            return _banner.Add(entity);
        }

        public Banner Delete(int id)
        {
            return _banner.Delete(id);
        }

        public Banner Delete(Banner entity)
        {
            return _banner.Delete(entity);
        }

        public IEnumerable<Banner> GetAlls()
        {
            return _banner.GetAll(null);
        }

        public IEnumerable<Banner> GetAlls(string[] includes, Expression<Func<Banner, bool>> filter)
        {
            return _banner.GetAll(includes, filter);
        }

        public Banner Update(Banner entity, List<Expression<Func<Banner, object>>> update = null, List<Expression<Func<Banner, object>>> exclude = null)
        {
            return _banner.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<BannerActionView> GetAll()
        {
            return _banner.GetAll();
        }

        public BannerActionView GetEdit(int id)
        {
            return _banner.GetEdit(id);
        }

        public bool Edit(BannerActionView model)
        {
            return _banner.Edit(model);
        }

        public bool Add(BannerActionView model)
        {
            return _banner.Add(model);
        }

        public bool StatusDelete(int id)
        {
            return _banner.StatusDelete(id);
        }
    }
}
