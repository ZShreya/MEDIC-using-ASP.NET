﻿using Medic.Services;
using Medic.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medic.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels();
            model.FeaturedCategories = CategoriesService.Instance.GetFeaturedCategories();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}