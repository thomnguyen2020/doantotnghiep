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
    public interface IPromotionBusiness
    {
        IEnumerable<Promotion> GetAlls(string[] includes, Expression<Func<Promotion, bool>> filter);
        IEnumerable<Promotion> GetAlls();
        IEnumerable<PromotionView> GetAll(long id);
        IEnumerable<PromotionView> GetAll();
        PromotionActionView GetByID(long id);
        bool Add(PromotionActionView entity);
        IEnumerable<PromotionAdminView> Gets();
        bool Edit(PromotionActionView entity);
        PromotionAdminView GetDetail(long id);
        bool Delete(long id);
        Promotion Update(Promotion entity, List<Expression<Func<Promotion, object>>> update = null, List<Expression<Func<Promotion, object>>> exclude = null);
        
        Promotion Delete(Promotion entity);
        void Save();
    }
   public class PromotionBusiness : IPromotionBusiness
    {
        private IPromotionRepository _promotion;
        private IUnitOfWork _unitOfWork;
        public PromotionBusiness(IPromotionRepository promotion,IUnitOfWork unitOfWork)
        {
            _promotion = promotion;
            _unitOfWork = unitOfWork;
        }

        

        

        public Promotion Delete(Promotion entity)
        {
            return _promotion.Delete(entity);
        }

        public IEnumerable<Promotion> GetAlls()
        {
            return _promotion.GetAll(null);
        }

        public IEnumerable<Promotion> GetAlls(string[] includes, Expression<Func<Promotion, bool>> filter)
        {
            return _promotion.GetAll(includes, filter);
        }

        public Promotion Update(Promotion entity, List<Expression<Func<Promotion, object>>> update = null, List<Expression<Func<Promotion, object>>> exclude = null)
        {
            return _promotion.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<PromotionView> GetAll(long id)
        {
            return _promotion.GetAll(id);
        }

        public PromotionActionView GetByID(long id)
        {
            return _promotion.GetByID(id);
        }

        public bool Add(PromotionActionView entity)
        {
            return _promotion.Add(entity);
        }

        public bool Edit(PromotionActionView entity)
        {
            return _promotion.Edit(entity);
        }

        public bool Delete(long id)
        {
            return _promotion.Delete(id);
        }

        public IEnumerable<PromotionAdminView> Gets()
        {
            return _promotion.Gets();
        }

        public IEnumerable<PromotionView> GetAll()
        {
            return _promotion.GetAll();
        }

        public PromotionAdminView GetDetail(long id)
        {
            return _promotion.GetDetail(id);
        }
    }
}
