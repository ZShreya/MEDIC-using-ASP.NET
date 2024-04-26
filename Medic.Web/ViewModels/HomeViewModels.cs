using Medic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medic.Web.ViewModels
{
    public class HomeViewModels
    {
        public List<Category>FeaturedCategories {get;set;}
        public List<Category> FeaturedProducts { get; set; }

    }
}