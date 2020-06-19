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
    public interface IMemberReceiptInfoBusiness
    {
        IEnumerable<MemberReceiptInfo> GetAlls(string[] includes, Expression<Func<MemberReceiptInfo, bool>> filter);
        IEnumerable<MemberReceiptInfo> GetAlls();
        MemberReceiptInfo Add(MemberReceiptInfo entity);
        MemberReceiptInfo Update(MemberReceiptInfo entity, List<Expression<Func<MemberReceiptInfo, object>>> update = null, List<Expression<Func<MemberReceiptInfo, object>>> exclude = null);
        MemberReceiptInfo Delete(int id);
        MemberReceiptInfo Delete(MemberReceiptInfo entity);
        IEnumerable<MemberReceiptInfoView> GetByMember(int id);
        bool Add(MemberReceiptInfoView model);
        bool DeleteV1(int id);
        void Save();
    }
   public class MemberReceiptInfoBusiness : IMemberReceiptInfoBusiness
    {
        private IMemberReceiptInfoRepository _memberReceiptInfo;
        private IUnitOfWork _unitOfWork;
        public MemberReceiptInfoBusiness(IMemberReceiptInfoRepository memberReceiptInfo,IUnitOfWork unitOfWork)
        {
            _memberReceiptInfo = memberReceiptInfo;
            _unitOfWork = unitOfWork;
        }

        public MemberReceiptInfo Add(MemberReceiptInfo entity)
        {
            return _memberReceiptInfo.Add(entity);
        }

        public MemberReceiptInfo Delete(int id)
        {
            return _memberReceiptInfo.Delete(id);
        }

        public MemberReceiptInfo Delete(MemberReceiptInfo entity)
        {
            return _memberReceiptInfo.Delete(entity);
        }

        public IEnumerable<MemberReceiptInfo> GetAlls()
        {
            return _memberReceiptInfo.GetAll(null);
        }

        public IEnumerable<MemberReceiptInfo> GetAlls(string[] includes, Expression<Func<MemberReceiptInfo, bool>> filter)
        {
            return _memberReceiptInfo.GetAll(includes, filter);
        }

        public MemberReceiptInfo Update(MemberReceiptInfo entity, List<Expression<Func<MemberReceiptInfo, object>>> update = null, List<Expression<Func<MemberReceiptInfo, object>>> exclude = null)
        {
            return _memberReceiptInfo.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<MemberReceiptInfoView> GetByMember(int id)
        {
            return _memberReceiptInfo.GetByMember(id);
        }

        public bool Add(MemberReceiptInfoView model)
        {
            return _memberReceiptInfo.Add(model);
        }

        public bool DeleteV1(int id)
        {
            return _memberReceiptInfo.DeleteV1(id);
        }
    }
}
