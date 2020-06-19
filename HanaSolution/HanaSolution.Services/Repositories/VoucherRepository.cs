using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;
namespace HanaSolution.Services.Repositories
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        IEnumerable<VoucherView> GetByPromotion(long id);
        bool CheckExistsCode(string param);
        
    }
    public class VoucherRepository : RepositoryBase<Voucher>, IVoucherRepository
    {
        public VoucherRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        

        public bool CheckExistsCode(string param)
        {
            try
            {
                var _item = DbContext.Vouchers.FirstOrDefault(x => x.Code == param);
                if (_item != null && _item.ID != 0)
                    return true;

                return false;

            }
            catch (System.Exception)
            {

                return true;
            }
        }

        public IEnumerable<VoucherView> GetByPromotion(long id)
        {
            try
            {
                List<VoucherView> vouchers = new List<VoucherView>();
                var _lst = from v in DbContext.Vouchers
                           where v.Promotion == id
                           select new
                           {
                               Code = v.Code,
                               Type = v.Type,
                               IsApplyOrder = v.IsApplyOrder,
                               Product = v.Product,
                               PercentReduced = v.PercentReduced,
                               AmountReduced = v.AmountReduced,
                               DateUsed = v.DateUsed,
                               IsUsed = v.IsUsed
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        VoucherView voucher = new VoucherView();
                        voucher.AmountReduced = item.AmountReduced;
                        voucher.Code = item.Code;
                        voucher.DateUsed = item.DateUsed;
                        voucher.IsApplyOrder = item.IsApplyOrder;
                        voucher.IsUsed = item.IsUsed;
                        voucher.PercentReduced = item.PercentReduced;
                        voucher.Product = item.Product;
                        voucher.Type = item.Type;
                        vouchers.Add(voucher);
                    }
                    return vouchers;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }


    }
}
