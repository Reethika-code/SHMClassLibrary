using Microsoft.Data.SqlClient;
using SHMClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHMClassLibrary
{
    public class CategoryDAL
    {
        public void AddCategory(CategoryModel newCategory)
        {
            using (var context = new CategoryDbContext())
            {
                context.Categories.Add(newCategory);
                context.SaveChanges();
            }
        }

        public List<CategoryModel> GetAllCategories()
        {
            using (var context = new CategoryDbContext())
            {
                var categories = context.Categories.ToList<CategoryModel>();
                return categories;
            }
        }

        public List<CategoryModel> GetCategoriesByName(string categoryName)
        {
            using (var context = new CategoryDbContext())
            {
                var categories = context.Categories.Where(c => c.Category == categoryName).ToList<CategoryModel>();
                foreach (var res in categories)
                {
                    Console.WriteLine(res.ToString());
                }
                return categories;
            }
        }

        public static void UpdateCategory(int categoryId, string newCategory, DateTime newActivateDate, DateTime? newDeactivateDate, string newRemarks)
        {
            using (var dbContext = new CategoryDbContext())
            {
                var category = dbContext.Categories.Find(categoryId);
                if (category != null)
                {
                    category.Category = newCategory;
                    category.CatActivateDate = newActivateDate;
                    category.CatDeactivateDate = newDeactivateDate;
                    category.Remarks = newRemarks;
                    dbContext.SaveChanges();
                }
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (var dbContext = new CategoryDbContext())
            {
                var category = dbContext.Categories.Find(categoryId);
                if (category != null)
                {
                    dbContext.Categories.Remove(category);
                    dbContext.SaveChanges();
                }
            }
        }

    }
}