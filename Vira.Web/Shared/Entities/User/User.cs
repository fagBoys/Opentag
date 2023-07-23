﻿using System.ComponentModel.DataAnnotations;

namespace Vira.Web.Shared.Entities.User
{
    public class User
    {
        [Key]
        public int  UserId { get; set; }

        [Display(Name = "نام کاربری ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(11,MinimumLength = 11 ,ErrorMessage = "تعداد کاراکتر مجاز نمی باشد")]
        public string  UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string  Password { get; set; }

        [Display(Name = "نام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string  FirstName { get; set; }

        [Display(Name = "نام خانوادگی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string  LastName { get; set; }


        [Display(Name = "کدملی ")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کدملی وارد شده صحیح نمی باشد")]
        public string  IdCode { get; set; }

        [Display(Name = "ایمیل ")]
        public string  Email { get; set; }

        [Display(Name = "تلفن ثابت ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تلفن ثابت وارد شده صحیح نمی باشد")]
        public string LandlineTelephone { get; set; }
        
        [Display(Name = "تلفن همرا ")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تلفن موبایل وارد شده صحیح نمی باشد")]
        public string PhoneNumber { get; set; }

        [Display(Name = "اینستاگرام")]
        public string Instagram { get; set; }

        [Display(Name = "تاریخ تولد ")]
        public DateTime BirthDate  { get; set; }

        [Display(Name = "شهر ")]
        public string  City { get; set; }

        [Display(Name = "استان ")]
        public string  State { get; set; }

        [Display(Name = "آدرس ")]
        [MaxLength(200)]
        public string  Address { get; set; }

        [Display(Name = "کدپستی ")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کدپستی وارد شده صحیح نمی باشد")]
        public string  PostCode { get; set; }

        [Display(Name = "نام شرکت ")]
        [MaxLength(30)]
        public string CompanyName { get; set; }

        [Display(Name = "آدرس شرکت ")]
        [MaxLength(200)]
        public string CompanyAddress { get; set; }

        [Display(Name = "کد پستی شرکت ")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کدپستی وارد شده صحیح نمی باشد")]
        public string CompanyPostCode { get; set; }

        [Display(Name = "وضعیت حذف")]
        public bool IsDelete { get; set; }

        [Display(Name = "کد فعال سازی")]
        public string ActiveCode { get; set; }

        [Display(Name = "عکس پروفایل")]
        [MaxLength(200)]
        public string UserAvatar { get; set; }


        [Display(Name = "وضعیت فعال سازی")]
        public bool IsActive { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }


    }
}