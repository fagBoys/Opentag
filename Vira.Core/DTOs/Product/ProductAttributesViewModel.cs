﻿using Berlance.DataLayer.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.Core.DTOs.Product
{
    public class ProductAttributesViewModel
    {
        public Attribut Title { get; set; }

        public Attribut Value { get; set; }
    }
}
