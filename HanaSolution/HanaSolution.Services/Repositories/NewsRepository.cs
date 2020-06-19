using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface INewsRepository : IRepository<News>
    {
        IEnumerable<NewsView> GetAll();
        NewsView GetView(long id);
        NewsAction GetEdit(long id);
        bool Edit(NewsAction model);
        bool Add(NewsAction model);
        bool StatusDelete(long id);
    }
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(NewsAction model)
        {
            try
            {
                News news = new News();
                news.Avatar = "http://localhost:44351/" + model.Avatar;
                news.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                news.CreateBy = model.CreateBy;
                news.CreateDate = DateTime.Now;
                news.Desc = model.Desc;
                news.ID = model.ID;
                news.MetaDesc = model.MetaDesc;
                news.MetaKeyword = model.MetaKeyword;
                news.MetaTitle = model.MetaTitle;
                news.ModifyBy = model.ModifyBy;
                news.ModifyDate = DateTime.Now;
                news.Status = model.Status;
                news.Title = model.Title;
                news.ViewNumber = 0;
                DbContext.News.Add(news);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(NewsAction model)
        {
            try
            {
                var _item = DbContext.News.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    if (!model.Avatar.Contains("http"))
                        _item.Avatar = "http://localhost:44351/" + model.Avatar;
                    else
                        _item.Avatar = model.Avatar;
                    _item.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                    _item.Desc = model.Desc;
                    _item.MetaDesc = model.MetaDesc;
                    _item.MetaKeyword = model.MetaKeyword;
                    _item.MetaTitle = model.MetaTitle;
                    _item.ModifyBy = model.ModifyBy;
                    _item.ModifyDate = DateTime.Now;
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

        public IEnumerable<NewsView> GetAll()
        {
            try
            {
                List<NewsView> news = new List<NewsView>();
                var _lst = from n in DbContext.News
                           where n.Status == true
                           select new
                           {
                               ID = n.ID,
                               Title = n.Title,
                               Avatar = n.Avatar,
                               Desc = n.Desc,
                               Content = n.Content,
                               ViewNumber = n.ViewNumber,
                               MetaTitle = n.MetaTitle,
                               MetaDesc = n.MetaDesc,
                               MetaKeyword = n.MetaKeyword
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        NewsView view = new NewsView();
                        view.Avatar = item.Avatar;
                        view.Content = item.Content;
                        view.Desc = item.Desc;
                        view.ID = item.ID;
                        view.MetaDesc = item.MetaDesc;
                        view.MetaKeyword = item.MetaKeyword;
                        view.MetaTitle = item.MetaTitle;
                        view.Title = item.Title;
                        view.ViewNumber = item.ViewNumber;
                        news.Add(view);
                    }
                    return news;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public NewsAction GetEdit(long id)
        {
            try
            {
                var _item = DbContext.News.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    NewsAction news = new NewsAction();
                    news.Avatar = _item.Avatar;
                    news.Content = _item.Content;
                    news.CreateBy = _item.CreateBy;
                    news.Desc = _item.Desc;
                    news.ID = _item.ID;
                    news.MetaDesc = _item.MetaDesc;
                    news.MetaKeyword = _item.MetaKeyword;
                    news.MetaTitle = _item.MetaTitle;
                    news.ModifyBy = _item.ModifyBy;
                    news.Status = _item.Status;
                    news.Title = _item.Title;
                    news.ViewNumber = _item.ViewNumber;
                    return news;
                }
                return new NewsAction();
            }
            catch (System.Exception)
            {

                return new NewsAction();
            }
        }

        public NewsView GetView(long id)
        {
            try
            {
                var _item = DbContext.News.Find(id);
                if(_item!=null && _item.ID != 0)
                {
                    NewsView news = new NewsView();
                    news.Avatar = _item.Avatar;
                    news.Content = _item.Content;
                    news.Desc = _item.Desc;
                    news.ID = _item.ID;
                    news.MetaDesc = _item.MetaDesc;
                    news.MetaKeyword = _item.MetaKeyword;
                    news.MetaTitle = _item.MetaTitle;
                    news.Title = _item.Title;
                    news.ViewNumber = _item.ViewNumber;
                    return news;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool StatusDelete(long id)
        {
            try
            {
                News news = DbContext.News.Find(id);
                if (news != null)
                {
                    news.Status = false;
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
