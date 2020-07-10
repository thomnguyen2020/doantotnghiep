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
    public interface IProductBusiness
    {
        IEnumerable<Product> GetAlls(string[] includes, Expression<Func<Product, bool>> filter);
        IEnumerable<Product> GetAlls();
        IEnumerable<ProductViewList> GetAll(int id);
        IEnumerable<ProductViewList> GetAll();
        IEnumerable<ProductViewList> GetByCat(int id);
        ProductEditView GetEdit(long id);
        IEnumerable<ProductViewList> GetSearchs(string key);
        ProductViewList GetDetail(long id);
        bool Add(ProductAddView entity);
        bool Edit(ProductEditView entity);
        Product Update(Product entity, List<Expression<Func<Product, object>>> update = null, List<Expression<Func<Product, object>>> exclude = null);
        bool Delete(long id);
        Product Delete(Product entity);
        void Save();
    }
   public class ProductBusiness : IProductBusiness
    {
        private IProductRepository _product;
        private IUnitOfWork _unitOfWork;
        public ProductBusiness(IProductRepository product,IUnitOfWork unitOfWork)
        {
            _product = product;
            _unitOfWork = unitOfWork;
        }

        public bool Add(ProductAddView entity)
        {
            return _product.Add(entity);
        }

        public bool Delete(long id)
        {
            return _product.Delete(id);
        }

        public Product Delete(Product entity)
        {
            return _product.Delete(entity);
        }

        public IEnumerable<Product> GetAlls()
        {
            return _product.GetAll(null);
        }

        public IEnumerable<Product> GetAlls(string[] includes, Expression<Func<Product, bool>> filter)
        {
            return _product.GetAll(includes, filter);
        }

        public Product Update(Product entity, List<Expression<Func<Product, object>>> update = null, List<Expression<Func<Product, object>>> exclude = null)
        {
            return _product.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ProductViewList> GetAll(int id)
        {
            return _product.GetAlls(id);
        }

        public ProductEditView GetEdit(long id)
        {
            return _product.GetEdit(id);
        }

        public bool Edit(ProductEditView entity)
        {
            return _product.Edit(entity);
        }

        public IEnumerable<ProductViewList> GetAll()
        {
            return _product.GetAlls();
        }

        public IEnumerable<ProductViewList> GetByCat(int id)
        {
            return _product.GetByCat(id);
        }

        public ProductViewList GetDetail(long id)
        {
            return _product.GetDetail(id);
        }

        public IEnumerable<ProductViewList> GetSearchs(string key)
        {
            return _product.GetSearchs(key);
        }
    }
}
