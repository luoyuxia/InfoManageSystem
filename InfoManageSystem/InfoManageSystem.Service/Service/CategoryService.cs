using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Service.IService;
using System.Linq.Expressions;

namespace InfoManageSystem.Service.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRespository categoryRespository;
        public CategoryService(ICategoryRespository categoryRespository)
        {
            this.categoryRespository = categoryRespository;
        }

        public bool deleteCategory(int CategoryID)
        {
            return categoryRespository.deleteCategory(CategoryID);
        }


        //得到所有的商品类别,不筛选
        public IEnumerable<Category> getAllCategory()
        {
            return categoryRespository.Category.AsEnumerable();
        }

        public IEnumerable<Category> getAllCategoryByName(string name)
        {
            return categoryRespository.Category.Where(c => c.Name.Contains(name)).AsEnumerable();
        }

        //根据商品类别名称得到所有的商品类别
        public IEnumerable<Category> getCategoryByName(int offset, int pageSize, string name, out int total)
        {
            Expression<Func<Category, bool>> exp = c => c.Name.Contains(name);
            return getCategoryPageable(offset, pageSize, out total, exp);
        }

        public Category GetSingleCategory(int categoryID)
        {
            return categoryRespository.getCategoryById(categoryID);
        }

        public bool saveCategory(Category category)
        {
            return categoryRespository.saveCategory(category);
        }

        private IEnumerable<Category> getCategoryPageable(int offset, int pageSize, out int totalCount, Expression<Func<Category, bool>> whereLambda)
        {
            totalCount = categoryRespository.Category.Where(whereLambda).Count();
            return categoryRespository.Category.Where(whereLambda).OrderBy(c => c.Id).Skip(pageSize * (offset - 1)).Take(pageSize).AsEnumerable();
        }
    }
}
