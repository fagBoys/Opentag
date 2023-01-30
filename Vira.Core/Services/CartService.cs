using Vira.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.DTOs.Cart;
using Vira.DataLayer.Context;
using Vira.DataLayer.Entities.Cart;
using Vira.DataLayer.Entities.User;
using Vira.DataLayer.Migrations;
using Microsoft.EntityFrameworkCore;
using Vira.DataLayer.Entities.Product;
using System.Collections;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Vira.DataLayer.Entities.Order;

namespace Vira.Core.Services
{
    public class CartService : ICartService
    {
        private IUserService _userService;
        private ViraContext _context;

        public CartService(IUserService userService, ViraContext context)
        {
            _userService = userService;
            _context = context;
        }
        public ResultDto AddToCart(int storageId, Guid browserId, string? userName)
        {

            var cart = _context.Carts.FirstOrDefault(p => p.BrowserId == browserId && p.Finished == false);
            if (cart == null && userName != null)
            {
                var user = _context.Users.Find(_userService.GetUserIdByUserName(userName));
                Cart newCart = new Cart()
                {
                    Finished = false,
                    BrowserId = browserId,
                    User = user,
                    SumAmount = 0
                };
                _context.Carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }
            else if (cart == null && userName == null)
            {
                Cart newCart = new Cart()
                {
                    Finished = false,
                    BrowserId = browserId,
                    SumAmount = 0
                };
                _context.Carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }

            var productToStorage = _context.Storages.Include(p => p.Product).First(s => s.StorageId == storageId);
            var cartItem = _context.CartItems.FirstOrDefault(s => s.StorageId == storageId && s.CartId == cart.CartId);

            if (cartItem != null)
            {
                cartItem.Count++;
                _context.CartItems.Update(cartItem);
                _context.SaveChanges();

                List<CartItem> cartdCartItems = new List<CartItem>();
                cartdCartItems = _context.CartItems.Include(c => c.Cart).Where(ci => ci.CartId == cart.CartId).ToList();
                cart.SumAmount = 0;
                foreach (var item in cartdCartItems)
                {

                    cart.SumAmount += (item.Price * item.Count);
                    _context.Carts.Update(cart);
                    _context.SaveChanges();
                }
            }
            else
            {
                if (productToStorage.Product.Discount != null && productToStorage.Product.Discount != 0)
                {
                    CartItem newCartItem = new CartItem()
                    {
                        Cart = cart,
                        Count = 1,
                        Price = productToStorage.Price-(((int)(productToStorage.Price * productToStorage.Product.Discount))/100),
                        Storage = productToStorage,
                    };
                    _context.CartItems.Add(newCartItem);
                    _context.SaveChanges();
                }
                else
                {
                    CartItem newCartItem = new CartItem()
                    {
                        Cart = cart,
                        Count = 1,
                        Price = productToStorage.Price,
                        Storage = productToStorage,
                    };
                    _context.CartItems.Add(newCartItem);
                    _context.SaveChanges();
                }


                List<CartItem> cartdCartItems = new List<CartItem>();
                cartdCartItems = _context.CartItems.Include(c => c.Cart).Where(ci => ci.CartId == cart.CartId).ToList();
                cart.SumAmount = 0;
                foreach (var item in cartdCartItems)
                {

                    cart.SumAmount += (item.Price * item.Count);
                    _context.Carts.Update(cart);
                    _context.SaveChanges();
                }
            }

            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"محصول  {productToStorage.Product.ProductTitle} با موفقیت به سبد خرید شما اضافه شد ",
            };


        }

