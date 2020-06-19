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
    public interface IProductFeedbackBusiness
    {
        IEnumerable<ProductFeedback> GetAlls(string[] includes, Expression<Func<ProductFeedback, bool>> filter);
        IEnumerable<ProductFeedback> GetAlls();
        IEnumerable<ProductFeedbackView> GetAll(long id);
        ProductFeedback Add(ProductFeedback entity);
        ProductFeedback Update(ProductFeedback entity, List<Expression<Func<ProductFeedback, object>>> update = null, List<Expression<Func<ProductFeedback, object>>> exclude = null);
        ProductFeedback Delete(int id);
        bool StatusUpdate(long id, int status);
        ProductFeedbackView GetById(long id);
        ProductFeedback Delete(ProductFeedback entity);
        void Save();
    }
   public class ProductFeedbackBusiness : IProductFeedbackBusiness
    {
        private IProductFeedbackRepository _productFeedback;
        private IUnitOfWork _unitOfWork;
        public ProductFeedbackBusiness(IProductFeedbackRepository productFeedback,IUnitOfWork unitOfWork)
        {
            _productFeedback = productFeedback;
            _unitOfWork = unitOfWork;
        }

        public ProductFeedback Add(ProductFeedback entity)
        {
            return _productFeedback.Add(entity);
        }

        public ProductFeedback Delete(int id)
        {
            return _productFeedback.Delete(id);
        }

        public ProductFeedback Delete(ProductFeedback entity)
        {
            return _productFeedback.Delete(entity);
        }

        public IEnumerable<ProductFeedback> GetAlls()
        {
            return _productFeedback.GetAll(null);
        }

        public IEnumerable<ProductFeedback> GetAlls(string[] includes, Expression<Func<ProductFeedback, bool>> filter)
        {
            return _productFeedback.GetAll(includes, filter);
        }

        public ProductFeedback Update(ProductFeedback entity, List<Expression<Func<ProductFeedback, object>>> update = null, List<Expression<Func<ProductFeedback, object>>> exclude = null)
        {
            return _productFeedback.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ProductFeedbackView> GetAll(long id)
        {
            return _productFeedback.GetAll(id);
        }

        

        public ProductFeedbackView GetById(long id)
        {
            return _productFeedback.GetById(id);
        }

        public bool StatusUpdate(long id, int status)
        {
            return _productFeedback.StatusUpdate(id, status);
        }
    }
}
