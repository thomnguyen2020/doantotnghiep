using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IMemberReceiptInfoRepository : IRepository<MemberReceiptInfo>
    {
        IEnumerable<MemberReceiptInfoView> GetByMember(int id);
        bool Add(MemberReceiptInfoView model);
        bool DeleteV1(int id);
    }
    public class MemberReceiptInfoRepository : RepositoryBase<MemberReceiptInfo>, IMemberReceiptInfoRepository
    {
        public MemberReceiptInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(MemberReceiptInfoView model)
        {
            try
            {
                MemberReceiptInfo memberReceipt = new MemberReceiptInfo();
                memberReceipt.Address = model.Address;
                memberReceipt.FullName = model.FullName;
                memberReceipt.Member = model.Member;
                memberReceipt.Phone = model.Phone;
                DbContext.MemberReceiptInfos.Add(memberReceipt);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool DeleteV1(int id)
        {
            try
            {
                var _item = DbContext.MemberReceiptInfos.Find(id);
                if(_item!=null && _item.ID!=0)
                {
                    DbContext.MemberReceiptInfos.Remove(_item);
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<MemberReceiptInfoView> GetByMember(int id)
        {
            try
            {
                List<MemberReceiptInfoView> memberReceipts = new List<MemberReceiptInfoView>();
                var _lst = DbContext.MemberReceiptInfos.Where(x => x.Member == id);
                if(_lst != null && _lst.Count() > 0)
                {
                    foreach(var item in _lst)
                    {
                        MemberReceiptInfoView memberReceipt = new MemberReceiptInfoView();
                        memberReceipt.Address = item.Address;
                        memberReceipt.FullName = item.FullName;
                        memberReceipt.ID = item.ID;
                        memberReceipt.Member = item.Member;
                        memberReceipt.Phone = item.Phone;
                        memberReceipts.Add(memberReceipt);
                    }
                    return memberReceipts;
                }
                return new List<MemberReceiptInfoView>();
            }
            catch (System.Exception)
            {

                return new List<MemberReceiptInfoView>();
            }
        }
    }
}
