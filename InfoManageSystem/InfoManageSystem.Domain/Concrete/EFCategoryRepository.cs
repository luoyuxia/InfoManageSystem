using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;

namespace InfoManageSystem.Domain.Concrete
{
    public class EFCategoryRepository : ICategoryResposity
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Category> Category
        {
            get
            {
                return context.Category;
            }
        }

        public bool deleteCategory(int CategoryId)
        {
            Category category = context.Category.Find(CategoryId);
            if (category == null)
                return false;
            else
            {
                context.Category.Remove(category);
                context.SaveChanges();
                return true;
            }            
        }

        public Category getCategoryById(int id)
        {
            return context.Category.Find(id);
        }

        public bool saveCategory(Category category)
        {
            //如果categoryId小于0，则认为是进行添加category
            if (category.Id <0)
            {
                context.Category.Add(category);
            }
            //否则 认为是修改category
            else
            {
                Category dbEntry = context.Category.Find(category.Id);
                if(dbEntry!=null)
                {
                    context.Entry(dbEntry).CurrentValues.SetValues(category);
                }
            }
            context.SaveChanges();
            return true;
        }
    }
}
