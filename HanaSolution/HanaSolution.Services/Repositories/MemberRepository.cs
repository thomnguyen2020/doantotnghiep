using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IMemberRepository : IRepository<Member>
    {
        ResponseMemberLogin Login(LoginModel model);
        IEnumerable<MemberView> GetAll();
        MemberView GetDetail(int id);
        bool ChangeStatus(int id, bool status);
        bool Register(MemberActionView model);
        bool ChangeInfo(MemberActionView model);
        bool ChangePass(ChangePassView model);
        MemberActionView GetEdit(int id);
        bool CheckExistsAccount(string account, int id);
        bool AddPoint(int id, double point);
        bool AddPoint(long id);
    }
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool AddPoint(int id, double point)
        {
            try
            {
                var _item = DbContext.Members.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.AccumulatedPoints = _item.AccumulatedPoints + point;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool AddPoint(long id)
        {
            try
            {
                var _order = DbContext.Orders.Find(id);
                if(_order!=null && _order.StatusPayment == 0)
                {
                    var _item = DbContext.Members.Find(_order.Member);
                    double point = 0;
                    point = _order.Total / 1000;
                    if (_item != null && _item.ID != 0)
                    {
                        _item.AccumulatedPoints = _item.AccumulatedPoints + point;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ChangeInfo(MemberActionView model)
        {
            try
            {
                var _item = DbContext.Members.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    _item.Mail = model.Mail;
                    _item.Name = model.Name;
                    _item.Phone = model.Phone;
                    _item.Address = model.Address;
                    _item.BirthDay = model.BirthDay;
                    _item.Gender = model.Gender;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ChangePass(ChangePassView model)
        {
            try
            {
                var _item = DbContext.Members.FirstOrDefault(x => x.Account == model.Account && x.Password == model.OldPass);
                if (_item != null && _item.Account != "")
                {
                    _item.Password = model.NewPass;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool ChangeStatus(int id, bool status)
        {
            try
            {
                var _item = DbContext.Members.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.Status = status;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool CheckExistsAccount(string account, int id)
        {
            try
            {
                if (id == 0)
                {
                    var _item = DbContext.Members.FirstOrDefault(x => x.Account == account);
                    if (_item != null && _item.ID != 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    var _item = DbContext.Members.FirstOrDefault(x => x.Account == account && x.ID != id);
                    if (_item != null && _item.ID != 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                return true;
            }
        }

        public IEnumerable<MemberView> GetAll()
        {
            try
            {
                List<MemberView> members = new List<MemberView>();
                var _lst = DbContext.Members.Where(x => x.ID > 0);
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        MemberView member = new MemberView();
                        member.Account = item.Account;
                        member.Address = item.Address;
                        member.BirthDay = item.BirthDay;
                        member.DateJoin = item.DateJoin;
                        member.Gender = item.Gender;
                        member.ID = item.ID;
                        member.Mail = item.Mail;
                        member.Name = item.Name;
                        member.Phone = item.Phone;
                        member.Platform = item.Platform;
                        member.Status = item.Status;
                        member.AccumulatedPoints = item.AccumulatedPoints;
                        member.Level = DbContext.MemberLevels.FirstOrDefault(x => x.Point <= item.AccumulatedPoints) != null ? DbContext.MemberLevels.FirstOrDefault(x => x.Point <= item.AccumulatedPoints).Name : "Thành viên";
                        members.Add(member);
                    }
                    return members;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public MemberView GetDetail(int id)
        {
            try
            {
                var _item = DbContext.Members.Find(id);
                if (_item != null && _item.ID != 0)
                {

                    MemberView member = new MemberView();
                    member.Account = _item.Account;
                    member.Address = _item.Address;
                    member.BirthDay = _item.BirthDay;
                    member.DateJoin = _item.DateJoin;
                    member.Gender = _item.Gender;
                    member.ID = _item.ID;
                    member.Mail = _item.Mail;
                    member.Name = _item.Name;
                    member.Phone = _item.Phone;
                    member.Platform = _item.Platform;
                    member.Status = _item.Status;
                    member.AccumulatedPoints = _item.AccumulatedPoints;
                    member.Level = DbContext.MemberLevels.FirstOrDefault(x => x.Point <= _item.AccumulatedPoints) != null ? DbContext.MemberLevels.Where(x => x.Point <= _item.AccumulatedPoints).OrderByDescending(x => x.Point).FirstOrDefault().Name : "Thành viên";
                    return member;

                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public MemberActionView GetEdit(int id)
        {
            try
            {
                var _item = DbContext.Members.Find(id);
                if (_item != null && _item.ID != 0)
                {

                    MemberActionView member = new MemberActionView();
                    member.Account = _item.Account;
                    member.Address = _item.Address;
                    member.BirthDay = _item.BirthDay;
                    member.Gender = _item.Gender;
                    member.ID = _item.ID;
                    member.Mail = _item.Mail;
                    member.Name = _item.Name;
                    member.Phone = _item.Phone;
                    return member;

                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public ResponseMemberLogin Login(LoginModel model)
        {
            try
            {
                ResponseMemberLogin response = new ResponseMemberLogin();
                var member = DbContext.Members.FirstOrDefault(x => x.Account == model.Username && x.Password == model.Password);
                if (member != null && member.ID != 0)
                {
                    response.ID = member.ID;
                    response.Name = member.Name;
                    return response;
                }
                else
                    return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public bool Register(MemberActionView model)
        {
            try
            {
                Member member = new Member();
                member.Account = model.Account;
                member.AccumulatedPoints = 0;
                member.Address = model.Address;
                member.BirthDay = model.BirthDay;
                member.DateJoin = DateTime.Now;
                member.Gender = model.Gender;
                member.Mail = model.Mail;
                member.Name = model.Name;
                member.Password = model.Password;
                member.Phone = model.Phone;
                member.Platform = "Web";
                member.Status = true;
                DbContext.Members.Add(member);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
