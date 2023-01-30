using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.Convertors;
using Vira.Core.Generator;
using Vira.Core.Security;
using Vira.Core.Senders;
using Vira.Core.Services.Interfaces;
using Vira.DataLayer.Context;
using Vira.DataLayer.Entities.Order;
using Vira.DataLayer.Entities.ProductReturn;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Vira.Core.Services
{
    public class ProductReturnService : IProductReturnService
    {
        private ViraContext _context;

        public ProductReturnService(ViraContext context)
        {
            _context = context;
        }

        public ProductReturn GetDitaileProductReturn(int returnId)
        {
            return _context.ProductReturns.Include(od=>od.OrderDetail).ThenInclude(s=>s.Storage).ThenInclude(p=>p.Product).Include(od=>od.OrderDetail).ThenInclude(s=>s.Storage).ThenInclude(i=>i.Images).FirstOrDefault(p => p.ReturnId == returnId);
        }

        #region UserPanel

        public bool SearchProductReturn(int orderDetailId)
        {
            return _context.OrderDetails.Any(od => od.OrderDetailId == orderDetailId);
        }

        public int AddProductReturn(ProductReturn productReturn, IFormFile imageProductReturn)
        {
            productReturn.ImageName = "no-photo.jpg";
            productReturn.verified = false;
            productReturn.ReturnDate = DateTime.Now;

            if (imageProductReturn != null && imageProductReturn.IsImage())
            {
                productReturn.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(imageProductReturn.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/ProductReturn/Image", productReturn.ImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageProductReturn.CopyTo(stream);
                }
            }

            _context.ProductReturns.Add(productReturn);
            _context.SaveChanges();

            return productReturn.ReturnId;

        }

        public List<ProductReturn> GetListProductReturns(int userId)
        {
            return _context.ProductReturns.Where(p => p.UserId == userId).ToList();
        }

        #endregion

        #region Admin

        public Tuple<List<ProductReturn>, int> GetListProductReturnsForAdmin(int pageId = 1, string userName = "" , string returnId = "")
        {
            int take = 10;
            int skip = (pageId - 1) * take;

            IQueryable<ProductReturn> result = _context.ProductReturns;
            if (!string.IsNullOrEmpty(returnId))
            {
                result = result.Where(p =>(p.ReturnId.ToString()).Contains(returnId));

            }
             if (!string.IsNullOrEmpty(userName))
            {
                result = result.Where(p => p.User.UserName.Contains(userName));

            }




            int pageCount = result.Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Skip(skip).Take(take).OrderByDescending(p => p.ReturnDate).ToList();

            return Tuple.Create(query, pageCount);

        }



        public void Confirmationbyadmin(int returnId , bool verified)
        {
            var productReturn = _context.ProductReturns.FirstOrDefault(p => p.ReturnId == returnId);
            productReturn.verified = verified;
            productReturn.ReturnUpdateDate = DateTime.Now;

            _context.ProductReturns.Update(productReturn);
            _context.SaveChanges();
        }

        #endregion
    }
}
