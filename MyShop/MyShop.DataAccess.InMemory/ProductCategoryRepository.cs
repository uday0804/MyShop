using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCatergory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCatergory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCatergory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;

        }

        public void Insert(ProductCatergory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCatergory productCategory)
        {
            ProductCatergory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product category Not Found");
            }
        }

        public ProductCatergory find(string Id)
        {
            ProductCatergory productCatergory = productCategories.Find(p => p.Id == Id);
            if (productCategories != null)
            {
                return productCatergory;
            }
            else
            {
                throw new Exception("Product Category Not FOund");
            }
        }

        public IQueryable<ProductCatergory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCatergory productCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product Category Not FOund");
            }
        }

    }
}
