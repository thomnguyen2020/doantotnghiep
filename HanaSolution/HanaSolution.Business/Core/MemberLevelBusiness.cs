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
    public interface IMemberLevelBusiness
    {
        IEnumerable<MemberLevel> GetAlls(string[] includes, Expression<Func<MemberLevel, bool>> filter);
        IEnumerable<MemberLevel> GetAlls();
        MemberLevel Add(MemberLevel entity);
        MemberLevel Update(MemberLevel entity, List<Expression<Func<MemberLevel, object>>> update = null, List<Expression<Func<MemberLevel, object>>> exclude = null);
        MemberLevel Delete(int id);
        MemberLevel Delete(MemberLevel entity);
        IEnumerable<MemberLevelView> GetAll();
        MemberLevelView GetEdit(int id);
        bool Edit(MemberLevelView model);
        bool Add(MemberLevelView model);
        bool StatusDelete(int id);
        void Save();
    }
   public class MemberLevelBusiness : IMemberLevelBusiness
    {
        private IMemberLevelRepository _memberLevel;
        private IUnitOfWork _unitOfWork;
        public MemberLevelBusiness(IMemberLevelRepository memberLevel,IUnitOfWork unitOfWork)
        {
            _memberLevel = memberLevel;
            _unitOfWork = unitOfWork;
        }

        public MemberLevel Add(MemberLevel entity)
        {
            return _memberLevel.Add(entity);
        }

        public MemberLevel Delete(int id)
        {
            return _memberLevel.Delete(id);
        }

        public MemberLevel Delete(MemberLevel entity)
        {
            return _memberLevel.Delete(entity);
        }

        public IEnumerable<MemberLevel> GetAlls()
        {
            return _memberLevel.GetAll(null);
        }

        public IEnumerable<MemberLevel> GetAlls(string[] includes, Expression<Func<MemberLevel, bool>> filter)
        {
            return _memberLevel.GetAll(includes, filter);
        }

        public MemberLevel Update(MemberLevel entity, List<Expression<Func<MemberLevel, object>>> update = null, List<Expression<Func<MemberLevel, object>>> exclude = null)
        {
            return _memberLevel.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<MemberLevelView> GetAll()
        {
            return _memberLevel.GetAll();
        }

        public MemberLevelView GetEdit(int id)
        {
            return _memberLevel.GetEdit(id);
        }

        public bool Edit(MemberLevelView model)
        {
            return _memberLevel.Edit(model);
        }

        public bool Add(MemberLevelView model)
        {
            return _memberLevel.Add(model);
        }

        public bool StatusDelete(int id)
        {
            return _memberLevel.StatusDelete(id);
        }
    }
}
