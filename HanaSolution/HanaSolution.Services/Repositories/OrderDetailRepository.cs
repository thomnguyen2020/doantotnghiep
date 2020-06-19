using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        IEnumerable<OrderDetailView> GetAll(string code);
        IEnumerable<OrderDetailView> GetAll();
        bool Add(OrderDetailView model);
    }
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(OrderDetailView model)
        {
            try
            {
                OrderDetail detail = new OrderDetail();
                detail.Code = model.Code;
                detail.Price = model.Price;
                detail.Product = model.Product;
                detail.Qty = model.Qty;
                detail.Reduce = model.Reduce;
                detail.Total = model.Total;
                DbContext.OrderDetails.Add(detail);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<OrderDetailView> GetAll(string code)
        {
            try
            {
                var _lst = from d in DbContext.OrderDetails
                           from p in DbContext.Products
                           where d.Product == p.ID
                           && d.Code.Equals(code)
                           select new
                           {
                               Code = d.Code,
                               Product = d.Product,
                               ProductName = p.Title,
                               ProductAvatar = p.Avatar,
                               Price = d.Price,
                               Reduce = d.Reduce,
                               Qty = d.Qty,
                               Total = d.Total
                           };

                if (_lst != null && _lst.Count() > 0)
                {
                    List<OrderDetailView> details = new List<OrderDetailView>();
                    foreach (var item in _lst)
                    {
                        OrderDetailView detail = new OrderDetailView();
                        detail.Code = item.Code;
                        detail.Price = item.Price;
                        detail.Product = item.Product;
                        detail.ProductAvatar = item.ProductAvatar;
                        detail.ProductName = item.ProductName;
                        detail.Qty = item.Qty;
                        detail.Reduce = item.Reduce;
                        detail.Total = item.Total;
                        details.Add(detail);
                    }
                    return details;
                }
                return new List<OrderDetailView>();
            }
            catch (System.Exception)
            {

                return new List<OrderDetailView>();
            }
        }


        public IEnumerable<OrderDetailView> GetAll()
        {
            try
            {
                var _lst = from d in DbContext.OrderDetails
                           from p in DbContext.Products
                           from o in DbContext.Orders
                           where d.Product == p.ID
                           && d.Code == o.Code
                           select new
                           {
                               Code = d.Code,
                               Product = d.Product,
                               ProductName = p.Title,
                               ProductAvatar = p.Avatar,
                               Price = d.Price,
                               Reduce = d.Reduce,
                               Qty = d.Qty,
                               Total = d.Total
                           };

                if (_lst != null && _lst.Count() > 0)
                {
                    List<OrderDetailView> details = new List<OrderDetailView>();
                    foreach (var item in _lst)
                    {
                        OrderDetailView detail = new OrderDetailView();
                        detail.Code = item.Code;
                        detail.Price = item.Price;
                        detail.Product = item.Product;
                        detail.ProductAvatar = item.ProductAvatar;
                        detail.ProductName = item.ProductName;
                        detail.Qty = item.Qty;
                        detail.Reduce = item.Reduce;
                        detail.Total = item.Total;
                        details.Add(detail);
                    }
                    return details;
                }
                return new List<OrderDetailView>();
            }
            catch (System.Exception)
            {

                return new List<OrderDetailView>();
            }
        }
    }
}
