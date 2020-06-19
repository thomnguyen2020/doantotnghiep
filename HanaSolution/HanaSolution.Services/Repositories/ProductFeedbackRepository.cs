using HanaSolution.Data.Models;
using HanaSolution.Data.ViewModels;
using HanaSolution.Services.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace HanaSolution.Services.Repositories
{
    public interface IProductFeedbackRepository : IRepository<ProductFeedback>
    {
        IEnumerable<ProductFeedbackView> GetAll(long id);
        ProductFeedbackView GetById(long id);
        bool StatusUpdate(long id, int status);
    }
    public class ProductFeedbackRepository : RepositoryBase<ProductFeedback>, IProductFeedbackRepository
    {
        public ProductFeedbackRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<ProductFeedbackView> GetAll(long id)
        {
            try
            {
                List<ProductFeedbackView> feedbacks = new List<ProductFeedbackView>();
                var _lst = from f in DbContext.ProductFeedbacks
                           from m in DbContext.Members
                           from p in DbContext.Products
                           where f.Product == p.ID
                           && p.ID == id
                           && f.Member == m.ID
                           select new
                           {
                               ID = f.ID,
                               Product = p.Title,
                               Rate = f.Rate,
                               Comment = f.Comment,
                               Files = f.Files,
                               Member = m.Name,
                               Status = f.Status,
                               Date = f.Date
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        ProductFeedbackView feedback = new ProductFeedbackView();
                        feedback.Comment = item.Comment;
                        feedback.Date = item.Date;
                        feedback.Files = item.Files;
                        feedback.ID = item.ID;
                        feedback.Member = item.Member;
                        feedback.Product = item.Product;
                        feedback.Rate = item.Rate;
                        feedback.Status = item.Status;
                        feedbacks.Add(feedback);
                    }
                    return feedbacks;
                }
                return null;

            }
            catch (System.Exception)
            {

                return null;
            }
        }


        public ProductFeedbackView GetById(long id)
        {
            try
            {
                var _item = (from f in DbContext.ProductFeedbacks
                             from m in DbContext.Members
                             from p in DbContext.Products
                             where f.Product == p.ID
                             && f.Member == m.ID
                             && f.ID == id
                             select new
                             {
                                 ID = f.ID,
                                 Product = p.Title,
                                 Rate = f.Rate,
                                 Comment = f.Comment,
                                 Files = f.Files,
                                 Member = m.Name,
                                 Status = f.Status,
                                 Date = f.Date
                             }).FirstOrDefault();
                if (_item != null)
                {
                    ProductFeedbackView feedback = new ProductFeedbackView();
                    feedback.Comment = _item.Comment;
                    feedback.Date = _item.Date;
                    feedback.Files = _item.Files;
                    feedback.ID = _item.ID;
                    feedback.Member = _item.Member;
                    feedback.Product = _item.Product;
                    feedback.Rate = _item.Rate;
                    feedback.Status = _item.Status;
                    return feedback;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }

        public bool StatusUpdate(long id, int status)
        {
            try
            {
                var _item = DbContext.ProductFeedbacks.Find(id);
                if (_item != null && _item.Status != status && _item.Status < status)
                {
                    _item.Status = status;
                    return true;
                }
                else
                    return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
