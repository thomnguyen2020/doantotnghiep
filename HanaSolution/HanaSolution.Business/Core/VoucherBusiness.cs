using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Helper.Core;
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
    public interface IVoucherBusiness
    {
        IEnumerable<Voucher> GetAlls(string[] includes, Expression<Func<Voucher, bool>> filter);
        IEnumerable<Voucher> GetAlls();
        bool Add(VoucherAddView entity);
        bool CheckExistsCode(string param);
        IEnumerable<VoucherView> GetByPromotion(long id);
        Voucher Update(Voucher entity, List<Expression<Func<Voucher, object>>> update = null, List<Expression<Func<Voucher, object>>> exclude = null);
        Voucher Delete(int id);
        Voucher Delete(Voucher entity);
        void Save();
    }
    public class VoucherBusiness : IVoucherBusiness
    {
        private IVoucherRepository _voucher;
        private IUnitOfWork _unitOfWork;
        public VoucherBusiness(IVoucherRepository voucher, IUnitOfWork unitOfWork)
        {
            _voucher = voucher;
            _unitOfWork = unitOfWork;
        }

        public bool Add(VoucherAddView entity)
        {
            try
            {
                int count = 0;
                int max = entity.LimitNumber;
                while (count < max)
                {
                    Voucher voucher = new Voucher();
                    voucher.AmountReduced = entity.AmountReduced;
                    voucher.IsApplyOrder = entity.IsApplyOrder;
                    voucher.IsUsed = false;
                    voucher.PercentReduced = entity.PercentReduced;
                    voucher.Product = entity.Product;
                    voucher.Promotion = entity.Promotion;
                    voucher.Type = entity.Type;
                    voucher.Code = $"{entity.PromotionCode}-{RandomUtils.RandomString(9, 9, true, true, false)}";
                    if (!_voucher.CheckExistsCode(voucher.Code))
                    {
                        if (_voucher.Add(voucher) != null)
                        {
                            _unitOfWork.Commit();
                            count += 1;
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Voucher Delete(int id)
        {
            return _voucher.Delete(id);
        }

        public Voucher Delete(Voucher entity)
        {
            return _voucher.Delete(entity);
        }

        public IEnumerable<Voucher> GetAlls()
        {
            return _voucher.GetAll(null);
        }

        public IEnumerable<Voucher> GetAlls(string[] includes, Expression<Func<Voucher, bool>> filter)
        {
            return _voucher.GetAll(includes, filter);
        }

        public Voucher Update(Voucher entity, List<Expression<Func<Voucher, object>>> update = null, List<Expression<Func<Voucher, object>>> exclude = null)
        {
            return _voucher.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<VoucherView> GetByPromotion(long id)
        {
            return _voucher.GetByPromotion(id);
        }

        public bool CheckExistsCode(string param)
        {
            return _voucher.CheckExistsCode(param);
        }
    }
}
