using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.DTOs.Admin;
using Vira.Core.DTOs.Cart;
using Vira.Core.DTOs.Payment;
using Vira.DataLayer.Entities.Order;

namespace Vira.Core.Services.Interfaces
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
