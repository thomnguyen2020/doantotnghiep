using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IStaffRepository : IRepository<Staff>
    {
        ResponseStaffLogin Login(LoginModel model);
        bool ChangePass(ChangePassView model);
        IEnumerable<StaffView> GetAll();
        StaffActionView GetEdit(int id);
        bool Edit(StaffActionView model);
        bool Add(StaffActionView model);
        bool StatusDelete(int id);
        bool CheckExistsAccount(string param, int id);
    }
    public class StaffRepository : RepositoryBase<Staff>, IStaffRepository
    {
        public StaffRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(StaffActionView model)
        {
            try
            {
                Staff staff = new Staff();
                staff.Account = model.Account;
                staff.Address = model.Address;
                staff.BirthDay = model.BirthDay;
                staff.CreateBy = model.CreateBy;
                staff.CreateDate = DateTime.Now;
                staff.Gender = model.Gender;
                staff.Mail = model.Mail;
                staff.ModifyBy = model.CreateBy;
                staff.ModifyDate = DateTime.Now;
                staff.Name = model.Name;
                staff.Password = "123456";
                staff.Phone = model.Phone;
                staff.Status = model.Status;
                DbContext.Staffs.Add(staff);
                return true;
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
                var _item = DbContext.Staffs.FirstOrDefault(x => x.Account == model.Account && x.Password == model.OldPass);
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

        public bool CheckExistsAccount(string param, int id)
        {
            try
            {
                var _item = DbContext.Staffs.FirstOrDefault(x => x.Account == param && x.ID != id);
                if (_item != null && _item.ID != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                return true;
            }
        }

        public bool Edit(StaffActionView model)
        {
            try
            {
                var _item = DbContext.Staffs.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    _item.Account = model.Account;
                    _item.Address = model.Address;
                    _item.BirthDay = model.BirthDay;
                    _item.Gender = model.Gender;
                    _item.Mail = model.Mail;
                    _item.ModifyBy = model.CreateBy;
                    _item.ModifyDate = DateTime.Now;
                    _item.Name = model.Name;
                    _item.Phone = model.Phone;
                    _item.Status = model.Status;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<StaffView> GetAll()
        {
            try
            {
                List<StaffView> staffs = new List<StaffView>();
                var _lst = DbContext.Staffs.Where(x => x.Status == true);
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        StaffView staff = new StaffView();
                        staff.Account = item.Account;
                        staff.Address = item.Address;
                        staff.BirthDay = item.BirthDay;
                        staff.CreateBy = item.CreateBy;
                        staff.Gender = item.Gender;
                        staff.ID = item.ID;
                        staff.Mail = item.Mail;
                        staff.Name = item.Name;
                        staff.Phone = item.Phone;
                        staffs.Add(staff);
                    }
                    return staffs;
                }
                return null;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public StaffActionView GetEdit(int id)
        {
            try
            {
                var _item = DbContext.Staffs.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    StaffActionView staff = new StaffActionView();
                    staff.Account = _item.Account;
                    staff.Address = _item.Address;
                    staff.BirthDay = _item.BirthDay;
                    staff.CreateBy = _item.CreateBy;
                    staff.Gender = _item.Gender;
                    staff.ID = _item.ID;
                    staff.Mail = _item.Mail;
                    staff.Name = _item.Name;
                    staff.Phone = _item.Phone;
                    return staff;
                }
                return new StaffActionView();
            }
            catch (System.Exception)
            {

                return new StaffActionView();
            }
        }

        public ResponseStaffLogin Login(LoginModel model)
        {
            try
            {
                ResponseStaffLogin response = new ResponseStaffLogin();
                var staff = DbContext.Staffs.FirstOrDefault(x => x.Account == model.Username && x.Password == model.Password);
                if (staff != null)
                {
                    response.ID = staff.ID;
                    response.Name = staff.Name;
                    response.Account = staff.Account;
                    response.Address = staff.Address;
                    response.BirthDay = staff.BirthDay;
                    response.Gender = staff.Gender;
                    response.Mail = staff.Mail;
                    response.Phone = staff.Phone;
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

        public bool StatusDelete(int id)
        {
            try
            {
                Staff staff = DbContext.Staffs.Find(id);
                if (staff != null)
                {
                    staff.Status = false;
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
