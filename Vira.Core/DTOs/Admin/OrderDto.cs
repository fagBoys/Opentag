using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.DataLayer.Entities.Order;

namespace Vira.Core.DTOs.Admin
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderRegistrationTime { get; set; }
        public Guid RequestId { get; set; }
        public int UserId { get; set; }
        public Order.OrdarState OrdarState { get; set; }
        public int ProductCount { get; set; }
        public int SumPrice { get; set; }
    }
}
