using Medic.Database;
using Medic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Medic.Services
{
    public class CategoriesService
    {
        #region Singleton
        public static CategoriesService Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesService();

                return instance;
            }
        }
        private static CategoriesService instance { get; set; }

        private CategoriesService()
        {
        }
        #endregion
        public Category GetCategory(int ID)
        {
            using (var context = new MedicContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public List<Category> GetCategories()
        {
            using (var context = new MedicContext())
            {
                return context.Categories.Include(x=>x.Products)
                    .ToList();
            }
        }

        public int GetCategoriesCount(string search)
        {
            using (var context = new MedicContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null &&
                         category.Name.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Categories.Count();
                }
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var context = new MedicContext())
            {
                return context.Categories
                        .ToList();
            }
        }

        public List<Category> GetCategories(string search, int pageNo)
        {
            int pageSize = 3;

            using (var context = new MedicContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Categories.Where(category => category.Name != null &&
                         category.Name.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.ID)
                         .Skip((pageNo - 1) * pageSize)
                         .Take(pageSize)
                         .Include(x => x.Products)
                         .ToList();
                }
                else
                {
                    return context.Categories
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Products)
                        .ToList();
                }
            }
        }


        public List<Category> GetFeaturedCategories()
        {
            using (var context = new MedicContext())
            {
                return context.Categories.Where(x => x.isFeatured && x.ImageURL != null).ToList();
            }
        }

        public void SaveCategory(Category category)
        {
            using (var context = new MedicContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new MedicContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new MedicContext())
            {
                var category = context.Categories.Where(x=> x.ID == ID).Include(x=> x.Products).FirstOrDefault();

                context.Products.RemoveRange(category.Products); //FIRST DELETE PROD OF THIS CAT
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
