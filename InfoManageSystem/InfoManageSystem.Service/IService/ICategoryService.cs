using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
namespace InfoManageSystem.Service.IService
{
    public interface ICategoryService
    {
        IEnumerable<Category> getAllCategory();

        IEnumerable<Category> getCategoryByName(int offset,int pageSize,string name,out int total);

        IEnumerable<Category> getAllCategoryByName(string name);

        bool saveCategory(Category category);

        Category GetSingleCategory(int categoryID);

        bool deleteCategory(int CategoryID);
    }
}
