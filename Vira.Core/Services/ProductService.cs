using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.Core.Convertors;
using Berlance.Core.DTOs.Comment;
using Berlance.Core.DTOs.Product;
using Berlance.Core.Generator;
using Berlance.Core.Services.Interfaces;
using Berlance.DataLayer.Context;
using Berlance.DataLayer.Entities.Article;
using Berlance.DataLayer.Entities.Notification;
using Berlance.DataLayer.Entities.Product;
using Berlance.DataLayer.Entities.Storage;
using Berlance.DataLayer.Entities.User;
using Berlance.DataLayer.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Berlance.Core.Services
{
    public class ProductService : IProductService
    {
        private BerLanceContext _context;
        private IUserService _userService;

        public ProductService(BerLanceContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        #region Group

        public List<ProductGroup> GetAllGroup()
        {
            return _context.ProductGroups.Include(c => c.ProductGroups).Include(p => p.Products).ThenInclude(s => s.Storages).ThenInclude(i => i.Images).ToList();
        }

        public List<SelectListItem> GetGroupForManagProduct()
        {
            return _context.ProductGroups.OrderByDescending(pg => pg.GroupId).Where(g => g.ParentId == null)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubGroupForManagProduct(int groupId)
        {
            return _context.ProductGroups.Where(g => g.ParentId == groupId)
                .Select(g => new SelectListItem()
                {
                    Text = g.GroupTitle,
                    Value = g.GroupId.ToString()
                }).ToList();
        }

        public void AddGroup(ProductGroup group)
        {
            _context.ProductGroups.Add(group);
            _context.SaveChanges();
        }

        public void UpdateGroup(ProductGroup group)
        {
            _context.ProductGroups.Update(group);
            _context.SaveChanges();
        }

        public ProductGroup GetGroupById(int id)
        {
            return _context.ProductGroups.Find(id);
        }


        #endregion

        #region Attribut

        public List<Attribut> GetAttributGroupForManagProduct()
        {
            return _context.Attributs.Where(g => g.ParentId == null).ToList();
        }
        public List<Attribut> GetAttributeValueForManagProduct()
        {
            return _context.Attributs.Where(g => g.ParentId != null).ToList();
        }
        public List<ProductAttribute> GetAllProductAttributesForManageProduct()
        {
            return _context.ProductAttributes.Include(PA => PA.Attribut).ToList();
        }
        public List<Attribut> GetAttributByGroupId(int id)
        {
            return _context.Attributs.Where(g => g.ParentId == null && g.GroupId == id).ToList();
        }
        public List<Attribut> GetAttributeValueByGroupId(int id)
        {
            return _context.Attributs.Where(g => g.ParentId != null && g.GroupId == id).ToList();
        }
        public List<ProductAttribute> GetProductAttributesForManageProduct(int id)
        {
            return _context.ProductAttributes.Include(PA => PA.Attribut).Where(PA => PA.ProductId == id).ToList();
        }

        public List<Attribut> GetAllAttribut()
        {
            return _context.Attributs.Include(a => a.Attributs).ToList();
        }

        public void AddAttribut(Attribut attribut)
        {
            _context.Attributs.Add(attribut);
            _context.SaveChanges();
        }

        public void UpdateAttribut(Attribut attribut)
        {
            _context.Attributs.Update(attribut);
            _context.SaveChanges();
        }
        public void DeleteAttribut(int id)
        {
            var attribut = _context.Attributs.Where(a => a.AttributId == id || a.ParentId == id).ToList();


            _context.Attributs.RemoveRange(attribut);
            _context.SaveChanges();

        }

        public Attribut GetAttributsById(int id)
        {
            return _context.Attributs.Find(id);
        }

        #endregion

        #region Product



        public Tuple<List<ShowproductListItemViewModel>, int> GetProduct(int pageId = 1, string filter = "",
    string orderByType = "date", int startprice = 0, int endPrice = 0,
    List<int> selectedGroups = null, List<string> colorName = null, string productDiscount = "off",
    string storageStock = "off", int take = 0)
        {
            if (take == 0)
            {
                take = 10;
            }

            IQueryable<Product> result = _context.Products;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.ProductTitle.Contains(filter));
            }


            if (colorName != null && colorName.Any())
            {
                List<Storage> s = new List<Storage>();
                List<Product> p = new List<Product>();
                IQueryable<Product> product = Enumerable.Empty<Product>().AsQueryable();
                foreach (var item in colorName)
                {
                    var d = _context.Storages.Include(P => P.Product).Where(s => s.Colors.ColorName == item).ToList();
                    //var d = from liststorage in _context.Storages where liststorage.Colors.ColorName == item select liststorage;
                    foreach (var itmed in d)
                    {
                        s.Add(itmed);
                    }
                }

                foreach (var itme2 in s)
                {
                    //product.Append(_context.Products.FirstOrDefault(p => p.ProductId == itme2.ProductId));
                    //product.Append((from itmes in _context.Products where itmes.ProductId == itme2.ProductId select itmes).FirstOrDefault()); 
                    p.Add(_context.Products.FirstOrDefault(p => p.ProductId == itme2.ProductId));
                }

                //product = product.Union(p);
                result = product.Union(p);
            }


            switch (storageStock)
            {
                case "off":
                    break;

                case "on":
                    {
                        result = result.Include(s => s.Storages).Where(s => s.Storages.Sum(c => c.CountProduct) > 0);
                        break;
                    }

            }

            switch (productDiscount)
            {
                case "off":
                    break;

                case "on":
                    {
                        result = result.Where(d => d.Discount != 0 && d.Discount != null);
                        break;
                    }

            }


            switch (orderByType)
            {
                case "date":
                    {
                        result = result.OrderByDescending(p => p.CreateDate);
                        break;
                    }

                case "Ascending":
                    {
                        result = result.Include(s => s.Storages).OrderByDescending(p => p.Storages.First().Price);
                        break;
                    }

                case "Descending":
                    {
                        result = result.Include(s => s.Storages).OrderBy(p => p.Storages.First().Price);

                        break;
                    }
                case "BestSelling":
                    {

                        result = result.Include(s => s.Storages).OrderByDescending(s => s.Storages.First().OrderDetails.First().Count);

                    }
                    break;

                case "mostvisited":
                    {
                        result = result.Include(s => s.Storages).OrderByDescending(s => s.VisitProduct);

                    }
                    break;
            }

            if (startprice > 0)
            {

                result = result.Include(s => s.Storages).Where(p => p.Storages.First().Price >= startprice);


            }

            if (endPrice > 0)
            {

                result = result.Include(s => s.Storages).Where(p => p.Storages.First().Price <= endPrice);


            }

            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (int groupId in selectedGroups)
                {
                    result = result.Where(r => r.GroupId == groupId || r.SubGroup == groupId);
                }
            }

            int skip = (pageId - 1) * take;
            try
            {
                int pageCount = result.Include(s => s.Storages).ThenInclude(i => i.Images).Select(c => new ShowproductListItemViewModel()
                {
                    ProductId = c.ProductId,
                    ProductTitle = c.ProductTitle,
                    Image = _context.Images.Include(s => s.Storage).Where(i => i.Storage.ProductId == c.ProductId).FirstOrDefault(),
                    ColorsName = c.Storages.Where(s => s.ProductId == c.ProductId).Select(c => c.Colors.ColorName).ToList(),
                    Discount = c.Discount,
                    Price = c.Storages.Where(p => p.ProductId == c.ProductId).Select(p => p.Price).FirstOrDefault()

                }).Count() / take;

                var query = result.Include(s => s.Storages).ThenInclude(i => i.Images).Select(c => new ShowproductListItemViewModel()
                {
                    ProductId = c.ProductId,
                    ProductTitle = c.ProductTitle,
                    Image = _context.Images.Include(s => s.Storage).Where(i => i.Storage.ProductId == c.ProductId).FirstOrDefault(),
                    ColorsName = c.Storages.Where(s => s.ProductId == c.ProductId).Select(c => c.Colors.ColorName).ToList(),
                    Discount = c.Discount,
                    Price = c.Storages.Where(p => p.ProductId == c.ProductId).Select(p => p.Price).FirstOrDefault()

                }).Skip(skip).Take(take).ToList();
                return Tuple.Create(query, pageCount);
            }
            catch (Exception e)
            {

                result = _context.Products;
                int pageCount = result.Include(s => s.Storages).ThenInclude(i => i.Images).Select(c => new ShowproductListItemViewModel()
                {
                    ProductId = c.ProductId,
                    ProductTitle = c.ProductTitle,
                    Image = _context.Images.Include(s => s.Storage).Where(i => i.Storage.ProductId == c.ProductId).FirstOrDefault(),
                    ColorsName = c.Storages.Where(s => s.ProductId == c.ProductId).Select(c => c.Colors.ColorName).ToList(),
                    Discount = c.Discount,
                    Price = c.Storages.Where(p => p.ProductId == c.ProductId).Select(p => p.Price).FirstOrDefault()

                }).Count() / take;

                var query = result.Include(s => s.Storages).ThenInclude(i => i.Images).Select(c => new ShowproductListItemViewModel()
                {
                    ProductId = c.ProductId,
                    ProductTitle = c.ProductTitle,
                    Image = _context.Images.Include(s => s.Storage).Where(i => i.Storage.ProductId == c.ProductId).FirstOrDefault(),
                    ColorsName = c.Storages.Where(s => s.ProductId == c.ProductId).Select(c => c.Colors.ColorName).ToList(),
                    Discount = c.Discount,
                    Price = c.Storages.Where(p => p.ProductId == c.ProductId).Select(p => p.Price).FirstOrDefault()

                }).Skip(skip).Take(take).ToList();
                return Tuple.Create(query, pageCount);

            }






            //return result.Include(c => c.Images).Include(s => s.Storages).Select(c => new ShowproductListItemViewModel()
            //{
            //    ProductId = c.ProductId,
            //    ProductTitle = c.ProductTitle,
            //    Image = c.Images.FirstOrDefault(i => i.ProductId == c.ProductId || i.IsPrimary),
            //    ColorsName = c.Storages.Where(s => s.ProductId == c.ProductId).Select(c => c.Colors.ColorName).ToList(),
            //    Discount = c.Discount,
            //    Price = c.Storages.Where(p => p.ProductId == c.ProductId).Select(p => p.Price).LastOrDefault()


            //}).Skip(skip).Take(take).ToList();

        }



        public List<ShowproductListItemViewModel> GetPopularProduct()
        {
            return _context.Storages.Include(o => o.OrderDetails)
                .Include(c => c.Product)
                .Where(od => od.OrderDetails.Any())
                .OrderBy(od => od.OrderDetails.Count)
                .Take(8).Select(c => new ShowproductListItemViewModel()
                {
                    ProductId = c.ProductId,
                    Price = c.Price,
                    Image = _context.Images.Include(s => s.Storage).Where(i => i.Storage.ProductId == c.ProductId).FirstOrDefault(),
                    ColorsName = c.Product.Storages.Where(s => s.ProductId == c.ProductId).Select(c => c.Colors.ColorName).ToList(),
                    Discount = c.Product.Discount,
                    ProductTitle = c.Product.ProductTitle,
                }).ToList();
        }

        public List<ShowproductListItemViewModel> GetRelatedProduct(int subGroupid, int productId)
        {
            return _context.Products
                .Include(c => c.Storages)
                .Where(od => od.SubGroup == subGroupid && od.ProductId != productId)
                .OrderBy(od => od.CreateDate)
                .Take(5).Select(c => new ShowproductListItemViewModel()
                {
                    ProductId = c.ProductId,
                    Price = c.Storages.FirstOrDefault().Price,
                    Image = _context.Images.Include(s => s.Storage).Where(i => i.Storage.ProductId == c.ProductId).FirstOrDefault(),
                    ColorsName = c.Storages.Where(s => s.ProductId == c.ProductId).Select(c => c.Colors.ColorName).ToList(),
                    Discount = c.Discount,
                    ProductTitle = c.ProductTitle,
                }).ToList();
        }

        public List<ShowProductForAdminViewModel> GetProductsForAdmin()
        {

            return _context.Products.Include(s => s.Storages).ThenInclude(i => i.Images).OrderByDescending(p => p.CreateDate).Select(p => new ShowProductForAdminViewModel()
            {
                ProductId = p.ProductId,
                Titel = p.ProductTitle,
                ImageName = _context.Images.Include(s => s.Storage).Where(i => i.Storage.ProductId == p.ProductId).Select(i => i.ImageName).FirstOrDefault(),
                Size = p.Storages.Where(s => s.ProductId == p.ProductId).Select(s => s.Size).ToList(),
                Color = p.Storages.Where(s => s.ProductId == p.ProductId).Select(s => s.Colors.ColorCode).ToList(),
                StorageCount = p.Storages.Where(s => s.ProductId == p.ProductId).Sum(s => s.CountProduct)

            }).ToList();
        }

        public int AddProduct(CreateProductViewModel product, string userName)
        {
            var userId = _userService.GetUserIdByUserName(userName);
            var NewProduct = new Product();
            NewProduct.CreateDate = DateTime.Now;
            NewProduct.UserId = userId;
            NewProduct.ProductTitle = product.ProductTitle;
            NewProduct.GroupId = product.GroupId;
            NewProduct.SubGroup = product.SubGroup;
            NewProduct.ProductDescription = product.ProductDescription;

            _context.Products.Add(NewProduct);
            _context.SaveChanges();

            #region ProductAttribut

            if(product.AttributeId != null)
            {
                foreach (var listAttribut in product.AttributeId)
                {
                    ProductAttribute proAtt = new ProductAttribute()
                    {
                        ProductId = NewProduct.ProductId,
                        AttributeId = listAttribut,
                    };
                    _context.ProductAttributes.Add(proAtt);
                    _context.SaveChanges();
                }
            }

            #endregion

            #region AddImage

            ////Save New Image
            //foreach (var listImage in product.Files)
            //{
            //    Image images = new Image();
            //    images.ProductId = NewProduct.ProductId;
            //    images.ImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(listImage.FileName);
            //    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/Image", images.ImageName);
            //    using (var stream = new FileStream(imagePath, FileMode.Create))
            //    {
            //        listImage.CopyTo(stream);
            //    }
            //    ImageConvertor imageResizer = new ImageConvertor();
            //    string ThumbNail = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product/ThumbNail", images.ImageName);
            //    imageResizer.Image_resize(imagePath, ThumbNail, 78);

            //    _context.Images.Add(images);
            //    _context.SaveChanges();
            //}

            #endregion

            return NewProduct.ProductId;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Include(pa => pa.ProductAttributes).FirstOrDefault(p => p.ProductId == productId);
        }

        public Product GetProductByStorageId(int storageId)
        {
            return _context.Storages.Where(S => S.StorageId == storageId).Select(S => S.Product).FirstOrDefault();
        }

        public int UpdateProduct(EditProductViewModel createProductViewModel, int productId, string Description)
        {
            var Target = _context.Products.Include(P=>P.ProductAttributes).ThenInclude(PA => PA.Attribut).Where(P => P.ProductId == productId).First();

            Target.ProductId = productId;
            Target.ProductTitle = createProductViewModel.ProductTitle;
            Target.GroupId = createProductViewModel.GroupId;
            Target.SubGroup = createProductViewModel.SubGroup;
            Target.ProductDescription = Description;

            _context.Products.Update(Target);
            _context.SaveChanges();

            #region ProductAttribut

            foreach (var listAttribut in createProductViewModel.AttributeId)
            {
                var ParentOfThisValue = _context.Attributs.Where(PA => PA.AttributId == listAttribut).Select(PA => PA.ParentId).FirstOrDefault();

                foreach (var Atts in Target.ProductAttributes)
                {
                    if(Atts.Attribut.ParentId == ParentOfThisValue)
                    {
                        Atts.AttributeId = listAttribut;
                        _context.ProductAttributes.Update(Atts);
                        _context.SaveChanges();
                    }
                }
            }

            #endregion



            return Target.ProductId;
        }

        public DetailProductViewModel GetProductForShow(int productId, int? colorId, string? size, int? storageId)
        {
            DetailProductViewModel PVM = new DetailProductViewModel();

            var storage = _context.Storages.FirstOrDefault(S => S.ProductId == productId);
            var product = _context.Products.FirstOrDefault(S => S.ProductId == productId);
            var group = _context.ProductGroups.Where(PG => PG.GroupId == product.GroupId).FirstOrDefault(PG => PG.ParentId == null);
            var subgroup = _context.ProductGroups.FirstOrDefault(PG => PG.ParentId == group.GroupId);
            var attribute = _context.Attributs.Where(A => A.GroupId == group.GroupId).Where(A => A.ParentId == null).Include(A => A.Attributs).ToList();
            PVM.Title = _context.Products.Where(P => P.ProductId == productId).Select(P => P.ProductTitle).FirstOrDefault();
            PVM.PrimaryImage = _context.Images.FirstOrDefault(P => P.StorageId == storage.StorageId);
            PVM.AllImages = _context.Images.Where(P => P.Storage.ProductId == storage.ProductId).ToList();
            PVM.Storages = _context.Storages.Where(S => S.ProductId == productId).Include(S => S.Colors).ToList();
            PVM.StorageSelected = _context.Storages.Include(c => c.Colors).FirstOrDefault(S =>
                S.StorageId == storageId || S.Colors.ColorId == colorId || S.Size == size);
            PVM.Colors = PVM.Storages.Where(S => S.ProductId == productId).Select(S => S.Colors).ToList();
            PVM.Group = group;
            PVM.SubGroup = subgroup;
            PVM.Description = product.ProductDescription;

            if (colorId != null && size == null)
            {
                PVM.StorageSelected = _context.Storages.Include(c => c.Colors).FirstOrDefault(S => (S.Colors.ColorId == colorId && S.ProductId == productId));
            }
            else if (size != null && colorId != null)
            {
                PVM.StorageSelected = _context.Storages.Include(c => c.Colors).FirstOrDefault(S => (S.Size == size && S.Colors.ColorId == colorId && S.ProductId == productId));
            }
            else
            {
                PVM.StorageSelected = _context.Storages.Include(c => c.Colors).FirstOrDefault(S => (S.ProductId == productId && S.CountProduct != 0));
            }


            var PAVM = new List<ProductAttributesViewModel>();
            foreach (var Att in attribute)
            {
                var NewAttribute = new ProductAttributesViewModel()
                {
                    Title = Att,
                    Value = Att.Attributs.FirstOrDefault()
                };
                PAVM.Add(NewAttribute);
            }
            PVM.Attributs = PAVM;

            return PVM;


            //return _context.Products
            //    .Include(P => P.ProductAttributes).ThenInclude(PA => PA.Attribut)
            //    .Include(s => s.Storages).ThenInclude(i => i.Images)
            //    .Include(s => s.Storages).ThenInclude(i => i.Colors)
            //    .Include(g => g.Group).ThenInclude(a => a.Attributs)
            //    .FirstOrDefault(p => p.ProductId == productId);
        }

        public void AddVisiteProduct(int productId)
        {
            Product product = new Product();
            product = _context.Products.Find(productId);
            product.VisitProduct += 1;
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        #endregion

        #region Color

        public List<Colors> GetColorsList()
        {
            return _context.Colors.Select(p => new Colors()
            {
                ColorId = p.ColorId,
                ColorName = p.ColorName,
                ColorCode = p.ColorCode
            }).ToList();
        }
        public Tuple<List<Colors>, int> GetColorsLists(int pageId = 1, string filter = "")
        {
            int take = 10;
            int skip = (pageId - 1) * take;

            IQueryable<Colors> result = _context.Colors;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.ColorName.Contains(filter));

            }

            int pageCount = result.Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public List<SelectListItem> GetColorsListItem()
        {
            return _context.Colors
                .Select(g => new SelectListItem()
                {
                    Text = g.ColorName,
                    Value = g.ColorId.ToString()
                }).ToList();

        }

        public int AddColor(Colors colors)
        {
            _context.Colors.Add(colors);
            _context.SaveChanges();
            return colors.ColorId;
        }

        public Colors GetColorById(int ColorId)
        {

            return _context.Colors.Find(ColorId);
        }

        public int UpdateColor(Colors colors)
        {
            _context.Colors.Update(colors);
            _context.SaveChanges();
            return colors.ColorId;
        }

        #endregion

        #region Comments

        #region Admin


        public void AddAnswerComment(string Answer, int commentId, int userId)
        {
            AnswerComment answerComments = new AnswerComment()
            {
                UserId = userId,
                CommentID = commentId,
                Answer = Answer,
                CreateDate = DateTime.Now
            };

            _context.AnswerComments.Add(answerComments);
            _context.SaveChanges();

            var productComment = _context.ProductComments.FirstOrDefault(pc => pc.CommentId == commentId);
            productComment.AnswerId = answerComments.AnswerId;
            productComment.IsAdminRead = true;
            _context.ProductComments.Update(productComment);
            _context.SaveChanges();
        }

        public Tuple<List<ProductComment>, int> GetAllProductComment(int pageId = 1, string firstName = "", string lastName = "")
        {
            int take = 5;
            int skip = (pageId - 1) * take;

            //int pageCount = _context.ProductComments.Where(pc => !pc.IsDelete && pc.ProductId == productId).Count() / take;

            IQueryable<ProductComment> result = _context.ProductComments.Include(a => a.User).Include(a => a.AnswerComment).Where(c => c.AnswerComment == null).OrderByDescending(c => c.CarateDateTime);
            int pageCount = result.Count() / take;

            if (!string.IsNullOrEmpty(firstName))
            {
                result = result.Where(p => p.User.Firstname.Contains(firstName));

            }
            if (!string.IsNullOrEmpty(lastName))
            {
                result = result.Where(p => p.User.LastName.Contains(lastName));

            }

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);

            //return Tuple.Create(_context.ProductComments.Include(u => u.User)
            //    .Where(pc => !pc.IsDelete && pc.ProductId == productId).Skip(skip).Take(take)
            //    .OrderByDescending(c => c.CommentId).ToList(), pageCount);
        }

        public Tuple<List<ProductComment>, int> GetListComment(int pageId = 1, string firstName = "", string lastName = "")
        {
            int take = 4;
            int skip = (pageId - 1) * take;

            IQueryable<ProductComment> result = _context.ProductComments.Include(U => U.User);
            if (!string.IsNullOrEmpty(firstName))
            {
                result = result.Where(p => p.User.Firstname.Contains(firstName));

            }
            if (!string.IsNullOrEmpty(lastName))
            {
                result = result.Where(p => p.User.LastName.Contains(lastName));

            }
            int pageCount = result.Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        [HttpPost]
        public void DeleteProductComment(int Id)
        {
            ProductComment productComment = _context.ProductComments.FirstOrDefault(pc => pc.CommentId == Id);
            productComment.IsDelete = true;
            _context.ProductComments.Update(productComment);
            _context.SaveChanges();
        }
        #endregion

        public void AddComment(ProductComment comment)
        {
            _context.ProductComments.Add(comment);
            _context.SaveChanges();
        }

        public Tuple<List<ShowComment>, int> GetProductComment(int productId, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            //int pageCount = _context.ProductComments.Where(pc => !pc.IsDelete && pc.ProductId == productId).Count() / take;

            IQueryable<ProductComment> result = _context.ProductComments;
            int pageCount = result.Include(s => s.User).Include(a => a.AnswerComment).Where(p => p.ProductId == productId).Select(c => new ShowComment()
            {
                UserAvatar = c.User.UserAvatar,
                ProductAnswerComment = c.AnswerComment.Answer,
                ProductComment = c.Comment,
                ProductCommentId = c.CommentId,
                CarateDateTime = c.CarateDateTime,
                UserName = c.User.UserName
            }).Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Include(s => s.User).Include(a => a.AnswerComment).Where(p => p.ProductId == productId).OrderByDescending(c => c.CarateDateTime).Select(c => new ShowComment()
            {
                UserAvatar = c.User.UserAvatar,
                ProductAnswerComment = c.AnswerComment.Answer,
                ProductComment = c.Comment,
                ProductCommentId = c.CommentId,
                CarateDateTime = c.CarateDateTime,
                UserName = c.User.UserName


            }).Skip(skip).Take(take).ToList();

            return Tuple.Create(query, pageCount);
        }

        public Tuple<List<ShowComment>, int> GetListcommentForUser(string userName, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            var userId = _userService.GetUserIdByUserName(userName);

            IQueryable<ProductComment> result = _context.ProductComments;
            int pageCount = result.Include(s => s.User).Include(a => a.AnswerComment).Where(p => p.UserId == userId).Select(c => new ShowComment()
            {
                UserAvatar = c.User.UserAvatar,
                ProductAnswerComment = c.AnswerComment.Answer,
                ProductComment = c.Comment,
                ProductCommentId = c.CommentId,
                CarateDateTime = c.CarateDateTime,
                UserName = c.User.UserName
            }).Count() / take;

            if ((pageCount % 2) != 0)
            {
                pageCount += 1;
            }

            var query = result.Include(s => s.User).Include(a => a.AnswerComment).Where(p => p.UserId == userId).OrderByDescending(c => c.CarateDateTime).Select(c => new ShowComment()
            {
                UserAvatar = c.User.UserAvatar,
                ProductAnswerComment = c.AnswerComment.Answer,
                ProductComment = c.Comment,
                ProductCommentId = c.CommentId,
                CarateDateTime = c.CarateDateTime,
                UserName = c.User.UserName


            }).Skip(skip).Take(take).ToList();


            return Tuple.Create(query, pageCount);
        }


        public int CountCommentForUser(string userName)
        {
            var userId = _userService.GetUserIdByUserName(userName);
            var countComment = _context.ProductComments.Include(s => s.User).Include(a => a.AnswerComment).Where(p => p.UserId == userId).Count();

            return countComment;
        }

        public void AddLikeComment(int commentId, string userName)
        {
            var userid = _userService.GetUserIdByUserName(userName);
            if (_context.ProductCommnetLikes.Where(l => l.CommentId == commentId && l.UserId == userid).Any() == false)
            {
                ProductCommnetLike productCommnetLike = new ProductCommnetLike();
                productCommnetLike.UserId = userid;
                productCommnetLike.CommentId = commentId;
                _context.ProductCommnetLikes.Add(productCommnetLike);
                _context.SaveChanges();

            }
            else
            {
                ProductCommnetLike productCommnetLike = new ProductCommnetLike();
                productCommnetLike = _context.ProductCommnetLikes.FirstOrDefault(l => l.CommentId == commentId && l.UserId == userid);
                _context.ProductCommnetLikes.Remove(productCommnetLike);
                _context.SaveChanges();
            }
        }

        #endregion

        #region Like


        public void AddLike(int ProductId, string userName)
        {
            var userid = _userService.GetUserIdByUserName(userName);
            if (_context.Likes.Where(l => l.ProductId == ProductId && l.UserId == userid) != null)
            {
                Like like = new Like();
                like.UserId = userid;
                like.ProductId = ProductId;
                _context.Likes.Add(like);
                _context.SaveChanges();

            }
            else
            {
                Like like = new Like();
                like = _context.Likes.FirstOrDefault(l => l.ProductId == ProductId && l.UserId == userid);
                _context.Likes.Remove(like);
                _context.SaveChanges();
            }
        }

        public List<ShowproductListItemViewModel> ListLikeForUser(string userName)
        {
            var userid = _userService.GetUserIdByUserName(userName);
            return _context.Likes.Include(p => p.Product).ThenInclude(s => s.Storages).Where(l => l.UserId == userid).Select(c => new ShowproductListItemViewModel
            {
                ProductId = c.ProductId,
                Price = c.Product.Storages.FirstOrDefault().Price,
                Image = _context.Images.Include(s => s.Storage).FirstOrDefault(i => i.Storage.ProductId == c.ProductId),
                ColorsName = c.Product.Storages.Where(s => s.ProductId == c.ProductId).Select(c => c.Colors.ColorName).ToList(),
                Discount = c.Product.Discount,
                ProductTitle = c.Product.ProductTitle,
            }).ToList();
        }
        public int GetCountLikeCommentProduct(int commentId)
        {
            return _context.ProductCommnetLikes.Count(l => l.CommentId == commentId);
        }


        #endregion

        #region Notification

        public void AddNotification(int ProductId, string userName, bool Available, bool Off)
        {
            var userid = _userService.GetUserIdByUserName(userName);

            DataLayer.Entities.Notification.Notification notification = new DataLayer.Entities.Notification.Notification()
            {
                ProductId = ProductId,
                UserId = userid,
                Available = Available,
                Off = Off
            };

            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }


        #endregion

        #region Vote

        public void AddVote(int ProductId, string userName, int ManyVote)
        {
            var userid = _userService.GetUserIdByUserName(userName);
            Vote vote = new Vote();
            vote.UserId = userid;
            vote.ProductId = ProductId;
            vote.ManyVote = ManyVote;
            _context.Votes.Add(vote);
            _context.SaveChanges();

        }

        public VoteViewModel GetListVote(int ProductId)
        {
            var manyVote = _context.Votes.Where(l => l.ProductId == ProductId).Sum(v => v.ManyVote);
            var Votecount = _context.Votes.Where(l => l.ProductId == ProductId).Count();
            var averageVote = manyVote / Votecount;

            VoteViewModel voteViewModel = new VoteViewModel()
            {
                Votecount = Votecount,
                manyVote = manyVote,
                averageVote = averageVote
            };

            return voteViewModel;
        }

        public bool CheckVote(int ProductId, string userName)
        {
            var userid = _userService.GetUserIdByUserName(userName);
            bool Checked = _context.Votes.Any(v => v.ProductId == ProductId && v.UserId == userid);

            if (Checked)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

    }
}