        public ResultDto AddToCartWithCount(int storageId, int count, Guid browserId, string? userName)
        {

            var cart = _context.Carts.Include(C => C.CartItems).FirstOrDefault(p => p.BrowserId == browserId && p.Finished == false);
            var countcartItem = 0;
            if (cart != null)

                
            if (cart.CartItems.Where(CI => CI.StorageId == storageId).Any())
            {
                countcartItem = cart.CartItems.Where(CI => CI.StorageId == storageId).Count();
            }


            if (_context.Storages.FirstOrDefault(S => S.StorageId == storageId).CountProduct > countcartItem + count)
            {

                if (cart == null && userName != null)
                {
                    var user = _context.Users.Find(_userService.GetUserIdByUserName(userName));
                    Cart newCart = new Cart()
                    {
                        Finished = false,
                        BrowserId = browserId,
                        User = user,
                        SumAmount = 0
                    };
                    _context.Carts.Add(newCart);
                    _context.SaveChanges();
                    cart = newCart;
                }
                else if (cart == null && userName == null)
                {
                    Cart newCart = new Cart()
                    {
                        Finished = false,
                        BrowserId = browserId,
                        SumAmount = 0
                    };
                    _context.Carts.Add(newCart);
                    _context.SaveChanges();
                    cart = newCart;
                }

                var productToStorage = _context.Storages.Include(p => p.Product).First(s => s.StorageId == storageId);
                var cartItem = _context.CartItems.FirstOrDefault(s => s.StorageId == storageId && s.CartId == cart.CartId);

                if (cartItem != null)
                {
                    cartItem.Count = cartItem.Count + count;
                    _context.CartItems.Update(cartItem);
                    _context.SaveChanges();

                    List<CartItem> cartdCartItems = new List<CartItem>();
                    cartdCartItems = _context.CartItems.Include(c => c.Cart).Where(ci => ci.CartId == cart.CartId).ToList();
                    cart.SumAmount = 0;
                    foreach (var item in cartdCartItems)
                    {

                        cart.SumAmount += (item.Price * item.Count);
                        _context.Carts.Update(cart);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (productToStorage.Product.Discount != null && productToStorage.Product.Discount != 0)
                    {
                        CartItem newCartItem = new CartItem()
                        {
                            Cart = cart,
                            Count = 1,
                            Price = productToStorage.Price - (((int)(productToStorage.Price * productToStorage.Product.Discount)) / 100),
                            Storage = productToStorage,
                        };
                        _context.CartItems.Add(newCartItem);
                        _context.SaveChanges();
                    }
                    else
                    {
                        CartItem newCartItem = new CartItem()
                        {
                            Cart = cart,
                            Count = 1,
                            Price = productToStorage.Price,
                            Storage = productToStorage,
                        };
                        _context.CartItems.Add(newCartItem);
                        _context.SaveChanges();
                    }


                    List<CartItem> cartdCartItems = new List<CartItem>();
                    cartdCartItems = _context.CartItems.Include(c => c.Cart).Where(ci => ci.CartId == cart.CartId).ToList();
                    cart.SumAmount = 0;
                    foreach (var item in cartdCartItems)
                    {

                        cart.SumAmount += (item.Price * item.Count);
                        _context.Carts.Update(cart);
                        _context.SaveChanges();
                    }
                }

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = $"محصول  {productToStorage.Product.ProductTitle} با موفقیت به سبد خرید شما اضافه شد ",
                };

            }
            return new ResultDto()
            {
                IsSuccess = false,
                Message = $"موجودی انبار به تعداد کافی نیست",
            };
        }

