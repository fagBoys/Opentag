using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.DataLayer.Entities.Product
{
    public class Image
    {
        [Key]
        public int  ImageId { get; set; }

        [Display(Name = "نام عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(700, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ImageName { get; set; }

        [Required]
        public bool IsPrimary { get; set; }

        [Required]
        public int StorageId { get; set; }
        public Storage.Storage Storage { get; set; }
    }
}
