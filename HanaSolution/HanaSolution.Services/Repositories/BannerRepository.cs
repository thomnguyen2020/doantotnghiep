using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IBannerRepository : IRepository<Banner>
    {
        IEnumerable<BannerActionView> GetAll();
        BannerActionView GetEdit(int id);
        bool Edit(BannerActionView model);
        bool Add(BannerActionView model);
        bool StatusDelete(int id);
    }
    public class BannerRepository : RepositoryBase<Banner>, IBannerRepository
    {
        public BannerRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(BannerActionView model)
        {
            try
            {
                Banner banner = new Banner();
                if (!model.Avatar.Contains("http"))
                    banner.Avatar = "http://localhost:44351/" + model.Avatar;
                else
                    banner.Avatar = model.Avatar;
                banner.Desc = model.Desc;
                banner.Status = model.Status;
                DbContext.Banners.Add(banner);
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Edit(BannerActionView model)
        {
            try
            {
                var _item = DbContext.Banners.Find(model.ID);
                if(_item!=null && _item.ID != 0)
                {
                    _item.Desc = model.Desc;
                    if (!model.Avatar.Contains("http"))
                        _item.Avatar = "http://localhost:44351/" + model.Avatar;
                    else
                        _item.Avatar = model.Avatar;
                    _item.Status = model.Status;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<BannerActionView> GetAll()
        {
            try
            {
                List<BannerActionView> banners = new List<BannerActionView>();
                var _lst = DbContext.Banners.Where(x => x.Status == true);
                if(_lst!=null && _lst.Count() > 0)
                {
                    foreach(var item in _lst)
                    {
                        BannerActionView banner = new BannerActionView();
                        banner.Avatar = item.Avatar;
                        banner.Desc = item.Desc;
                        banner.ID = item.ID;
                        banner.Status = item.Status;
                        banners.Add(banner);
                    }
                    return banners;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public BannerActionView GetEdit(int id)
        {
            try
            {
                var _item = DbContext.Banners.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    BannerActionView banner = new BannerActionView();
                    banner.Avatar = _item.Avatar;
                    banner.Desc = _item.Desc;
                    banner.ID = _item.ID;
                    banner.Status = _item.Status;
                    return banner;
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
                Banner banner = DbContext.Banners.Find(id);
                if (banner != null)
                {
                    banner.Status = false;
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
