using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.Core.Convertors;
using Berlance.Core.DTOs;
using Berlance.Core.DTOs.Notification;
using Berlance.Core.DTOs.Storage;
using Berlance.Core.Generator;
using Berlance.Core.Senders;
using Berlance.Core.Services.Interfaces;
using Berlance.DataLayer.Context;
using Berlance.DataLayer.Entities.Product;
using Berlance.DataLayer.Entities.Storage;
using Berlance.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Berlance.Core.Services
{
    public class StorageService : IStorageService
    {
        private BerLanceContext _context;
        private IViewRenderService _viewRender;

        public StorageService(BerLanceContext context, IViewRenderService viewRender)
        {
            _context = context;
            _viewRender = viewRender;
        }


        public int AddStorage(AddStorageViewModel storage)
        {
            var newStorage = new Storage();
            newStorage.RegisterDate = DateTime.Now;
            newStorage.ProductId = storage.ProductId;
            newStorage.ColorId = storage.ColorId;
            newStorage.Price = storage.Price;
            newStorage.Size = storage.Size;
            newStorage.CountProduct = storage.CountProduct;
            _context.Storages.Add(newStorage);
            _context.SaveChanges();

            #region AddImage
            //Save New Image
            foreach (var listImage in storage.Files)
            {
                Image images = new Image();
                images.StorageId = newStorage.StorageId;
                images.ImageName = listImage;
                //string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/Image", images.ImageName);
                //using (var stream = new FileStream(imagePath, FileMode.Create))
                //{
                //    listImage.CopyTo(stream);
                //}
                //ImageConvertor imageResizer = new ImageConvertor();
                //string ThumbNail = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/ThumbNail", images.ImageName);
                //imageResizer.Image_resize(imagePath, ThumbNail, 78);

                _context.Images.Add(images);
            }
            #endregion


            _context.SaveChanges();


            #region SendMailNotification

            var Notfications = _context.Notifications.Where(n => n.ProductId == storage.ProductId).ToList();

            if (Notfications != null
                || _context.Storages.
                    Where(s => s.ProductId == storage.ProductId)
                    .Select(s => s.CountProduct).Count() > 0)
            {
                foreach (var item in Notfications)
                {
                    SendNotification notification = new SendNotification();

                    User user = _context.Users.FirstOrDefault(u => u.UserId == item.UserId);

                    notification.UserName = user.UserName;
                    notification.ProductId = item.ProductId;

                    #region Send Activation Email

                    string body = _viewRender.RenderToStringAsync("_Notification", notification);
                    SendEmail.Send(user.Email, "فعالسازی", body);

                    #endregion
                }




            }
            #endregion

            return newStorage.ProductId;
        }

        public List<Storage> GetListStoragesProduct(int productId)
        {
            return _context.Storages.Include(c => c.Colors).Include(i => i.Images).Include(p => p.Product).Where(p => p.ProductId == productId).ToList();
        }

        public Storage GetStorageById(int id)
        {
            //return _context.Storages.Find(id);
            return _context.Storages.Include(S => S.Images).First(S => S.StorageId == id);

        }

        public void EditStorage(int id, AddStorageViewModel storage, List<string> imageName)
        {
            var Storage = _context.Storages.First(S => S.StorageId == id);
            Storage.CountProduct = storage.CountProduct;
            Storage.Price = storage.Price;
            Storage.Size = storage.Size;
            Storage.ColorId = storage.ColorId;
            _context.Storages.Update(Storage);
            _context.SaveChanges();
            #region AddImage
            var oldImage = _context.Images.Where(i => i.StorageId == id);
            _context.Images.RemoveRange(oldImage);
            _context.SaveChanges();
            Image image = new Image();
            
            foreach(var item in imageName)
            {
                //image.ImageName = item;
                //image.StorageId = id;
                _context.Images.Add(new Image { ImageName = item, StorageId = id });
                _context.SaveChanges();

            }
            


            //DEleteImage
            //var DeletImage = _context.Images.Where(I => I.StorageId == id);
            //if (image != null)
            //{
            //    foreach (var item in DeletImage)
            //    {

            //        string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/Image", item.ImageName);
            //        if (File.Exists(deleteImagePath))
            //        {
            //            File.Delete(deleteImagePath);
            //        }

            //        string deleteImageThumbNail = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/ThumbNail", item.ImageName);
            //        if (File.Exists(deleteImageThumbNail))
            //        {
            //            File.Delete(deleteImageThumbNail);
            //        }
            //    }
            //}
            //Save New Image

            //foreach (var listImage in image)
            //{

            //    if (image != null)
            //    {
            //        Image images = new Image();


            //        images.StorageId = Storage.StorageId;
            //        images.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(listImage.FileName);
            //        string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/Image", images.ImageName);
            //        using (var stream = new FileStream(imagePath, FileMode.Create))
            //        {
            //            listImage.CopyTo(stream);
            //        }
            //        ImageConvertor imageResizer = new ImageConvertor();
            //        string ThumbNail = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/ThumbNail", images.ImageName);
            //        imageResizer.Image_resize(imagePath, ThumbNail, 78);

            //        _context.Images.Update(images);
            //        _context.SaveChanges();
            //    }

            //}

            #endregion

            #region SendMailNotification

            var Notfications = _context.Notifications.Where(n => n.ProductId == storage.ProductId).ToList();

            if ( Notfications!= null 
                || _context.Storages.
                    Where(s => s.ProductId == storage.ProductId)
                    .Select(s => s.CountProduct).Count() > 0)
            {
                foreach (var item in Notfications)
                {
                    SendNotification notification =new SendNotification();

                    User user = _context.Users.FirstOrDefault(u => u.UserId == item.UserId);

                    notification.UserName = user.UserName;
                    notification.ProductId = item.ProductId;

                    #region Send Activation Email

                    string body = _viewRender.RenderToStringAsync("_Notification", notification);
                    SendEmail.Send(user.Email, "فعالسازی", body);

                    #endregion
                }




            }
            #endregion
        }

        public Storage GetStoragesById(int storageId)
        {
            return _context.Storages.Find(storageId);
        }

        public void DeleteStorage(int storageId)
        {
            Storage storage = GetStorageById(storageId);
            storage.IsDelete = true;
            _context.Storages.Update(storage);
            _context.SaveChanges();
        }

        public StorageViewModel GetDeleteStorage(int pageId = 1, string productName = "", string Size = "")
        {

            IQueryable<Storage> result = _context.Storages.IgnoreQueryFilters().Where(U => U.IsDelete);

            if (!string.IsNullOrEmpty(productName))
            {
                result = result.Where(A => A.Product.ProductTitle.Contains(productName));
            }

            if (!string.IsNullOrEmpty(Size))
            {
                result = result.Where(A => A.Size.Contains(Size));
            }

            //Show Item In page
            int take = 20;
            int skip = (pageId - 1) * take;


            StorageViewModel List = new StorageViewModel();
            List.CurrentPage = pageId;
            List.PageCount = result.Count() / take;
            List.Storages = result.OrderBy(A => A.RegisterDate).Skip(skip).Take(take).ToList();

            return List;

        }

        public Tuple<List<Storage> , int> GetListStorage(int pageId = 1, string productName = "", string Size = "")
        {
            IQueryable<Storage> result = _context.Storages;

            if (!string.IsNullOrEmpty(productName))
            {
                result = result.Where(A => A.Product.ProductTitle.Contains(productName));
            }

            if (!string.IsNullOrEmpty(Size))
            {
                result = result.Where(A => A.Size.Contains(Size));
            }

            //Show Item In page
            int take = 20;
            int skip = (pageId - 1) * take;
            int pageCount = result.Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Skip(skip).Take(take).ToList();


            return Tuple.Create(query, pageCount);
        }
    }
}
