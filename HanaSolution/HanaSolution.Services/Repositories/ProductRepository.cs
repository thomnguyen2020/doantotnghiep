using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductViewList> GetAlls(int id);
        IEnumerable<ProductViewList> GetAlls();
        IEnumerable<ProductViewList> GetByCat(int id);
        ProductViewList GetDetail(long id);
        bool Add(ProductAddView model);
        ProductEditView GetEdit(long id);
        bool Edit(ProductEditView model);
        bool Delete(long id);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(ProductAddView model)
        {
            try
            {
                Product product = new Product();
                product.Avatar = "http://localhost:44351" + model.Avatar;
                product.Category = model.Category;
                product.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                product.CreateBy = model.Staff.ToString();
                product.CreateDate = DateTime.Now;
                product.Desc = model.Desc;
                product.ModifyBy = model.Staff.ToString();
                product.ModifyDate = DateTime.Now;
                product.Price = model.Price;
                product.Status = model.Status;
                product.Title = model.Title;
                product.Staff = model.Staff;

                DbContext.Products.Add(product);

                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                Product product = DbContext.Products.Find(id);
                if (product != null)
                {
                    product.Status = false;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Edit(ProductEditView model)
        {
            try
            {
                Product product = DbContext.Products.Find(model.ID);
                if (product != null)
                {
                    if (!model.Avatar.Contains("http"))
                        product.Avatar = "http://localhost:44351" + model.Avatar;
                    else
                        product.Avatar = model.Avatar;
                    product.Category = model.Category;
                    product.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                    product.Desc = model.Desc;
                    product.Price = model.Price;
                    product.Status = model.Status;
                    product.Title = model.Title;
                    product.Staff = model.Staff;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<ProductViewList> GetAlls(int id)
        {
            try
            {
                List<ProductViewList> viewLists = new List<ProductViewList>();
                var _lst = from p in DbContext.Products
                           from c in DbContext.ProductCategorys
                           from v in DbContext.Staffs
                           where p.Staff == v.ID
                           && p.Category == c.ID
                           && p.Staff == id
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Desc = p.Desc,
                               Avatar = p.Avatar,
                               Category = c.Title,
                               Price = p.Price,
                               Staff = v.Name
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        ProductViewList viewList = new ProductViewList();
                        viewList.Avatar = item.Avatar;
                        viewList.Category = item.Category;
                        viewList.Desc = item.Desc;
                        viewList.ID = item.ID;
                        viewList.Price = item.Price;
                        viewList.Title = item.Title;
                        viewList.Staff = item.Staff;
                        viewLists.Add(viewList);
                    }
                }
                return viewLists;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public IEnumerable<ProductViewList> GetAlls()
        {
            try
            {
                List<ProductViewList> viewLists = new List<ProductViewList>();
                var _lst = from p in DbContext.Products
                           from c in DbContext.ProductCategorys
                           from v in DbContext.Staffs
                           where p.Staff == v.ID
                           && p.Category == c.ID
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Desc = p.Desc,
                               Avatar = p.Avatar,
                               Category = c.Title,
                               Price = p.Price,
                               Staff = v.Name,
                               Rate = p.Rate
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        ProductViewList viewList = new ProductViewList();
                        viewList.Avatar = item.Avatar;
                        viewList.Category = item.Category;
                        viewList.Desc = item.Desc;
                        viewList.ID = item.ID;
                        viewList.Price = item.Price;
                        viewList.Title = item.Title;
                        viewList.Staff = item.Staff;
                        viewList.Rate = item.Rate;
                        viewLists.Add(viewList);
                    }
                }
                return viewLists;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public IEnumerable<ProductViewList> GetByCat(int id)
        {
            try
            {
                List<ProductViewList> viewLists = new List<ProductViewList>();
                var _lst = from p in DbContext.Products
                           from c in DbContext.ProductCategorys
                           from v in DbContext.Staffs
                           where p.Staff == v.ID
                           && p.Category == c.ID
                           && p.Category == id
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Desc = p.Desc,
                               Avatar = p.Avatar,
                               Category = c.Title,
                               Price = p.Price,
                               Staff = v.Name
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        ProductViewList viewList = new ProductViewList();
                        viewList.Avatar = item.Avatar;
                        viewList.Category = item.Category;
                        viewList.Desc = item.Desc;
                        viewList.ID = item.ID;
                        viewList.Price = item.Price;
                        viewList.Title = item.Title;
                        viewList.Staff = item.Staff;
                        viewLists.Add(viewList);
                    }
                }
                return viewLists;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public ProductViewList GetDetail(long id)
        {
            try
            {
                var _item = (from p in DbContext.Products
                             from c in DbContext.ProductCategorys
                             from v in DbContext.Staffs
                             where p.Staff == v.ID
                             && p.Category == c.ID
                             && p.ID == id
                             && p.Status == true
                             select new
                             {
                                 ID = p.ID,
                                 Title = p.Title,
                                 Desc = p.Desc,
                                 Avatar = p.Avatar,
                                 Category = c.Title,
                                 Price = p.Price,
                                 Staff = v.Name,
                                 StaffID = v.ID,
                                 Content = p.Content
                             }).FirstOrDefault();
                if (_item != null && _item.ID != 0)
                {
                    ProductViewList viewList = new ProductViewList();
                    viewList.Avatar = _item.Avatar;
                    viewList.Category = _item.Category;
                    viewList.Desc = _item.Desc;
                    viewList.ID = _item.ID;
                    viewList.Price = _item.Price;
                    viewList.Title = _item.Title;
                    viewList.Staff = _item.Staff;
                    viewList.StaffID = _item.StaffID;
                    viewList.Content = _item.Content;
                    return viewList;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ProductEditView GetEdit(long id)
        {
            try
            {
                var product = DbContext.Products.Find(id);
                if (product != null)
                    return new ProductEditView { ID = product.ID, Avatar = product.Avatar, Category = product.Category, Content = product.Content, Desc = product.Desc, Price = product.Price, Status = product.Status, Title = product.Title, Staff = product.Staff };
                else
                    return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
