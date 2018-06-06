using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> Context;
        IRepository<ProductCatergory> productCategories;

        public HomeController(IRepository<Product> productContect, IRepository<ProductCatergory> productCategoryContext)
        {
            Context = productContect;
            productCategories = productCategoryContext;
        }

        public ActionResult Index(string Category=null)
        {
            List<Product> products;
            List<ProductCatergory> catergories = productCategories.Collection().ToList();

            if(Category == null)
            {
               products =  Context.Collection().ToList();
            }
            else
            {
                products = Context.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCatergories = catergories;
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

        public ActionResult Details(string Id)
        {
            Product product = Context.find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
    }
}