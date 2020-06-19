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
    public interface IAssignPositionBusiness
    {
        IEnumerable<AssignPosition> GetAlls(string[] includes, Expression<Func<AssignPosition, bool>> filter);
        IEnumerable<AssignPosition> GetAlls();
        AssignPosition Add(AssignPosition entity);
        AssignPosition Update(AssignPosition entity, List<Expression<Func<AssignPosition, object>>> update = null, List<Expression<Func<AssignPosition, object>>> exclude = null);
        AssignPosition Delete(int id);
        AssignPosition Delete(AssignPosition entity);
        IEnumerable<AssignPositionView> GetAll();
        bool Add(AssignPositionActionView model);
        bool Delete(int id, long sId, int dId);
        void Save();
    }
   public class AssignPositionBusiness : IAssignPositionBusiness
    {
        private IAssignPositionRepository _assignPosition;
        private IUnitOfWork _unitOfWork;
        public AssignPositionBusiness(IAssignPositionRepository assignPosition,IUnitOfWork unitOfWork)
        {
            _assignPosition = assignPosition;
            _unitOfWork = unitOfWork;
        }

        public AssignPosition Add(AssignPosition entity)
        {
            return _assignPosition.Add(entity);
        }

        public AssignPosition Delete(int id)
        {
            return _assignPosition.Delete(id);
        }

        public AssignPosition Delete(AssignPosition entity)
        {
            return _assignPosition.Delete(entity);
        }

        public IEnumerable<AssignPosition> GetAlls()
        {
            return _assignPosition.GetAll(null);
        }

        public IEnumerable<AssignPosition> GetAlls(string[] includes, Expression<Func<AssignPosition, bool>> filter)
        {
            return _assignPosition.GetAll(includes, filter);
        }

        public AssignPosition Update(AssignPosition entity, List<Expression<Func<AssignPosition, object>>> update = null, List<Expression<Func<AssignPosition, object>>> exclude = null)
        {
            return _assignPosition.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<AssignPositionView> GetAll()
        {
            return _assignPosition.GetAll();
        }

        public bool Add(AssignPositionActionView model)
        {
            return _assignPosition.Add(model);
        }

        public bool Delete(int id, long sId, int dId)
        {
            return _assignPosition.Delete(id, sId, dId);
        }
    }
}
