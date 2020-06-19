using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<OrderView> GetAll();
        OrderView GetOrder(string code);
        IEnumerable<OrderView> GetByMember(int id);
        bool Add(OrderView model);
        bool UpdateStatus(long id,int status);
        bool UpdatePaymentStatus(long id, int status);
        bool CheckExistsCode(string code);
    }
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(OrderView model)
        {
            try
            {
                Order order = new Order();
                order.Amount = model.Amount;
                order.Code = model.Code;
                order.Date = DateTime.Now;
                order.DateUpdate = DateTime.Now;
                order.Member = model.Member;
                order.Receipt = model.Receipt;
                order.Reduce = model.Reduce;
                order.StatusOrder = model.StatusOrder;
                order.StatusPayment = model.StatusPayment;
                order.Total = model.Total;
                order.TypePayment = model.TypePayment;
                DbContext.Orders.Add(order);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool CheckExistsCode(string code)
        {
            try
            {
                var _item = DbContext.Orders.FirstOrDefault(x => x.Code.Equals(code));
                if (_item != null && _item.ID != 0)
                    return true;
                return false;
            }
            catch (Exception)
            {

                return true;
            }
        }


        public IEnumerable<OrderView> GetAll()
        {
            try
            {
                List<OrderView> orders = new List<OrderView>();
                var _lst = from o in DbContext.Orders
                           from m in DbContext.Members
                           where o.Member == m.ID
                           select new
                           {
                               ID = o.ID,
                               Code = o.Code,
                               Date = o.Date,
                               TypePayment = o.TypePayment,
                               StatusPayment = o.StatusPayment,
                               StatusOrder = o.StatusOrder,
                               Member = o.Member,
                               MemberName = m.Name,
                               Amount = o.Amount,
                               Reduce = o.Reduce,
                               Total = o.Total,
                               DateUpdate = o.DateUpdate,
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        OrderView order = new OrderView();
                        order.Amount = item.Amount;
                        order.Code = item.Code;
                        order.Date = item.Date;
                        order.DateUpdate = item.DateUpdate;
                        order.ID = item.ID;
                        order.Member = item.Member;
                        order.MemberName = item.MemberName;
                        order.Reduce = item.Reduce;
                        order.StatusOrder = item.StatusOrder;
                        order.StatusPayment = item.StatusPayment;
                        order.Total = item.Total;
                        order.TypePayment = item.TypePayment;
                        orders.Add(order);
                    }
                    return orders;
                }
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public IEnumerable<OrderView> GetByMember(int id)
        {
            try
            {
                List<OrderView> orders = new List<OrderView>();
                var _lst = from o in DbContext.Orders
                           from m in DbContext.Members
                           where o.Member == m.ID
                           && o.Member == id
                           select new
                           {
                               ID = o.ID,
                               Code = o.Code,
                               Date = o.Date,
                               TypePayment = o.TypePayment,
                               StatusPayment = o.StatusPayment,
                               StatusOrder = o.StatusOrder,
                               Member = o.Member,
                               MemberName = m.Name,
                               Amount = o.Amount,
                               Reduce = o.Reduce,
                               Total = o.Total,
                               DateUpdate = o.DateUpdate
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        OrderView order = new OrderView();
                        order.Amount = item.Amount;
                        order.Code = item.Code;
                        order.Date = item.Date;
                        order.DateUpdate = item.DateUpdate;
                        order.ID = item.ID;
                        order.Member = item.Member;
                        order.MemberName = item.MemberName;
                        order.Reduce = item.Reduce;
                        order.StatusOrder = item.StatusOrder;
                        order.StatusPayment = item.StatusPayment;
                        order.Total = item.Total;
                        order.TypePayment = item.TypePayment;
                        orders.Add(order);
                    }
                    return orders;
                }
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public OrderView GetOrder(string code)
        {
            try
            {
                var _item = DbContext.Orders.FirstOrDefault(x=>x.Code.Equals(code));
                if(_item!=null && _item.ID != 0)
                {
                    OrderView order = new OrderView();
                    order.Amount = _item.Amount;
                    order.Code = _item.Code;
                    order.Date = _item.Date;
                    order.DateUpdate = _item.DateUpdate;
                    order.ID = _item.ID;
                    order.Member = _item.Member;
                    order.MemberName = DbContext.Members.FirstOrDefault(x => x.ID == _item.Member).Name ?? "";
                    order.Receipt = _item.Receipt;
                    order.Reduce = _item.Reduce;
                    order.StatusOrder = _item.StatusOrder;
                    order.StatusPayment = _item.StatusPayment;
                    order.Total = _item.Total;
                    order.TypePayment = _item.TypePayment;
                    return order;
                }
                return new OrderView();

            }
            catch (Exception)
            {

                return new OrderView();
            }
        }

        public bool UpdatePaymentStatus(long id, int status)
        {
            try
            {
                var _item = DbContext.Orders.Find(id);
                if(_item!=null && _item.ID != 0)
                {
                    _item.StatusPayment = status;
                    _item.DateUpdate = DateTime.Now;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool UpdateStatus(long id, int status)
        {
            try
            {
                var _item = DbContext.Orders.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.StatusOrder = status;
                    _item.DateUpdate = DateTime.Now;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
