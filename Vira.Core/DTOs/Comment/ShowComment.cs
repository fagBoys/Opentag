using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.DataLayer.Entities.Product;

namespace Vira.Core.DTOs.Comment
{
    public class ShowComment
    {
        public int ProductCommentId { get; set; }
        public string ProductComment { get; set; }
        public string ProductAnswerComment { get; set; }
        public DateTime CarateDateTime { get; set; }
        public string UserName { get; set; }
        public string UserAvatar { get; set; }
    }
}
