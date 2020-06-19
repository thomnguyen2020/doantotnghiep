using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProdcutCategoryView> GetAlls();
        ProductCategoryAction GetEdit(int id);
        bool Edit(ProductCategoryAction model);
        bool StatusDelete(int id);
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public bool StatusDelete(int id)
        {
            try
            {
                ProductCategory category = DbContext.ProductCategorys.Find(id);
                if (category != null)
                {
                    category.Status = false;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
        public bool Edit(ProductCategoryAction model)
        {
            try
            {
                var _item = DbContext.ProductCategorys.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    if (!model.Avatar.Contains("http"))
                        _item.Avatar = "http://localhost:8810/" + model.Avatar;
                    else
                        _item.Avatar = model.Avatar;
                    _item.Desc = model.Desc;
                    _item.ModifyBy = model.ModifyBy;
                    _item.ModifyDate = DateTime.Now;
                    _item.Rank = model.Rank;
                    _item.Status = model.Status;
                    _item.Title = model.Title;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<ProdcutCategoryView> GetAlls()
        {
            try
            {
                List<ProdcutCategoryView> viewModels = new List<ProdcutCategoryView>();
                var _lst = from cat in DbContext.ProductCategorys
                           where cat.Status == true
                           select new
                           {
                               ID = cat.ID,
                               Avatar = cat.Avatar,
                               Title = cat.Title,
                               Rank = cat.Rank,
                               Desc = cat.Desc
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var i in _lst)
                    {
                        ProdcutCategoryView model = new ProdcutCategoryView();
                        model.Avatar = i.Avatar;
                        model.Desc = i.Desc;
                        model.ID = i.ID;
                        model.Rank = i.Rank;
                        model.Title = i.Title;
                        viewModels.Add(model);
                    }
                }

                return viewModels;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public ProductCategoryAction GetEdit(int id)
        {
            try
            {
                var _item = DbContext.ProductCategorys.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    ProductCategoryAction category = new ProductCategoryAction();
                    category.Avatar = _item.Avatar;
                    category.CreateBy = _item.CreateBy;
                    category.CreateDate = _item.CreateDate;
                    category.Desc = _item.Desc;
                    category.ID = _item.ID;
                    category.ModifyBy = _item.ModifyBy;
                    category.ModifyDate = _item.ModifyDate;
                    category.Rank = _item.Rank;
                    category.Status = _item.Status;
                    category.Title = _item.Title;
                    return category;
                }
                return null;
            }
            catch (System.Exception)
            {

                return new ProductCategoryAction();
            }
        }
    }
}
