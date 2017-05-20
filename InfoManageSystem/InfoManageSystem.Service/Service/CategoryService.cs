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
        private ICategoryResposity categoryResposity;
        public CategoryService(ICategoryResposity categoryResposity)
        {
            this.categoryResposity = categoryResposity;
        }

        public bool deleteCategory(int CategoryID)
        {
            return categoryResposity.deleteCategory(CategoryID);
        }


        //得到所有的商品类别,不筛选
        public IEnumerable<Category> getAllCategory(int offset, int pageSize, out int total)
        {
            return getCategoryByName(offset, pageSize, "", out total);
        }

        //根据商品类别名称得到所有的商品类别
        public IEnumerable<Category> getCategoryByName(int offset, int pageSize, string name, out int total)
        {
            Expression<Func<Category, bool>> exp = c => c.Name.Contains(name);
            return getCategoryPageable(offset, pageSize, out total, exp);       
        }

        public bool saveCategory(Category category)
        {
            return categoryResposity.saveCategory(category);
        }

        private IEnumerable<Category> getCategoryPageable(int offset, int pageSize,out int totalCount, Expression<Func<Category, bool>> whereLambda)
        {
            totalCount = categoryResposity.Category.Where(whereLambda).Count();
            return categoryResposity.Category.Where(whereLambda).OrderBy(c=>c.Id).Skip(pageSize * (offset - 1)).Take(pageSize).ToList();
        }
    }
}
