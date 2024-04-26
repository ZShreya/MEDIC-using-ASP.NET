using Medic.Entities;
using Medic.Services;
using Medic.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medic.Web.Controllers
{
    public class ProductController : Controller
    {
        //ProductsService productsService = new ProductsService();
        
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search, int? pageNo) 
        {
            var pageSize = ConfigurationsService.Instance.PageSize();

            ProductSearchViewModel model = new ProductSearchViewModel();
            model.SearchTerm = search;
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            
            var totalRecords = ProductsService.Instance.GetProductsCount(search);
            model.Products = ProductsService.Instance.GetProducts(search, pageNo.Value, 10);

            model.Pager = new Pager(totalRecords, pageNo, pageSize);

            return PartialView(model);
        }


        // !!!!!!!!!!!OLD ONE BEFORE 18 !!!!!!!!!!!
        //public ActionResult ProductTable(string search, int? pageNo)
        //{
        //    ProductSearchViewModel model = new ProductSearchViewModel();
        //    model.SearchTerm = search;
        //    model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

        //    model.Products = ProductsService.Instance.GetProducts(model.PageNo);

        //    if (string.IsNullOrEmpty(search) == false)
        //    {
        //        model.SearchTerm = search;
        //        model.Products = model.Products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
        //    }


        //    return PartialView(model);
        //}


        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();

            model.AvailableCategories = CategoriesService.Instance.GetCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
                var newProduct = new Product();
                newProduct.Name = model.Name;
                newProduct.Description = model.Description;
                newProduct.Price = model.Price;
                newProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);
                newProduct.ImageURL = model.ImageURL;
                ProductsService.Instance.SaveProduct(newProduct);

                return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();
            var product = ProductsService.Instance.GetProduct(ID);

            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.CategoryID = product.Category != null ? product.Category.ID : 0;
            model.AvailableCategories = CategoriesService.Instance.GetCategories();
            model.ImageURL = product.ImageURL;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = ProductsService.Instance.GetProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.Price = model.Price;

            existingProduct.Category = null;
            existingProduct.CategoryID = model.CategoryID;
            //existingProduct.ImageURL = model.ImageURL;

            if (!string.IsNullOrEmpty(model.ImageURL))
            {
                existingProduct.ImageURL = model.ImageURL;
            }
            ProductsService.Instance.UpdateProduct(existingProduct);
            
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsService.Instance.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }

        //[HttpGet]
        //public ActionResult Details(int ID)
        // {
        //    ProductViewModel model = new ProductViewModel();

        //    model.Product = ProductsService.Instance.GetProduct(ID);

        //    if (model.Product == null) return HttpNotFound();

        //     return View(model);
        //  }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            ProductViewModel model = new ProductViewModel();
            model.Product = ProductsService.Instance.GetProduct(ID);


            return View(model);
        }


    }
}