using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
namespace HanaSolution.Services.Repositories
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        IEnumerable<PromotionView> GetAll(long id);
        IEnumerable<PromotionView> GetAll();
        IEnumerable<PromotionAdminView> Gets();
        PromotionAdminView GetDetail(long id);
        PromotionActionView GetByID(long id);
        bool Add(PromotionActionView model);

        bool Edit(PromotionActionView model);
        bool Delete(long id);
    }
    public class PromotionRepository : RepositoryBase<Promotion>, IPromotionRepository
    {
        public PromotionRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(PromotionActionView model)
        {
            try
            {
                int year, month, day;
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                if (model.StartDate == "" || model.EndDate == "")
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                    day = DateTime.Now.Day;
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = DateTime.Now.AddYears(1).Year;
                    month = DateTime.Now.AddYears(1).Month;
                    day = DateTime.Now.AddYears(1).Day;
                    end = new DateTime(year, month, day, 23, 59, 0);
                }
                else
                {
                    year = Convert.ToInt32(model.StartDate.Split('/')[2]);
                    month = Convert.ToInt32(model.StartDate.Split('/')[1]);
                    day = Convert.ToInt32(model.StartDate.Split('/')[0]);
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = Convert.ToInt32(model.EndDate.Split('/')[2]);
                    month = Convert.ToInt32(model.EndDate.Split('/')[1]);
                    day = Convert.ToInt32(model.EndDate.Split('/')[0]);
                    end = new DateTime(year, month, day, 0, 0, 0);
                }

                Promotion promotion = new Promotion();
                promotion.Avatar = "http://localhost:44351" + model.Avatar;
                promotion.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                promotion.Desc = model.Desc;
                promotion.EndAge = model.EndAge;
                promotion.EndDate = end;
                promotion.Gender = model.Gender;
                promotion.ID = model.ID;
                promotion.Limit = model.Limit;
                promotion.MemberLevel = model.MemberLevel;
                promotion.MemberPoint = model.MemberPoint;
                promotion.StartAge = model.StartAge;
                promotion.StartDate = start;
                promotion.Status = model.Status;
                promotion.Title = model.Title;
                promotion.Type = model.Type;
                promotion.Staff = model.Staff;
                promotion.Code = model.Code;

                DbContext.Promotions.Add(promotion);

                return true;
            }
            catch (System.Exception ex)
            {

                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                Promotion promotion = DbContext.Promotions.Find(id);
                if (promotion != null)
                {
                    promotion.Status = false;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Edit(PromotionActionView model)
        {
            try
            {
                int year, month, day;
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                if (model.StartDate == "" || model.EndDate == "")
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                    day = DateTime.Now.Day;
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = DateTime.Now.AddYears(1).Year;
                    month = DateTime.Now.AddYears(1).Month;
                    day = DateTime.Now.AddYears(1).Day;
                    end = new DateTime(year, month, day, 23, 59, 0);
                }
                else
                {
                    year = Convert.ToInt32(model.StartDate.Split('/')[2]);
                    month = Convert.ToInt32(model.StartDate.Split('/')[1]);
                    day = Convert.ToInt32(model.StartDate.Split('/')[0]);
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = Convert.ToInt32(model.EndDate.Split('/')[2]);
                    month = Convert.ToInt32(model.EndDate.Split('/')[1]);
                    day = Convert.ToInt32(model.EndDate.Split('/')[0]);
                    end = new DateTime(year, month, day, 0, 0, 0);
                }

                Promotion promotion = DbContext.Promotions.Find(model.ID);
                if (promotion != null)
                {
                    if (!model.Avatar.Contains("http"))
                        promotion.Avatar = "http://localhost:44351" + model.Avatar;
                    else
                        promotion.Avatar = model.Avatar;
                    promotion.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                    promotion.Desc = model.Desc;
                    promotion.EndAge = model.EndAge;
                    promotion.EndDate = end;
                    promotion.Gender = model.Gender;
                    promotion.Limit = model.Limit;
                    promotion.MemberLevel = model.MemberLevel;
                    promotion.MemberPoint = model.MemberPoint;
                    promotion.StartAge = model.StartAge;
                    promotion.StartDate = start;
                    promotion.Status = model.Status;
                    promotion.Title = model.Title;
                    promotion.Type = model.Type;
                    promotion.Staff = model.Staff;
                    promotion.Code = model.Code;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }


        public IEnumerable<PromotionView> GetAll(long id)
        {
            try
            {
                List<PromotionView> promotions = new List<PromotionView>();
                var _lst = from p in DbContext.Promotions
                           where p.EndDate >= DateTime.Now
                           && p.Staff == id
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Avatar = p.Avatar,
                               Desc = p.Desc,
                               Content = p.Content,
                               StartDate = p.StartDate,
                               EndDate = p.EndDate,
                               Type = p.Type,
                               Code = p.Code
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        PromotionView promotion = new PromotionView();
                        promotion.Avatar = item.Avatar;
                        promotion.Content = item.Content;
                        promotion.Desc = item.Desc;
                        promotion.EndDate = item.EndDate;
                        promotion.ID = item.ID;
                        promotion.StartDate = item.StartDate;
                        promotion.Title = item.Title;
                        promotion.Type = item.Type;
                        promotion.Code = item.Code;
                        promotions.Add(promotion);
                    }
                    return promotions;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public IEnumerable<PromotionView> GetAll()
        {
            try
            {
                List<PromotionView> promotions = new List<PromotionView>();
                var _lst = from p in DbContext.Promotions
                           where p.EndDate >= DateTime.Now
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Avatar = p.Avatar,
                               Desc = p.Desc,
                               Content = p.Content,
                               StartDate = p.StartDate,
                               EndDate = p.EndDate,
                               Type = p.Type,
                               Code = p.Code
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        PromotionView promotion = new PromotionView();
                        promotion.Avatar = item.Avatar;
                        promotion.Content = item.Content;
                        promotion.Desc = item.Desc;
                        promotion.EndDate = item.EndDate;
                        promotion.ID = item.ID;
                        promotion.StartDate = item.StartDate;
                        promotion.Title = item.Title;
                        promotion.Type = item.Type;
                        promotion.Code = item.Code;
                        promotions.Add(promotion);
                    }
                    return promotions;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public PromotionActionView GetByID(long id)
        {
            try
            {
                var _item = DbContext.Promotions.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    PromotionActionView promotion = new PromotionActionView();
                    promotion.Avatar = _item.Avatar;
                    promotion.Content = _item.Content;
                    promotion.Desc = _item.Desc;
                    promotion.EndDate = String.Format("{0:dd/MM/yyyy}", _item.EndDate);
                    promotion.ID = _item.ID;
                    promotion.StartDate = String.Format("{0:dd/MM/yyyy}", _item.StartDate);
                    promotion.Title = _item.Title;
                    promotion.Type = _item.Type;
                    promotion.Limit = _item.Limit;
                    promotion.MemberLevel = _item.MemberLevel;
                    promotion.MemberPoint = _item.MemberPoint;
                    promotion.StartAge = _item.StartAge;
                    promotion.EndAge = _item.EndAge;
                    promotion.Gender = _item.Gender;
                    promotion.Status = _item.Status;
                    promotion.Code = _item.Code;
                    return promotion;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public PromotionAdminView GetDetail(long id)
        {
            try
            {
                var _item = (from p in DbContext.Promotions
                             from v in DbContext.Staffs
                             where p.EndDate >= DateTime.Now
                             && p.Staff == v.ID
                             && p.Status == true
                             && p.ID == id
                             select new
                             {
                                 ID = p.ID,
                                 Title = p.Title,
                                 Avatar = p.Avatar,
                                 Desc = p.Desc,
                                 Content = p.Content,
                                 StartDate = p.StartDate,
                                 EndDate = p.EndDate,
                                 Type = p.Type,
                                 Code = p.Code,
                                 Staff = v.Name
                             }).FirstOrDefault();
                if (_item != null && _item.ID != 0)
                {
                    PromotionAdminView promotion = new PromotionAdminView();
                    promotion.Avatar = _item.Avatar;
                    promotion.Content = _item.Content;
                    promotion.Desc = _item.Desc;
                    promotion.EndDate = _item.EndDate;
                    promotion.ID = _item.ID;
                    promotion.StartDate = _item.StartDate;
                    promotion.Title = _item.Title;
                    promotion.Type = _item.Type;
                    promotion.Code = _item.Code;
                    promotion.Staff = _item.Staff;
                    return promotion;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public IEnumerable<PromotionAdminView> Gets()
        {
            try
            {
                List<PromotionAdminView> promotions = new List<PromotionAdminView>();
                var _lst = from p in DbContext.Promotions
                           from v in DbContext.Staffs
                           where p.EndDate >= DateTime.Now
                           && p.Staff == v.ID
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Avatar = p.Avatar,
                               Desc = p.Desc,
                               Content = p.Content,
                               StartDate = p.StartDate,
                               EndDate = p.EndDate,
                               Type = p.Type,
                               Code = p.Code,
                               Staff = v.Name
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        PromotionAdminView promotion = new PromotionAdminView();
                        promotion.Avatar = item.Avatar;
                        promotion.Content = item.Content;
                        promotion.Desc = item.Desc;
                        promotion.EndDate = item.EndDate;
                        promotion.ID = item.ID;
                        promotion.StartDate = item.StartDate;
                        promotion.Title = item.Title;
                        promotion.Type = item.Type;
                        promotion.Code = item.Code;
                        promotion.Staff = item.Staff;
                        promotions.Add(promotion);
                    }
                    return promotions;
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
