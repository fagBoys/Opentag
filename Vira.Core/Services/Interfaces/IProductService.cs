using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Berlance.Core.DTOs.Comment;
using Berlance.Core.DTOs.Product;
using Berlance.DataLayer.Entities.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Berlance.Core.DTOs.Product;

namespace Berlance.Core.Services.Interfaces
{
    public interface IProductService
    {
        #region Group
        //برای منوی صفحات
        List<ProductGroup> GetAllGroup();
        //برای آوردن گروه های اصلی در درج محصول
        List<SelectListItem> GetGroupForManagProduct();
        //برای آوردن زیر گروه ها در درج محصول
        List<SelectListItem> GetSubGroupForManagProduct(int groupId);

        void AddGroup(ProductGroup group);
        void UpdateGroup(ProductGroup group);
        ProductGroup GetGroupById(int id);


        #endregion

        #region AttributGroup

        //برای آوردن  مشخصات اصلی در درج محصول
        List<Attribut> GetAttributGroupForManagProduct();
        List<Attribut> GetAttributeValueForManagProduct();
        List<Attribut> GetAttributByGroupId(int id);
        List<Attribut> GetAttributeValueByGroupId(int id);

        List<ProductAttribute> GetProductAttributesForManageProduct(int id);
        List<Attribut> GetAllAttribut();
        void AddAttribut(Attribut attribut);
        void UpdateAttribut(Attribut attribut);
        void DeleteAttribut(int id);

        Attribut GetAttributsById(int id);
        #endregion

        #region Product
        Tuple<List<ShowproductListItemViewModel>, int> GetProduct(int pageId = 1, string filter = "",
            string orderByType = "date", int startprice = 0
            , int endPrice = 0, List<int> selectedGroups = null, List<string> colorName = null,
            string productDiscount = "off",
            string storageStock = "off", int take = 0);

        List<ShowProductForAdminViewModel> GetProductsForAdmin();
        List<ShowproductListItemViewModel> GetRelatedProduct(int subGroupid, int productId);
        List<ShowproductListItemViewModel> GetPopularProduct();

        List<ProductAttribute> GetAllProductAttributesForManageProduct();

        int AddProduct(CreateProductViewModel product, string userName);
        Product GetProductById(int productId);
        Product GetProductByStorageId(int storageId);
        int UpdateProduct(EditProductViewModel createProductViewModel, int productId, string Description);
        DetailProductViewModel GetProductForShow(int productId, int? colorId, string? size, int? storageId);

        void AddVisiteProduct(int productId);
        #endregion

        #region Comments

        #region Admin

        void AddAnswerComment(string Answer, int commentId , int userId);
        Tuple<List<ProductComment>, int> GetAllProductComment(int pageId = 1, string firstName = "", string lastName = "");
        Tuple<List<ProductComment>, int> GetListComment(int pageId = 1, string firstName = "", string lastName = "");
        void DeleteProductComment(int Id);

        #endregion
        void AddComment(ProductComment comment); 
        Tuple<List<ShowComment>, int> GetProductComment(int productId, int pageId = 1);
        int CountCommentForUser(string userName);

        Tuple<List<ShowComment>, int> GetListcommentForUser(string userName, int pageId = 1);
        void AddLikeComment(int commentId, string userName);

        #endregion

        #region Color

        List<Colors> GetColorsList();
        public Tuple<List<Colors>, int> GetColorsLists(int pageId = 1, string filter = "");

        public List<SelectListItem> GetColorsListItem();

        int AddColor(Colors colors);
        Colors GetColorById(int ColorId);
        int UpdateColor(Colors colors);

        #endregion

        #region Like
        void AddLike(int ProductId, string userName);

        List<ShowproductListItemViewModel> ListLikeForUser(string userName);

        int GetCountLikeCommentProduct(int commentId);

        #endregion

        #region Notification

        void AddNotification(int ProductId, string userName , bool Available , bool Off);


        #endregion

        #region Vote

        void AddVote(int ProductId, string userName, int ManyVote);

        VoteViewModel GetListVote(int ProductId);
        bool CheckVote(int ProductId , string UserName);

        #endregion
    }
}
