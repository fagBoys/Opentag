using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vira.DataLayer.Entities.Product
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? SubGroup { get; set; }

        [Required]
        public int UserId { get; set; }


        [Display(Name = "تیتر محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ProductTitle { get; set; }

        [Display(Name = " توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductDescription { get; set; }

        [Display(Name = " تخفیفات")]
        public int? Discount { get; set; }

        [Display(Name = " جدول سایز")]
        public string? SizeTable { get; set; }

        [Display(Name = "بازدید از پروداکت")]
        public int VisitProduct { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }



        #region Relations

        [ForeignKey("UserId")]
        public User.User User { get; set; }

        [ForeignKey("GroupId")]
        public ProductGroup ProductGroup { get; set; }
        [ForeignKey("SubGroup")]
        public ProductGroup Group { get; set; }

        public ICollection<Storage.Storage> Storages  { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<Vote> Votes { get; set; }
        
        //public List<OrderDetail> OrderDetails { get; set; }
        //public List<UserProduct> UserProducts { get; set; }
        //public List<ProductVote> ProductVotes { get; set; }
        //public List<Question.Question> Questions { get; set; }
        //public ICollection<ProductColors> ProductColors { get; set; }

        #endregion


    }
}
