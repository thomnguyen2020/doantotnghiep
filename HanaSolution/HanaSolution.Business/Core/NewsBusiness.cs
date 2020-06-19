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
    public interface INewsBusiness
    {
        IEnumerable<News> GetAlls(string[] includes, Expression<Func<News, bool>> filter);
        IEnumerable<News> GetAlls();
        News Add(News entity);
        News Update(News entity, List<Expression<Func<News, object>>> update = null, List<Expression<Func<News, object>>> exclude = null);
        News Delete(int id);
        News Delete(News entity);
        IEnumerable<NewsView> GetAll();
        NewsAction GetEdit(long id);
        NewsView GetView(long id);
        bool Edit(NewsAction model);
        bool Add(NewsAction model);
        bool StatusDelete(long id);
        void Save();
    }
   public class NewsBusiness : INewsBusiness
    {
        private INewsRepository _news;
        private IUnitOfWork _unitOfWork;
        public NewsBusiness(INewsRepository news,IUnitOfWork unitOfWork)
        {
            _news = news;
            _unitOfWork = unitOfWork;
        }

        public News Add(News entity)
        {
            return _news.Add(entity);
        }

        public News Delete(int id)
        {
            return _news.Delete(id);
        }

        public News Delete(News entity)
        {
            return _news.Delete(entity);
        }

        public IEnumerable<News> GetAlls()
        {
            return _news.GetAll(null);
        }

        public IEnumerable<News> GetAlls(string[] includes, Expression<Func<News, bool>> filter)
        {
            return _news.GetAll(includes, filter);
        }

        public News Update(News entity, List<Expression<Func<News, object>>> update = null, List<Expression<Func<News, object>>> exclude = null)
        {
            return _news.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<NewsView> GetAll()
        {
            return _news.GetAll();
        }

        public NewsAction GetEdit(long id)
        {
            return _news.GetEdit(id);
        }

        public bool Edit(NewsAction model)
        {
            return _news.Edit(model);
        }

        public bool Add(NewsAction model)
        {
            return _news.Add(model);
        }

        public bool StatusDelete(long id)
        {
            return _news.StatusDelete(id);
        }

        public NewsView GetView(long id)
        {
            return _news.GetView(id);
        }
    }
}
