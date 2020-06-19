using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using HanaSolution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HanaSolution.Business.Core
{
    public interface IOrderBusiness
    {
        IEnumerable<Order> GetAlls(string[] includes, Expression<Func<Order, bool>> filter);
        IEnumerable<Order> GetAlls();
        IEnumerable<OrderView> GetAll();
        IEnumerable<OrderView> GetByMember(int id);
        bool Add(OrderView model);
        bool UpdateStatus(long id, int status);
        bool UpdatePaymentStatus(long id, int status);
        bool CheckExistsCode(string code);
        OrderView GetOrder(string code);
        Order Add(Order entity);
        Order Update(Order entity, List<Expression<Func<Order, object>>> update = null, List<Expression<Func<Order, object>>> exclude = null);
        Order Delete(int id);
        Order Delete(Order entity);
        void Save();
    }
   public class OrderBusiness : IOrderBusiness
    {
        private IOrderRepository _order;
        private IUnitOfWork _unitOfWork;
        public OrderBusiness(IOrderRepository order,IUnitOfWork unitOfWork)
        {
            _order = order;
            _unitOfWork = unitOfWork;
        }

        public Order Add(Order entity)
        {
            return _order.Add(entity);
        }

        public Order Delete(int id)
        {
            return _order.Delete(id);
        }

        public Order Delete(Order entity)
        {
            return _order.Delete(entity);
        }

        public IEnumerable<Order> GetAlls()
        {
            return _order.GetAll(null);
        }

        public IEnumerable<Order> GetAlls(string[] includes, Expression<Func<Order, bool>> filter)
        {
            return _order.GetAll(includes, filter);
        }

        public Order Update(Order entity, List<Expression<Func<Order, object>>> update = null, List<Expression<Func<Order, object>>> exclude = null)
        {
            return _order.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        

        public IEnumerable<OrderView> GetByMember(int id)
        {
            return _order.GetByMember(id);
        }

        public bool Add(OrderView model)
        {
            return _order.Add(model);
        }

        public bool UpdateStatus(long id, int status)
        {
            return _order.UpdateStatus(id, status);
        }

        public bool UpdatePaymentStatus(long id, int status)
        {
            return _order.UpdatePaymentStatus(id, status);
        }

        public bool CheckExistsCode(string code)
        {
            return _order.CheckExistsCode(code);
        }

        public OrderView GetOrder(string code)
        {
            return _order.GetOrder(code);
        }

        public IEnumerable<OrderView> GetAll()
        {
            return _order.GetAll();
        }
    }
}
