using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Domain.Entities;
using System.Data.Entity;

namespace InfoManageSystem.Domain.Concrete
{
    public class EFReproductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get
            {
                var products = from p in context.Products
                             select p;
                return (context.Products.Where(p=>p.ProductID==1)).Include(p=>p.ProductType);
                
            }
        }
    }
}