        public ResultDto DeleteFromCart(int storageId, Guid browserId, int? userId)
        {
            var cartItem = _context.CartItems.FirstOrDefault(s => s.Cart.BrowserId == browserId || s.Cart.UserId == userId);
            if (userId != null)
            {
                var cartUserId = _context.Carts.FirstOrDefault(c=>c.UserId == userId).UserId;
                if (cartUserId == userId && cartItem != null)
                {
                    cartItem.IsDelete = true;
                        cartItem.DeleteTime = DateTime.Now;
                        _context.SaveChanges();
                        return new ResultDto
                        {
                            IsSuccess = true,
                            Message = "محصول از سبد خرید شما حذف شد"
                        };
                    
                   
                }
                else
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "محصول یافت نشد"
                    };
            }
            else
            {
                if (cartItem != null)
                {
                    cartItem.IsDelete = true;
                    cartItem.DeleteTime = DateTime.Now;
                    _context.SaveChanges();
                    return new ResultDto
                    {
                        IsSuccess = true,
                        Message = "محصول از سبد خرید شما حذف شد"
                    };

                }
                else
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "محصول یافت نشد"
                    };
            }

        }

        public ResultDto<GetMyCart.CartDto> GetMyCart(Guid browserId, int userId)
        {

            var cart = _context.Carts
                .Include(c => c.CartItems).ThenInclude(s => s.Storage).ThenInclude(c => c.Images)
                .OrderByDescending(c => c.CartId)
                .FirstOrDefault(c => (c.UserId == userId || c.BrowserId == browserId) && c.Finished == false);
            if (cart != null)
            {
                if (userId != 0)
                {
                    var user = _context.Users.Find(userId);
                    cart.User = user;
                    _context.SaveChanges();
                }

                return new ResultDto<GetMyCart.CartDto>
                {
                    Data = new GetMyCart.CartDto()
                    {
                        productCount = cart.CartItems.Count,

                        //SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                        SumAmount = cart.SumAmount,

                        CartId = cart.CartId,
                        CartItems = cart.CartItems.Select(c => new GetMyCart.CartItemDto()
                        {
                            Id = c.CartItemId,
                            ProductTitle = _context.Products.FirstOrDefault(p => p.ProductId == c.Storage.ProductId)
                                .ProductTitle,

                            ProductId = _context.Products.FirstOrDefault(p => p.ProductId == c.Storage.ProductId)
                                .ProductId,

                            ImageProduct = _context.Images.FirstOrDefault(i => i.StorageId == c.Storage.StorageId)
                                .ImageName,

                            count = c.Count,

                            price = c.Price,

                            storageid = c.Storage.StorageId,

                            StorageCount = _context.Storages.Where(d => d.StorageId == c.StorageId)
                                .Sum(c => c.CountProduct),

                            NameColor = _context.Storages.Where(co => co.StorageId == c.StorageId)
                                .Select(co => co.Colors.ColorName).FirstOrDefault(),

                            Size = _context.Storages.FirstOrDefault(co => co.StorageId == c.StorageId).Size,
                        }).ToList(),

                    },
                    IsSuccess = true,
                };
            }


            return new ResultDto<GetMyCart.CartDto>() { IsSuccess = false };
        }

        public ResultDto AddCountProduct(int CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);
            var stockinstock = _context.Storages.FirstOrDefault(s => s.StorageId == cartItem.StorageId);
            if (stockinstock.CountProduct >= cartItem.Count)
            {
                cartItem.Count++;
                _context.SaveChanges();

                List<CartItem> cartdCartItems = new List<CartItem>();
                cartdCartItems = _context.CartItems.Include(c => c.Cart).Where(ci => ci.CartId == cartItem.CartId).ToList();
                foreach (var item in cartdCartItems)
                {
                    item.Cart.SumAmount = 0;
                }
                foreach (var item in cartdCartItems)
                {
                    item.Cart.SumAmount += (item.Price * item.Count);
                    _context.CartItems.Update(item);
                    _context.SaveChanges();
                }
                return new ResultDto()
                {
                    IsSuccess = true,
                };
            }
            else
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "موجودی در انبار کافی نمی باشد."

                };
            }

        }

        public ResultDto LowOffCountProduct(int CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);
            if (cartItem.Count <= 1)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                };
            }
            cartItem.Count--;
            _context.SaveChanges();

            List<CartItem> cartdCartItems = new List<CartItem>();
            cartdCartItems = _context.CartItems.Include(c => c.Cart).Where(ci => ci.CartId == cartItem.CartId).ToList();
            foreach (var item in cartdCartItems)
            {
                item.Cart.SumAmount = 0;
            }
            foreach (var item in cartdCartItems)
            {
                item.Cart.SumAmount += (item.Price * item.Count);
                _context.CartItems.Update(item);
                _context.SaveChanges();
            }

            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public Cart GetCartById(int CartId)
        {
            return _context.Carts.Find(CartId);
        }

        public void UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
        }

        public ResultDto CheckedAccount(string userName)
        {
           var user= _context.Users.FirstOrDefault(u=>u.UserName == userName);
            if (user.City == null || user.State == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "برای سفارش کالا باید در پروفایل خود شهر و استان پر شود."
                };
            }
       
            if (user.PostCode == null )
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "برای سفارش کالا باید در پروفایل خود کدپستی پر شود."
                };
            }

            if (user.Address == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "برای سفارش کالا باید در پروفایل خود آدرس پر شود."
                };
            }

            if (user.PhoneNumber == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "برای سفارش کالا باید در پروفایل خود شماره تلفن پر شود."
                };
            }

            return new ResultDto()
            {
                IsSuccess = true
            };
        }

        #region Discount

        public DiscountUseType UseDiscount(int cartId, string code)
        {
            var discount = _context.Discounts.SingleOrDefault(d => d.DIscountCode == code);
            if (discount == null)
                return DiscountUseType.NotFound;

            if (discount.StartDate != null && discount.StartDate > DateTime.Now)
                return DiscountUseType.ExiperDate;

            if (discount.EndDate != null && discount.EndDate < DateTime.Now)
                return DiscountUseType.ExiperDate;

            if (discount.UsableCount != null && discount.UsableCount < 1)
                return DiscountUseType.Finished;


            var cart = GetCartById(cartId);

            if (_context.UserDiscountCodes.Any(d => d.UserId == cart.UserId && d.DiscountId == discount.DiscountId))
            {
                return DiscountUseType.UserUsed;
            }

            int percent = (cart.SumAmount * discount.DiscountPercent) / 100;
            cart.SumAmount = cart.SumAmount - percent;

            UpdateCart(cart);

            if (discount.UsableCount != null)
            {
                discount.UsableCount -= 1;
            }

            _context.Discounts.Update(discount);
            _context.UserDiscountCodes.Add(new UserDiscountCode()
            {
                UserId = (int)cart.UserId,
                DiscountId = discount.DiscountId,
            });
            _context.SaveChanges();

            return DiscountUseType.Success;

        }

        public void AddDisCount(Discount discount)
        {
            _context.Discounts.Add(discount);
            _context.SaveChanges();
        }

        public List<Discount> GetAllDiscounts()
        {
            return _context.Discounts.ToList();
        }

        public Discount GetDiscountById(int id)
        {
            return _context.Discounts.Find(id);
        }

        public void UpdateDisCount(Discount discount)
        {
            _context.Discounts.Update(discount);
            _context.SaveChanges();
        }

        public bool IsExistCode(string code)
        {
            return _context.Discounts.Any(d => d.DIscountCode == code);
        }

        #endregion
    }
}
