using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.DTOs.Comment;
using Vira.DataLayer.Entities.Article;
using Microsoft.AspNetCore.Http;

namespace Vira.Core.Services.Interfaces
{
    public interface IArticleService
    {
        Tuple<List<Article>, int> GetAllArticle( int pageId = 1, string filter = "");
        Article GetArticleById(int ArticleId);

        List<Article> GetMostVisited();

        #region Admin

        int AddArticle(Article article, IFormFile imageArticle);
        int UpdateArticle(Article article, IFormFile imageArticle);
        void DeleteArticle(int id);
        #endregion

        #region Comments

        #region Admin

         void AddArticleAnswerComment(string Answer, int commentId, int userId);

         Tuple<List<ArticleComment>, int> GetAllArticleComment(int pageId = 1, string firstName = "",
             string lastName = "");

        Tuple<List<ArticleComment>, int> GetListArticleComments(int pageId = 1, string firstName = "",
             string lastName = "");
        void DeleteArticleComments(int Id);


        #endregion

         void AddComment(ArticleComment comment);

         Tuple<List<ShowCommentArticle>, int> GetArticleComment(int ArticleId, int pageId = 1);

         void AddLikeComment(int commentId  , string userName);
         int GetCountLikeCommentArticle(int commentId);


        #endregion
    }
}
