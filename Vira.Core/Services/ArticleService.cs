using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.Convertors;
using Vira.Core.DTOs.Comment;
using Vira.Core.DTOs.Notification;
using Vira.Core.Generator;
using Vira.Core.Security;
using Vira.Core.Senders;
using Vira.Core.Services.Interfaces;
using Vira.DataLayer.Context;
using Vira.DataLayer.Entities.Article;
using Vira.DataLayer.Entities.Product;
using Vira.DataLayer.Entities.Storage;
using Vira.DataLayer.Entities.User;
using Vira.DataLayer.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Article = Vira.DataLayer.Entities.Article.Article;

namespace Vira.Core.Services
{
    public class ArticleService : IArticleService
    {
        private ViraContext _context;
        private IViewRenderService _viewRender;
        private IUserService _userService;


        public ArticleService(ViraContext context, IViewRenderService viewRender, IUserService userService)
        {
            _context = context;
            _viewRender = viewRender;
            _userService = userService;
        }

        public Tuple<List<Article>, int> GetAllArticle(int pageId = 1, string filter = "")
        {
            //10 Shod
            int take = 4;
            int skip = (pageId - 1) * take;

            IQueryable<Article> result = _context.Articles;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.Description.Contains(filter) || p.Title.Contains(filter) || p.Type.Contains(filter) || p.Title2.Contains(filter) || p.Tage.Contains(filter));

            }
            int pageCount = result.Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);

        }

        public Article GetArticleById(int ArticleId)
        {

            var article = _context.Articles.Find(ArticleId);
            article.View++;
            _context.Articles.Update(article);
            _context.SaveChanges();

            return article;
        }

        public List<Article> GetMostVisited()
        {
            return _context.Articles.OrderBy(a => a.View).Take(2).ToList();
        }


        #region Admin


        public int AddArticle(Article article, IFormFile imageArticle)
        {
            article.View = 1;
            article.ImageName = "no-photo.jpg";
            if (imageArticle != null && imageArticle.IsImage())
            {
                article.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imageArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Article/Image", article.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageArticle.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string tumnpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Article/Thumb", article.ImageName);
                imgResizer.Image_resize(imagePath, tumnpath, 374);
            }

            _context.Articles.Add(article);
            _context.SaveChanges();

            #region SendMailNotification

            var Notfications = _context.ArticleNotifications.ToList();

            if (Notfications != null)
            {
                foreach (var item in Notfications)
                {
                    #region Send Activation Email

                    string body = _viewRender.RenderToStringAsync("_Notification", item.Email);
                    SendEmail.Send(item.Email, "مقالات", body);

                    #endregion
                }




            }
            #endregion

            return article.ArticleId;

        }

        public int UpdateArticle(Article article, IFormFile imageArticle)
        {
            if (imageArticle != null && imageArticle.IsImage())
            {

                if (article.ImageName != "no-photo.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Article/Image", article.ImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Article/Thumb", article.ImageName);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }

                }

                article.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imageArticle.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Article/Image", article.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageArticle.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string tumnpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Article/Thumb", article.ImageName);
                imgResizer.Image_resize(imagePath, tumnpath, 274);
            }


            _context.Articles.Update(article);
            _context.SaveChanges();
            return article.ArticleId;
        }

        public void DeleteArticle(int id)
        {
            Article article = _context.Articles.Find(id);

            string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Article/Image", article.ImageName);
            if (File.Exists(deleteimagePath))
            {
                File.Delete(deleteimagePath);
            }

            string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Article/Thumb", article.ImageName);
            if (File.Exists(deletethumbPath))
            {
                File.Delete(deletethumbPath);
            }

            _context.Articles.Remove(article);
            _context.SaveChanges();

        }


        #endregion

        #region Comments

        #region Admin


        public void AddArticleAnswerComment(string Answer, int commentId, int userId)
        {
            ArticleAnswerComment answerComments = new ArticleAnswerComment()
            {
                UserId = userId,
                CommentID = commentId,
                Answer = Answer,
                CreateDate = DateTime.Now
            };

            _context.ArticleAnswerComments.Add(answerComments);
            _context.SaveChanges();

            var articleComment = _context.ArticleComments.FirstOrDefault(pc => pc.CommentId == commentId);
            articleComment.AnswerId = answerComments.AnswerId;
            articleComment.IsAdminRead = true;
            _context.ArticleComments.Update(articleComment);
            _context.SaveChanges();

        }

        public Tuple<List<ArticleComment>, int> GetAllArticleComment(int pageId = 1,string firstName = "", string lastName = "")
        {
            int take = 5;
            int skip = (pageId - 1) * take;

            //int pageCount = _context.ProductComments.Where(pc => !pc.IsDelete && pc.ProductId == productId).Count() / take;

            IQueryable<ArticleComment> result = _context.ArticleComments.Include(a => a.User).Include(a => a.ArticleAnswerComment).OrderByDescending(c => c.CarateDateTime).Where(c => c.ArticleAnswerComment == null);

            if (!string.IsNullOrEmpty(firstName))
            {
                result = result.Where(p => p.User.Firstname.Contains(firstName));

            }
            if (!string.IsNullOrEmpty(lastName))
            {
                result = result.Where(p => p.User.LastName.Contains(lastName));

            }

            int pageCount = result.Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);

            //return Tuple.Create(_context.ProductComments.Include(u => u.User)
            //    .Where(pc => !pc.IsDelete && pc.ProductId == productId).Skip(skip).Take(take)
            //    .OrderByDescending(c => c.CommentId).ToList(), pageCount);
        }

        public Tuple<List<ArticleComment>, int> GetListArticleComments(int pageId = 1, string firstName = "", string lastName = "")
        {
            int take = 5;
            int skip = (pageId - 1) * take;

            IQueryable<ArticleComment> result = _context.ArticleComments.Include(U => U.User);
            if (!string.IsNullOrEmpty(firstName))
            {
                result = result.Where(p => p.User.Firstname.Contains(firstName));

            }
            if (!string.IsNullOrEmpty(lastName))
            {
                result = result.Where(p => p.User.LastName.Contains(lastName));

            }
            int pageCount = result.Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
            //return _context.ArticleComments.Include(i=>i.User).ToList();
        }

        public void DeleteArticleComments(int Id)
        {
            ArticleComment articleComment = _context.ArticleComments.FirstOrDefault(pc => pc.CommentId == Id);
            articleComment.IsDelete = true;
            _context.ArticleComments.Update(articleComment);
            _context.SaveChanges();
        }

        #endregion


        public void AddComment(ArticleComment comment)
        {
            _context.ArticleComments.Add(comment);
            _context.SaveChanges();
        }

        public Tuple<List<ShowCommentArticle>, int> GetArticleComment(int ArticleId, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            //int pageCount = _context.ProductComments.Where(pc => !pc.IsDelete && pc.ProductId == productId).Count() / take;

            IQueryable<ArticleComment> result = _context.ArticleComments;
            int pageCount = result.Include(s => s.User).Include(a => a.ArticleAnswerComment).Where(p => p.ArticleId == ArticleId).Select(c => new ShowCommentArticle()
            {
                //ArticleComments = _context.ArticleComments.Include(u=>u.User).Where(c => c.ArticleId == ArticleId).ToList(),
                //ArticleAnswerComments = _context.ArticleAnswerComments.Include(u => u.User).Where(a => a.ArticleComment.ArticleId== ArticleId).ToList(),
                UserAvatar = c.User.UserAvatar,
                ArticleAnswerComment = c.ArticleAnswerComment.Answer,
                ArticleComment = c.Comment,
                ArticleCommentId = c.CommentId,
                CarateDateTime = c.CarateDateTime,
                UserName = c.User.UserName,
                ArticleId = c.ArticleId
            }).Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Include(s => s.User).Include(a => a.ArticleAnswerComment).Where(p => p.ArticleId == ArticleId).OrderByDescending(c => c.CarateDateTime).Select(c => new ShowCommentArticle()
            {
                //ArticleComments = _context.ArticleComments.Include(u => u.User).Where(c => c.ArticleId == ArticleId).ToList(),
                //ArticleAnswerComments = _context.ArticleAnswerComments.Include(u => u.User).Where(a => a.ArticleComment.ArticleId == ArticleId).ToList(),

                UserAvatar = c.User.UserAvatar,
                ArticleAnswerComment = c.ArticleAnswerComment.Answer,
                ArticleComment = c.Comment,
                ArticleCommentId = c.CommentId,
                CarateDateTime = c.CarateDateTime,
                UserName = c.User.UserName,
                ArticleId = c.ArticleId


            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }


        #region Like

        public void AddLikeComment(int commentId, string userName)
        {
            var userid = _userService.GetUserIdByUserName(userName);
            if (_context.ArticleCommentLikes.Any(l => l.CommentId == commentId && l.UserId == userid))
            {

                ArticleCommentLike articlelike = new ArticleCommentLike();
                articlelike = _context.ArticleCommentLikes.FirstOrDefault(l => l.CommentId == commentId && l.UserId == userid);
                _context.ArticleCommentLikes.Remove(articlelike);
                _context.SaveChanges();

            }
            else
            {


                ArticleCommentLike articlelike = new ArticleCommentLike();
                articlelike.UserId = userid;
                articlelike.CommentId = commentId;


                _context.ArticleCommentLikes.Add(articlelike);
                _context.SaveChanges();
            }
        }

        public int GetCountLikeCommentArticle(int commentId)
        {
            return _context.ArticleCommentLikes.Count(l => l.CommentId == commentId);
        }

        #endregion


        #endregion


    }
}
