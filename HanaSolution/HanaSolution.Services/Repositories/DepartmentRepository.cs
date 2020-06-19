using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<DepartmentActionView> GetAll();
        DepartmentActionView GetEdit(int id);
        bool Edit(DepartmentActionView model);
        bool Add(DepartmentActionView model);
        bool StatusDelete(int id);
    }
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(DepartmentActionView model)
        {
            try
            {
                Department department = new Department();
                department.CreateBy = model.ActionBy;
                department.CreateDate = DateTime.Now;
                department.Desc = model.Desc;
                department.Mail = model.Mail;
                department.ModifyBy = model.ActionBy;
                department.ModifyDate = DateTime.Now;
                department.Phone = model.Phone;
                department.Status = model.Status;
                department.Title = model.Title;
                DbContext.Departments.Add(department);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(DepartmentActionView model)
        {
            try
            {
                var _item =DbContext.Departments.Find(model.ID);
                if(_item!=null && _item.ID != 0)
                {
                    _item.Desc = model.Desc;
                    _item.Mail = model.Mail;
                    _item.ModifyBy = model.ActionBy;
                    _item.ModifyDate = DateTime.Now;
                    _item.Phone = model.Phone;
                    _item.Status = model.Status;
                    _item.Title = model.Title;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<DepartmentActionView> GetAll()
        {
            try
            {
                List<DepartmentActionView> departments = new List<DepartmentActionView>();
                var _lst = DbContext.Departments.Where(x => x.Status == true);
                if(_lst!=null && _lst.Count() > 0)
                {
                    foreach(var item in _lst)
                    {
                        DepartmentActionView department = new DepartmentActionView();
                        department.ActionBy = item.CreateBy;
                        department.Desc = item.Desc;
                        department.ID = item.ID;
                        department.Mail = item.Mail;
                        department.Phone = item.Phone;
                        department.Status = item.Status;
                        department.Title = item.Title;
                        departments.Add(department);
                    }
                    return departments;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public DepartmentActionView GetEdit(int id)
        {
            try
            {
                var _item = DbContext.Departments.Find(id);
                if(_item!=null && _item.ID != 0)
                {
                    DepartmentActionView department = new DepartmentActionView();
                    department.ActionBy = _item.CreateBy;
                    department.Desc = _item.Desc;
                    department.ID = _item.ID;
                    department.Mail = _item.Mail;
                    department.Phone = _item.Phone;
                    department.Status = _item.Status;
                    department.Title = _item.Title;
                    return department;
                }
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
                Department department = DbContext.Departments.Find(id);
                if (department != null)
                {
                    department.Status = false;
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
