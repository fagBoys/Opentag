using Opentag.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Opentag.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            ApplicationDbContext Context = new ApplicationDbContext();

            Articles = Context.Article.OrderByDescending(A => A.ArticleId).Take(4).Select(A =>
            new IndexArticlesViewModel
            {

                ArticleId = A.ArticleId,
                ArticleTitle = A.Title

            }).ToList();
        }

        [Required(ErrorMessage = "The Collection Postcode is required")]
        [MinLength(5)]
        public string CollectionLocation { get; set; }

        [Required(ErrorMessage = "The Delivery Postcode is required")]
        [MinLength(5)]
        public string DeliveryLocation { get; set; }

        public DateTime CollectionDate { get; set; }

        public DateTime CollectionTime { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime DeliveryTime { get; set; }

        [Required(ErrorMessage = "The Email Address is required")]
        [MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "The Phone Number is required")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The Full Name is required")]
        [MaxLength(50)]
        public string FullName { get; set; }

        public string VehicleSize { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Accepting The Terms is required")]
        public bool Terms { get; set; }

        [MinLength(1)]
        public string GoogleCaptchaToken { get; set; }

        public IEnumerable<IndexArticlesViewModel> Articles { get; set; }
    }
}
