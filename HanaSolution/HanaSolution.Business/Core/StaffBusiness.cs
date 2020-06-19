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
    public interface IStaffBusiness
    {
        IEnumerable<Staff> GetAlls(string[] includes, Expression<Func<Staff, bool>> filter);
        IEnumerable<Staff> GetAlls();
        Staff Add(Staff entity);
        Staff Update(Staff entity, List<Expression<Func<Staff, object>>> update = null, List<Expression<Func<Staff, object>>> exclude = null);
        Staff Delete(int id);
        Staff Delete(Staff entity);
        ResponseStaffLogin Login(LoginModel model);
        bool ChangePass(ChangePassView model);
        IEnumerable<StaffView> GetAll();
        StaffActionView GetEdit(int id);
        bool Edit(StaffActionView model);
        bool Add(StaffActionView model);
        bool StatusDelete(int id);
        bool CheckExistsAccount(string param, int id);
        void Save();
    }
    public class StaffBusiness : IStaffBusiness
    {
        private IStaffRepository _staff;
        private IUnitOfWork _unitOfWork;
        public StaffBusiness(IStaffRepository staff, IUnitOfWork unitOfWork)
        {
            _staff = staff;
            _unitOfWork = unitOfWork;
        }

        public Staff Add(Staff entity)
        {
            return _staff.Add(entity);
        }

        public Staff Delete(int id)
        {
            return _staff.Delete(id);
        }

        public Staff Delete(Staff entity)
        {
            return _staff.Delete(entity);
        }

        public IEnumerable<Staff> GetAlls()
        {
            return _staff.GetAll(null);
        }

        public IEnumerable<Staff> GetAlls(string[] includes, Expression<Func<Staff, bool>> filter)
        {
            return _staff.GetAll(includes, filter);
        }

        public Staff Update(Staff entity, List<Expression<Func<Staff, object>>> update = null, List<Expression<Func<Staff, object>>> exclude = null)
        {
            return _staff.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public ResponseStaffLogin Login(LoginModel model)
        {
            return _staff.Login(model);
        }

        public bool ChangePass(ChangePassView model)
        {
            return _staff.ChangePass(model);
        }

        public IEnumerable<StaffView> GetAll()
        {
            return _staff.GetAll();
        }

        public StaffActionView GetEdit(int id)
        {
            return _staff.GetEdit(id);
        }

        public bool Edit(StaffActionView model)
        {
            return _staff.Edit(model);
        }

        public bool Add(StaffActionView model)
        {
            return _staff.Add(model);
        }

        public bool StatusDelete(int id)
        {
            return _staff.StatusDelete(id);
        }

        public bool CheckExistsAccount(string param, int id)
        {
            return _staff.CheckExistsAccount(param, id);
        }
    }
}
