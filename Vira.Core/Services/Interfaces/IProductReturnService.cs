using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.DataLayer.Entities.ProductReturn;
using Microsoft.AspNetCore.Http;

namespace Berlance.Core.Services.Interfaces
{
    public interface IProductReturnService
    {
         ProductReturn GetDitaileProductReturn(int returnId);

        #region UserPanel

         bool SearchProductReturn(int orderDetailId);
         int AddProductReturn(ProductReturn productReturn, IFormFile imageProductReturn);

         List<ProductReturn> GetListProductReturns(int userId);
        #endregion

        #region Admin
        Tuple<List<ProductReturn>, int> GetListProductReturnsForAdmin(int pageId = 1, string userName = "", string returnId = "");
        void Confirmationbyadmin(int returnId, bool verified);

        #endregion

    }
}
