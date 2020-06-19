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
    public interface IPositionBusiness
    {
        IEnumerable<Position> GetAlls(string[] includes, Expression<Func<Position, bool>> filter);
        IEnumerable<Position> GetAlls();
        Position Add(Position entity);
        Position Update(Position entity, List<Expression<Func<Position, object>>> update = null, List<Expression<Func<Position, object>>> exclude = null);
        Position Delete(int id);
        Position Delete(Position entity);
        IEnumerable<PositionActionView> GetAll();
        PositionActionView GetEdit(int id);
        bool Edit(PositionActionView model);
        bool Add(PositionActionView model);
        bool StatusDelete(int id);
        void Save();
    }
   public class PositionBusiness : IPositionBusiness
    {
        private IPositionRepository _position;
        private IUnitOfWork _unitOfWork;
        public PositionBusiness(IPositionRepository position,IUnitOfWork unitOfWork)
        {
            _position = position;
            _unitOfWork = unitOfWork;
        }

        public Position Add(Position entity)
        {
            return _position.Add(entity);
        }

        public Position Delete(int id)
        {
            return _position.Delete(id);
        }

        public Position Delete(Position entity)
        {
            return _position.Delete(entity);
        }

        public IEnumerable<Position> GetAlls()
        {
            return _position.GetAll(null);
        }

        public IEnumerable<Position> GetAlls(string[] includes, Expression<Func<Position, bool>> filter)
        {
            return _position.GetAll(includes, filter);
        }

        public Position Update(Position entity, List<Expression<Func<Position, object>>> update = null, List<Expression<Func<Position, object>>> exclude = null)
        {
            return _position.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<PositionActionView> GetAll()
        {
            return _position.GetAll();
        }

        public PositionActionView GetEdit(int id)
        {
            return _position.GetEdit(id);
        }

        public bool Edit(PositionActionView model)
        {
            return _position.Edit(model);
        }

        public bool Add(PositionActionView model)
        {
            return _position.Add(model);
        }

        public bool StatusDelete(int id)
        {
            return _position.StatusDelete(id);
        }
    }
}
