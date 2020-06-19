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
    public interface IOrderDetailBusiness
    {
        IEnumerable<OrderDetail> GetAlls(string[] includes, Expression<Func<OrderDetail, bool>> filter);
        
        OrderDetail Add(OrderDetail entity);
        IEnumerable<OrderDetailView> GetAll(string code);
        IEnumerable<OrderDetailView> GetAll();
        bool Add(OrderDetailView model);
        OrderDetail Update(OrderDetail entity, List<Expression<Func<OrderDetail, object>>> update = null, List<Expression<Func<OrderDetail, object>>> exclude = null);
        OrderDetail Delete(int id);
        OrderDetail Delete(OrderDetail entity);
        void Save();
    }
   public class OrderDetailBusiness : IOrderDetailBusiness
    {
        private IOrderDetailRepository _orderDetail;
        private IUnitOfWork _unitOfWork;
        public OrderDetailBusiness(IOrderDetailRepository orderDetail,IUnitOfWork unitOfWork)
        {
            _orderDetail = orderDetail;
            _unitOfWork = unitOfWork;
        }

        public OrderDetail Add(OrderDetail entity)
        {
            return _orderDetail.Add(entity);
        }

        public OrderDetail Delete(int id)
        {
            return _orderDetail.Delete(id);
        }

        public OrderDetail Delete(OrderDetail entity)
        {
            return _orderDetail.Delete(entity);
        }

       

        public IEnumerable<OrderDetail> GetAlls(string[] includes, Expression<Func<OrderDetail, bool>> filter)
        {
            return _orderDetail.GetAll(includes, filter);
        }

        public OrderDetail Update(OrderDetail entity, List<Expression<Func<OrderDetail, object>>> update = null, List<Expression<Func<OrderDetail, object>>> exclude = null)
        {
            return _orderDetail.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<OrderDetailView> GetAll(string code)
        {
            return _orderDetail.GetAll(code);
        }

        public bool Add(OrderDetailView model)
        {
            return _orderDetail.Add(model);
        }


        public IEnumerable<OrderDetailView> GetAll()
        {
            return _orderDetail.GetAll();
        }
    }
}
