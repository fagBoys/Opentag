using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.Core.DTOs.Admin;
using Berlance.Core.DTOs.Cart;
using Berlance.Core.DTOs.Payment;
using Berlance.Core.DTOs.Product;
using Berlance.Core.Services.Interfaces;
using Berlance.DataLayer.Context;
using Berlance.DataLayer.Entities.Cart;
using Berlance.DataLayer.Entities.Order;
using Berlance.DataLayer.Entities.Product;
using Berlance.DataLayer.Entities.Storage;
using Berlance.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Berlance.Core.Services
{
    public class OrderService : IOrderService
    {
        private BerLanceContext _context;
        private IUserService _userService;

        public OrderService(BerLanceContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public ResultDto AddOrder(string userName /*, int StorageId*/, RequestPayDto.RequestAddNewOrder request)
        {

            int UserId = _userService.GetUserIdByUserName(userName);
            User user = _userService.GetUserByUserName(userName);
            var requestPay = _context.RequestPays.Find(request.RequsetPayId);
            var cart = _context.Carts.Include(c => c.CartItems).ThenInclude(s => s.Storage)
                .FirstOrDefault(c => c.CartId == request.CartId);

            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.Authority = request.Authority;
            requestPay.RefId = request.RefId;
            cart.Finished = true;

            Order order = new Order()
            {
                ordarState = Order.OrdarState.Processing,
                RequestPay = requestPay,
                UserId = UserId,
                OrderDate = DateTime.Now,
                RequestId = requestPay.RequestId,
                Address = user.City + " " + user.Address
            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = item.Count,
                    StorageId = item.Storage.StorageId,
                    OrderId = order.OrderId,
                    Price = item.Price,
                };
                order.Sum += orderDetail.Price * orderDetail.Count;
                orderDetails.Add(orderDetail);
            }

            order.Sum += 22000;
            _context.Orders.Update(order);
            _context.OrderDetails.AddRange(orderDetails);
            _context.SaveChanges();

            //برای منها کردن تعداد محصولات سفارش داده در انبار
            var CountStorage = _context.OrderDetails
                .Where(s => s.OrderId == order.OrderId).Select(s => new { s.StorageId, s.Count });

            List<Storage> Storages = new List<Storage>();
            foreach (var item in CountStorage)
            {
                var currentStorage = _context.Storages.FirstOrDefault(s => s.StorageId == item.StorageId);
                currentStorage.CountProduct -= item.Count;
                Storages.Add(currentStorage);
            }

            _context.Storages.UpdateRange(Storages);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "پرداخت با موفقیت انجام شد.",
            };

            #region OldCode

            //Order order = _context.Orders.FirstOrDefault(o => o.UserId == UserId && !o.IsFinally);
            //var Storage = _context.Storages.Find(StorageId);

            //if (order == null)
            //{
            //    order = new Order()
            //    {
            //        UserId = UserId,
            //        IsFinally = false,
            //        OrderDate = DateTime.Now,
            //        Sum = Storage.Price,
            //        OrderDetails = new List<OrderDetail>()
            //            {
            //                new OrderDetail()
            //                {
            //                StorageId = StorageId,
            //                Count = 1,
            //                Price = Storage.Price
            //                }
            //            }
            //    };
            //    _context.Orders.Add(order);
            //    _context.SaveChanges();
            //}
            //else
            //{
            //    OrderDetail detail = _context.OrderDetails
            //        .FirstOrDefault(D => D.OrderId == order.OrderId && D.StorageId == StorageId);
            //    if (detail != null)
            //    {
            //        detail.Count += 1;
            //        //detail.Price = detail.Price * detail.Count;
            //        _context.OrderDetails.Update(detail);
            //        UpdatePriceOrder(order.OrderId);
            //    }
            //    else
            //    {
            //        detail = new OrderDetail()
            //        {
            //            OrderId = order.OrderId,
            //            Count = 1,
            //            StorageId = Storage.StorageId,
            //            Price = Storage.Price

            //        };
            //        _context.OrderDetails.Add(detail);
            //    }
            //    _context.SaveChanges();
            //    UpdatePriceOrder(order.OrderId);
            //}

            //return order.OrderId;

            #endregion

        }

        public void UpdatePriceOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);

            order.Sum = _context.OrderDetails.Where(D => D.OrderId == orderId).Sum(D => D.Price * D.Count);

            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public Order GetOrderForUserPanel(string userName, int OrderId)
        {
            int userId = _userService.GetUserIdByUserName(userName);
            return _context.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Storage).ThenInclude(S => S.Images)
                .FirstOrDefault(o => o.UserId == userId && o.OrderId == OrderId);
        }

        public bool FinalyOrder(string userName, int orderId)
        {
            int UserId = _userService.GetUserIdByUserName(userName);
            var order = _context.Orders.Include(o => o.OrderDetails)
                .ThenInclude(od => od.Storage).FirstOrDefault(o => o.OrderId == orderId && o.UserId == UserId);

            if (order == null /*|| order.IsFinally*/)
                return false;

            //order.IsFinally = true;
            order.OrderDate = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();


            //برای منها کردن تعداد محصولات سفارش داده در انبار
            var storage = _context.OrderDetails.Where(s => s.OrderId == orderId)
                .Select(s => new { s.StorageId, s.Count });

            foreach (var item in storage)
            {


                var currentStorage = _context.Storages.FirstOrDefault(s => s.StorageId == item.StorageId);

                currentStorage.CountProduct -= item.Count;
                _context.Storages.Update(currentStorage);
                _context.SaveChanges();
            }

            return true;

        }

        public List<Order> GetUserOrdes(string userName)
        {
            int userId = _userService.GetUserIdByUserName(userName);
            return _context.Orders.Where(O => O.UserId == userId).ToList();
        }

        public OrderDetail GetOrderDetailByid(int orderDetailId)
        {
            return _context.OrderDetails.Include(s => s.Storage).ThenInclude(p => p.Product).Include(s => s.Storage)
                .ThenInclude(i => i.Images).FirstOrDefault(p => p.OrderDetailId == orderDetailId);

        }

        #region Admin

        public ResultDto<List<OrderDto>> GetUserOrdersForAdmin(Order.OrdarState ordarState)
        {
            var orders = _context.Orders.Include(od => od.OrderDetails)
                .Where(o => o.ordarState == ordarState).OrderByDescending(o => o.OrderDate).ToList()
                .Select(o => new OrderDto()
                {
                    OrderRegistrationTime = o.OrderDate,
                    OrderId = o.OrderId,
                    OrdarState = o.ordarState,
                    ProductCount = o.OrderDetails.Count,
                    RequestId = o.RequestId,
                    UserId = o.UserId,
                    SumPrice = o.Sum
                }).ToList();
            return new ResultDto<List<OrderDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };
        }

        //public ResultDto<List<OrderDto>> GetAllUserOrdersForAdmin()
        public Tuple<List<OrderDto>, int> GetAllUserOrdersForAdmin(int pageId = 1, string TrackinCode = "", string Firstname = "", string LastName = "") 
        {
            //var orders = _context.Orders.Include(od => od.OrderDetails)
            //    .OrderByDescending(o => o.OrderDate).ToList()
            //    .Select(o => new OrderDto()
            //    {
            //        OrderRegistrationTime = o.OrderDate,
            //        OrderId = o.OrderId,
            //        OrdarState = o.ordarState,
            //        ProductCount = o.OrderDetails.Count,
            //        RequestId = o.RequestId,
            //        UserId = o.UserId,
            //        SumPrice = o.Sum
            //    }).ToList();
            //return new ResultDto<List<OrderDto>>()
            //{
            //    Data = orders,
            //    IsSuccess = true,
            //};

            IQueryable<Order> result = _context.Orders.Include(od => od.OrderDetails).Include(u=>u.OrderUser);

            if (!string.IsNullOrEmpty(TrackinCode))
            {
                result = result.Where(p => p.OrderId.ToString().Contains(TrackinCode));
            }
            if (!string.IsNullOrEmpty(Firstname))
            {
                result = result.Where(p => p.OrderUser.Firstname.Contains(Firstname));
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                result = result.Where(p => p.OrderUser.LastName.Contains(LastName));
            }

            int take = 10;

            int pageCount = result.Select(o => new OrderDto()
            {
                       OrderRegistrationTime = o.OrderDate,
                       OrderId = o.OrderId,
                       OrdarState = o.ordarState,
                       ProductCount = o.OrderDetails.Count,
                        RequestId = o.RequestId,
                        UserId = o.UserId,
                        SumPrice = o.Sum

            }).Count() / take;

            int skip = (pageId - 1) * take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }
            var query = result.OrderByDescending(o => o.OrderDate).Select(o => new OrderDto()
            {
                OrderRegistrationTime = o.OrderDate,
                OrderId = o.OrderId,
                OrdarState = o.ordarState,
                ProductCount = o.OrderDetails.Count,
                RequestId = o.RequestId,
                UserId = o.UserId,
                SumPrice = o.Sum

            }).Skip(skip).Take(take).ToList();
            return Tuple.Create(query, pageCount);
        }
        public List<OrderDetail> GetOrderDetailUserForAdmin(int orderId)
        {
          return _context.OrderDetails.Include(o=>o.Order).Include(s=>s.Storage).ThenInclude(i=>i.Images).Where(o => o.OrderId == orderId).ToList();
        }

        public int UpdateState(int orderId , Order.OrdarState state)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            order.ordarState = state;

            _context.Orders.Update(order);
            _context.SaveChanges();
            return order.OrderId;

        }

        public int GetCountOrders()
        {
            return _context.Orders.Count();
        }

        #endregion
    }
}
