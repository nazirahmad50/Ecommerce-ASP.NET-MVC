﻿using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Web.ViewModels
{
    public class CheckoutViewModels
    {
        public List<Product> CartProducts { get; set; }

        public List<int> CartProductIds { get; set; }
    }
}