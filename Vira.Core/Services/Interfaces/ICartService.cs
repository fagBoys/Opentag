using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.Core.DTOs.Cart;
using Berlance.DataLayer.Entities.Cart;
using Berlance.DataLayer.Migrations;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Berlance.Core.Services.Interfaces
{
    public interface ICartService
    {
        ResultDto AddToCart(int storageId , Guid browserId, string? userName);
        ResultDto AddToCartWithCount(int storageId, int count, Guid browserId, string? userName);

        ResultDto DeleteFromCart(int storageId , Guid browserId, int? userId);
        ResultDto<GetMyCart.CartDto> GetMyCart(Guid browserId, int userId);

        ResultDto AddCountProduct(int CartItemId);

        ResultDto LowOffCountProduct(int CartItemId);
        Cart GetCartById(int CartId);
        ResultDto CheckedAccount(string userName);


        #region Discount

        DiscountUseType UseDiscount(int cartId, string code);

         void AddDisCount(Discount discount);
         List<Discount> GetAllDiscounts();
         Discount GetDiscountById(int id);
         void UpdateDisCount(Discount discount);
         bool IsExistCode(string code);



        #endregion
    }
}
