using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.Core.DTOs.Payment
{
    public class RequestPayDto
    {
        public class ResultRequestPayDto
        {
            public Guid Guid { get; set; }
            public int Amount { get; set; }

        }

        public class RequestAddNewOrder
        {
            public int  CartId { get; set; }
            public Guid RequsetPayId { get; set; }
            public string Authority { get; set; }
            public long RefId { get; set; }
        }
    }
}
