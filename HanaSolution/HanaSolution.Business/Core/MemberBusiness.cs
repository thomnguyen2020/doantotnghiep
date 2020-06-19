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
    public interface IMemberBusiness
    {
        IEnumerable<Member> GetAlls(string[] includes, Expression<Func<Member, bool>> filter);
        IEnumerable<Member> GetAlls();
        Member Add(Member entity);
        MemberView GetDetail(int id);
        ResponseMemberLogin Login(LoginModel model);
        bool Register(MemberActionView model);
        bool ChangeInfo(MemberActionView model);
        bool ChangePass(ChangePassView model);
        Member Update(Member entity, List<Expression<Func<Member, object>>> update = null, List<Expression<Func<Member, object>>> exclude = null);
        Member Delete(int id);
        Member Delete(Member entity);
        IEnumerable<MemberView> GetAll();
        bool ChangeStatus(int id, bool status);
        MemberActionView GetEdit(int id);
        bool AddPoint(long id);
        bool AddPoint(int id, double point);
        bool CheckExistsAccount(string account, int id);
        void Save();
    }
   public class MemberBusiness : IMemberBusiness
    {
        private IMemberRepository _member;
        private IUnitOfWork _unitOfWork;
        public MemberBusiness(IMemberRepository member,IUnitOfWork unitOfWork)
        {
            _member = member;
            _unitOfWork = unitOfWork;
        }

        public Member Add(Member entity)
        {
            return _member.Add(entity);
        }

        public Member Delete(int id)
        {
            return _member.Delete(id);
        }

        public Member Delete(Member entity)
        {
            return _member.Delete(entity);
        }

        public IEnumerable<Member> GetAlls()
        {
            return _member.GetAll(null);
        }

        public IEnumerable<Member> GetAlls(string[] includes, Expression<Func<Member, bool>> filter)
        {
            return _member.GetAll(includes, filter);
        }

        public Member Update(Member entity, List<Expression<Func<Member, object>>> update = null, List<Expression<Func<Member, object>>> exclude = null)
        {
            return _member.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<MemberView> GetAll()
        {
            return _member.GetAll();
        }

        public bool ChangeStatus(int id, bool status)
        {
            return _member.ChangeStatus(id, status);
        }

        public ResponseMemberLogin Login(LoginModel model)
        {
            return _member.Login(model);
        }

        public MemberView GetDetail(int id)
        {
            return _member.GetDetail(id);
        }

        public bool Register(MemberActionView model)
        {
            return _member.Register(model);
        }

        public bool ChangeInfo(MemberActionView model)
        {
            return _member.ChangeInfo(model);
        }

        public bool ChangePass(ChangePassView model)
        {
            return _member.ChangePass(model);
        }

        public MemberActionView GetEdit(int id)
        {
            return _member.GetEdit(id);
        }

        public bool CheckExistsAccount(string account, int id)
        {
            return _member.CheckExistsAccount(account, id);
        }

        public bool AddPoint(int id, double point)
        {
            return _member.AddPoint(id, point);
        }

        public bool AddPoint(long id)
        {
            return _member.AddPoint(id);
        }
    }
}
