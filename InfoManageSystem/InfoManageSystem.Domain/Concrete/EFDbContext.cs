using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Domain.Concrete
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class EFDbContext:DbContext
    {
        public EFDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
