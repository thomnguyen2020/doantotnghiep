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
    public interface IDepartmentBusiness
    {
        IEnumerable<Department> GetAlls(string[] includes, Expression<Func<Department, bool>> filter);
        IEnumerable<Department> GetAlls();
        Department Add(Department entity);
        Department Update(Department entity, List<Expression<Func<Department, object>>> update = null, List<Expression<Func<Department, object>>> exclude = null);
        Department Delete(int id);
        Department Delete(Department entity);
        IEnumerable<DepartmentActionView> GetAll();
        DepartmentActionView GetEdit(int id);
        bool Edit(DepartmentActionView model);
        bool Add(DepartmentActionView model);
        bool StatusDelete(int id);
        void Save();
    }
   public class DepartmentBusiness : IDepartmentBusiness
    {
        private IDepartmentRepository _department;
        private IUnitOfWork _unitOfWork;
        public DepartmentBusiness(IDepartmentRepository department,IUnitOfWork unitOfWork)
        {
            _department = department;
            _unitOfWork = unitOfWork;
        }

        public Department Add(Department entity)
        {
            return _department.Add(entity);
        }

        public Department Delete(int id)
        {
            return _department.Delete(id);
        }

        public Department Delete(Department entity)
        {
            return _department.Delete(entity);
        }

        public IEnumerable<Department> GetAlls()
        {
            return _department.GetAll(null);
        }

        public IEnumerable<Department> GetAlls(string[] includes, Expression<Func<Department, bool>> filter)
        {
            return _department.GetAll(includes, filter);
        }

        public Department Update(Department entity, List<Expression<Func<Department, object>>> update = null, List<Expression<Func<Department, object>>> exclude = null)
        {
            return _department.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<DepartmentActionView> GetAll()
        {
            return _department.GetAll();
        }

        public DepartmentActionView GetEdit(int id)
        {
            return _department.GetEdit(id);
        }

        public bool Edit(DepartmentActionView model)
        {
            return _department.Edit(model);
        }

        public bool Add(DepartmentActionView model)
        {
            return _department.Add(model);
        }

        public bool StatusDelete(int id)
        {
            return _department.StatusDelete(id);
        }
    }
}
