using Microsoft.EntityFrameworkCore;
using Opentag.Data;
using Opentag.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opentag
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }

        public int TotalPage { get; private set; }

        public IEnumerable<IndexArticlesViewModel> Articles { get; set; }


        public PaginatedList(List<T> items, int count, int PageIndex, int PageSize)
        {
            ApplicationDbContext Context = new ApplicationDbContext();

            Articles = Context.Article.OrderByDescending(A => A.ArticleId).Take(4).Select(A =>
            new IndexArticlesViewModel
            {

                ArticleId = A.ArticleId,
                ArticleTitle = A.Title

            }).ToList();

            this.PageIndex = PageIndex;
            this.TotalPage = (int)Math.Ceiling(count / (double)PageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPage);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsunc(IQueryable<T> source, int PageIndex, int PageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            return new PaginatedList<T>(items, count, PageIndex, PageSize);
        }
    }
}
