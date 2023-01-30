using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.DataLayer.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;

namespace Vira.Core.DTOs.Cart
{
    public class GetMyCart
    {

        public class CartDto
        {
            public int CartId { get; set; }
            public int productCount { get; set; }
            public int SumAmount { get; set; }
            public List<CartItemDto> CartItems { get; set; }
        }

        public class CartItemDto
        {
            public int Id { get; set; }
            public int storageid { get; set; }
            public string ProductTitle { get; set; }
            public string ImageProduct { get; set; }
            public int count { get; set; }
            public int price { get; set; }
            public string NameColor { get; set; }
            public string  Size { get; set; }
            public int  StorageCount { get; set; }
            public int ProductId { get; set; }

        }
    }
}
