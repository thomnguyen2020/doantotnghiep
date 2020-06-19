using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        IEnumerable<PositionActionView> GetAll();
        PositionActionView GetEdit(int id);
        bool Edit(PositionActionView model);
        bool Add(PositionActionView model);
        bool StatusDelete(int id);
    }
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(PositionActionView model)
        {
            try
            {
                Position position = new Position();
                position.CreateBy = model.ActionBy;
                position.CreateDate = DateTime.Now;
                position.Desc = model.Desc;
                position.ModifyBy = model.ActionBy;
                position.ModifyDate = DateTime.Now;
                position.Status = model.Status;
                position.Title = model.Title;
                DbContext.Positions.Add(position);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Edit(PositionActionView model)
        {
            try
            {
                var _item = DbContext.Positions.Find(model.ID);
                if(_item!=null && _item.ID != 0)
                {
                    _item.Desc = model.Desc;
                    _item.ModifyBy = model.ActionBy;
                    _item.ModifyDate = DateTime.Now;
                    _item.Status = model.Status;
                    _item.Title = model.Title;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<PositionActionView> GetAll()
        {
            try
            {
                List<PositionActionView> positions = new List<PositionActionView>();
                var _lst = DbContext.Positions.Where(x => x.Status == true);
                if(_lst!=null && _lst.Count() > 0)
                {
                    foreach(var item in _lst)
                    {
                        PositionActionView position = new PositionActionView();
                        position.ActionBy = item.CreateBy;
                        position.Desc = item.Desc;
                        position.ID = item.ID;
                        position.Status = item.Status;
                        position.Title = item.Title;
                        positions.Add(position);
                    }
                    return positions;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public PositionActionView GetEdit(int id)
        {
            try
            {
                var _item = DbContext.Positions.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    PositionActionView position = new PositionActionView();
                    position.ActionBy = _item.CreateBy;
                    position.Desc = _item.Desc;
                    position.ID = _item.ID;
                    position.Status = _item.Status;
                    position.Title = _item.Title;
                    return position;
                }
                    return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool StatusDelete(int id)
        {
            try
            {
                Position position = DbContext.Positions.Find(id);
                if (position != null)
                {
                    position.Status = false;
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
