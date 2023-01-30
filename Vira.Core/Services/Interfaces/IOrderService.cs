using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.Core.DTOs.Admin;
using Berlance.Core.DTOs.Cart;
using Berlance.Core.DTOs.Payment;
using Berlance.DataLayer.Entities.Order;

namespace Berlance.Core.Services.Interfaces
{
    public interface IOrderService
    {
        ResultDto AddOrder(string userName , RequestPayDto.RequestAddNewOrder request);
        void UpdatePriceOrder(int orderId);
        Order GetOrderForUserPanel(string userName, int OrderId);
        bool FinalyOrder(string userName , int orderId);
        List<Order> GetUserOrdes(string userName);
        OrderDetail GetOrderDetailByid(int orderDetailId);

        #region Admin

        ResultDto<List<OrderDto>> GetUserOrdersForAdmin(Order.OrdarState ordarState);

        Tuple<List<OrderDto>, int> GetAllUserOrdersForAdmin(int pageId = 1, string TrackinCode = "",
            string Firstname = "", string LastName = "");
        List<OrderDetail> GetOrderDetailUserForAdmin(int OrderId);
        int UpdateState(int orderId, Order.OrdarState state);
        int GetCountOrders();

        #endregion

    }
}
