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
        IEnumerable<Category> getAllCategory(int offset, int pageSize, out int total);

        IEnumerable<Category> getCategoryByName(int offset,int pageSize,string name,out int total);

        bool saveCategory(Category category);

        bool deleteCategory(int CategoryID);
    }
}
