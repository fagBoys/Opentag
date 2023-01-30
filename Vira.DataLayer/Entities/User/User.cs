using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Vira.DataLayer.Entities.Article;
using Vira.DataLayer.Entities.Product;
using Vira.DataLayer.Entities.Support;

//using Vira.DataLayer.Entities.Product;

namespace Vira.DataLayer.Entities.User
{
    public class User
    {
        public User()
        {
        }

        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Firstname { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string LastName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "تاریخ تولد")]
        [MaxLength(12, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public DateTime BirthDate { get; set; } 

        [Display(Name = "جنسیت")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Sex { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? IdCode { get; set; }

        [Display(Name = "شماره تلفن همرا")]
        [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "استان")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? State { get; set; }


        [Display(Name = "شهر")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? City { get; set; }


        [Display(Name = "کد پستی")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? PostCode { get; set; }


        [Display(Name = "آدرس")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Address { get; set; }

        [Display(Name = "ایمیل")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string? Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }

        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ActiveCode { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserAvatar { get; set; }

        [Display(Name = "شماره کارت")]
        [MaxLength(16, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? CartNumber { get; set; }

        [Display(Name = "دارنده حساب")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Accountowner { get; set; }


        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        public bool IsDelete { get; set; }

        #region Relations

        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<Product.Product> Product { get; set; }
        public virtual ICollection<Order.Order>Orders { get; set; }
        public virtual ICollection<Vote>Votes { get; set; }
        public ICollection<MessengerSupport> MessengerSupport { get; set; }
        public List<UserDiscountCode> UserDiscountCodes { get; set; }
        public ICollection<ArticleCommentLike> ArticleCommentLike { get; set; }
        public ICollection<ProductCommnetLike> ProductCommnetLike { get; set; }
        public ICollection<ProductReturn.ProductReturn> ProductReturns { get; set; }

        //public virtual List<Wallet.Wallet> Wallets { get; set; }
        //public virtual List<Order.Order> Orders { get; set; }
        //public List<Question.Question> Questions { get; set; }
        //public List<UserProduct> UserProduct { get; set; }
        //public List<ProductComment> ProductComments { get; set; }
        //public List<ProductVote> ProductVotes { get; set; }

        #endregion

    }
}
