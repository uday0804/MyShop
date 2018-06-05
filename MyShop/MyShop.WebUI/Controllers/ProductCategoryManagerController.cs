using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.DataAccess.InMemory;
using MyShop.Core.Models;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        InMemoryRepository<ProductCatergory> Context;

        public ProductCategoryManagerController()
        {
            Context = new InMemoryRepository<ProductCatergory>();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCatergory> productCatergories = Context.Collection().ToList();
            return View(productCatergories);
        }

        public ActionResult Create()
        {
            ProductCatergory productCatergory = new ProductCatergory();
            return View(productCatergory);
        }

        [HttpPost]
        public ActionResult Create(ProductCatergory productCatergory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCatergory);
            }
            else
            {
                Context.Insert(productCatergory);
                Context.Commit();

                return RedirectToAction("Index");
            }
        }


        public ActionResult Edit(string Id)
        {
            ProductCatergory productCatergory = Context.find(Id);
            if (productCatergory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCatergory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCatergory product, string Id)
        {
            ProductCatergory productCategoryToEdit = Context.find(Id);
            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                productCategoryToEdit.Category = product.Category;

                Context.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Delete(string Id)
        {
            ProductCatergory productCategoryToDelete = Context.find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCatergory productCategoryToDelete = Context.find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                Context.Delete(Id);
                Context.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}