using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
namespace InfoManageSystem.Domain.Abstract
{
    public interface ICategoryRespository
    {
        IQueryable<Category> Category { get; }

        Category getCategoryById(int id);

        bool deleteCategory(int CategoryId);

        bool saveCategory(Category category);
    }
}
