using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IMemberLevelRepository : IRepository<MemberLevel>
    {
        IEnumerable<MemberLevelView> GetAll();
        MemberLevelView GetEdit(int id);
        bool Edit(MemberLevelView model);
        bool Add(MemberLevelView model);
        bool StatusDelete(int id);
    }
    public class MemberLevelRepository : RepositoryBase<MemberLevel>, IMemberLevelRepository
    {
        public MemberLevelRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(MemberLevelView model)
        {
            try
            {
                MemberLevel memberLevel = new MemberLevel();
                memberLevel.CreateBy = model.ActionBy;
                memberLevel.CreateDate = DateTime.Now;
                memberLevel.Desc = model.Desc;
                memberLevel.ModifyBy = model.ActionBy;
                memberLevel.ModifyDate = DateTime.Now;
                memberLevel.Name = model.Name;
                memberLevel.Point = model.Point;
                memberLevel.Rank = model.Rank;
                memberLevel.Status = model.Status;
                DbContext.MemberLevels.Add(memberLevel);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(MemberLevelView model)
        {
            try
            {
                var _item = DbContext.MemberLevels.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    _item.Desc = model.Desc;
                    _item.ModifyDate = DateTime.Now;
                    _item.ModifyBy = model.ActionBy;
                    _item.Name = model.Name;
                    _item.Point = model.Point;
                    _item.Rank = model.Rank;
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

        public IEnumerable<MemberLevelView> GetAll()
        {
            try
            {
                List<MemberLevelView> memberLevels = new List<MemberLevelView>();
                var _lst = DbContext.MemberLevels.Where(x => x.Status == true);
                if(_lst!=null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        MemberLevelView memberLevel = new MemberLevelView();
                        memberLevel.Desc = item.Desc;
                        memberLevel.ID = item.ID;
                        memberLevel.Name = item.Name;
                        memberLevel.Point = item.Point;
                        memberLevel.Rank = item.Rank;
                        memberLevels.Add(memberLevel);
                    }
                    return memberLevels;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public MemberLevelView GetEdit(int id)
        {
            try
            {
                var _item = DbContext.MemberLevels.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    MemberLevelView memberLevel = new MemberLevelView();
                    memberLevel.Desc = _item.Desc;
                    memberLevel.ID = _item.ID;
                    memberLevel.Name = _item.Name;
                    memberLevel.Point = _item.Point;
                    memberLevel.Rank = _item.Rank;
                    return memberLevel;
                }
                return new MemberLevelView();
            }
            catch (System.Exception)
            {

                return new MemberLevelView();
            }
        }

        public bool StatusDelete(int id)
        {
            try
            {
                var _item = DbContext.MemberLevels.Find(id);
                if(_item!=null && _item.ID != 0)
                {
                    _item.Status = false;
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
