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
    public interface IProductCategoryBusiness
    {
        IEnumerable<ProductCategory> GetAlls(string[] includes, Expression<Func<ProductCategory, bool>> filter);
        IEnumerable<ProductCategory> GetAlls();
        IEnumerable<ProdcutCategoryView> GetAll();
        ProductCategory Add(ProductCategoryAction entity);
        ProductCategory Update(ProductCategory entity, List<Expression<Func<ProductCategory, object>>> update = null, List<Expression<Func<ProductCategory, object>>> exclude = null);
        ProductCategory Delete(int id);
        bool StatusDelete(int id);
        ProductCategory Delete(ProductCategory entity);
        ProductCategoryAction GetEdit(int id);
        bool Edit(ProductCategoryAction model);
        void Save();
    }
    public class ProductCategoryBusiness : IProductCategoryBusiness
    {
        private IProductCategoryRepository _productCategory;
        private IUnitOfWork _unitOfWork;
        public ProductCategoryBusiness(IProductCategoryRepository productCategory, IUnitOfWork unitOfWork)
        {
            _productCategory = productCategory;
            _unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategoryAction entity)
        {
            try
            {
                ProductCategory category = new ProductCategory();
                category.Avatar = "http://localhost:44351/" + entity.Avatar;
                category.CreateBy = entity.CreateBy;
                category.CreateDate = DateTime.Now;
                category.Desc = entity.Desc;
                category.ID = entity.ID;
                category.ModifyBy = entity.ModifyBy;
                category.ModifyDate = DateTime.Now;
                category.Rank = entity.Rank;
                category.Status = entity.Status;
                category.Title = entity.Title;
                return _productCategory.Add(category);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ProductCategory Delete(int id)
        {
            return _productCategory.Delete(id);
        }

        public ProductCategory Delete(ProductCategory entity)
        {
            return _productCategory.Delete(entity);
        }

        public IEnumerable<ProductCategory> GetAlls()
        {
            return _productCategory.GetAll(null);
        }

        public IEnumerable<ProductCategory> GetAlls(string[] includes, Expression<Func<ProductCategory, bool>> filter)
        {
            return _productCategory.GetAll(includes, filter);
        }

        public ProductCategory Update(ProductCategory entity, List<Expression<Func<ProductCategory, object>>> update = null, List<Expression<Func<ProductCategory, object>>> exclude = null)
        {
            return _productCategory.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        IEnumerable<ProdcutCategoryView> IProductCategoryBusiness.GetAll()
        {
            return _productCategory.GetAlls();
        }

        public ProductCategoryAction GetEdit(int id)
        {
            return _productCategory.GetEdit(id);
        }

        public bool Edit(ProductCategoryAction model)
        {
            return _productCategory.Edit(model);
        }

        public bool StatusDelete(int id)
        {
            return _productCategory.StatusDelete(id);
        }
    }
}
