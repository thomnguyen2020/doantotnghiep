using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IAssignPositionRepository : IRepository<AssignPosition>
    {
        IEnumerable<AssignPositionView> GetAll();
        bool Add(AssignPositionActionView model);
        bool Delete(int id, long sId, int dId);
    }
    public class AssignPositionRepository : RepositoryBase<AssignPosition>, IAssignPositionRepository
    {
        public AssignPositionRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(AssignPositionActionView model)
        {
            try
            {
                AssignPosition assignPosition = new AssignPosition();
                assignPosition.CreateBy = model.ActionBy;
                assignPosition.CreateDate = DateTime.Now;
                assignPosition.DepartmentID = model.DepartmentID;
                assignPosition.Desc = model.Desc;
                assignPosition.ModifyBy = model.ActionBy;
                assignPosition.ModifyDate = DateTime.Now;
                assignPosition.PositionID = model.PositionID;
                assignPosition.StaffID = model.StaffID;
                assignPosition.Status = model.Status;
                DbContext.AssignPositions.Add(assignPosition);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Delete(int id, long sId, int dId)
        {
            try
            {
                var _item = DbContext.AssignPositions.FirstOrDefault(x => x.StaffID == sId && x.PositionID == id && x.DepartmentID == dId);
                if (_item != null && _item.StaffID != 0)
                {
                    DbContext.AssignPositions.Remove(_item);
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<AssignPositionView> GetAll()
        {
            try
            {
                List<AssignPositionView> assignPositions = new List<AssignPositionView>();
                var _lst = from a in DbContext.AssignPositions
                           from s in DbContext.Staffs
                           from d in DbContext.Departments
                           from p in DbContext.Positions
                           where a.Status == true
                           && a.StaffID == s.ID
                           && a.DepartmentID == d.ID
                           && a.PositionID == p.ID
                           select new
                           {
                               StaffID=a.StaffID,
                               Staff=s.Name,
                               PositionID=a.PositionID,
                               Position=p.Title,
                               DepartmentID=a.DepartmentID,
                               Department=d.Title,
                               Desc=a.Desc,
                               ActionBy=a.CreateBy,
                               Status=a.Status
                           };
                if(_lst!=null && _lst.Count() > 0)
                {
                    foreach(var item in _lst)
                    {
                        AssignPositionView assignPosition = new AssignPositionView();
                        assignPosition.ActionBy = item.ActionBy;
                        assignPosition.DepartmentID = item.DepartmentID;
                        assignPosition.Desc = item.Desc;
                        assignPosition.PositionID = item.PositionID;
                        assignPosition.StaffID = item.StaffID;
                        assignPosition.Status = item.Status;
                        assignPosition.Staff = item.Staff;
                        assignPosition.Position = item.Position;
                        assignPosition.Department = item.Department;
                        assignPositions.Add(assignPosition);
                    }
                    return assignPositions;
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
