using Medic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medic.Web.ViewModels
{
    public class ProductsWidgetViewModel
    {
        public List<Product> Products { get; set; }

        public bool IsLatestProducts { get; set; }
    }
}