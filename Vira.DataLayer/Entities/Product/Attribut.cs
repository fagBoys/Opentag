using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.DataLayer.Entities.Product
{
    public class Attribut
    {
        [Key]
        public int AttributId { get; set; }
      
        
        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string AttributTitel { get; set; }

        public int? ParentId { get; set; }


        public int GroupId { get; set; }

        #region Relation

        [ForeignKey("ParentId")]
        public ICollection<Attribut> Attributs { get; set; }

        [ForeignKey("GroupId")] 
        public ProductGroup ProductGroup { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }

        //public static implicit operator Attribute(Attribut v)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}
