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
            this.Configuration.LazyLoadingEnabled = true;
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<WareHouse> WareHouse { get; set; }
        public virtual DbSet<GoodsStorage> GoodsStorage { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Dealers> Dealers { get; set; }
        public virtual DbSet<WareHousingList> WareHousingList { get; set; }
        public virtual DbSet<WareHousingItem> WareHousingItem { get; set; }
        public virtual DbSet<ShipmentList> ShipmentList { get; set; }
        public virtual DbSet<ShipmentItem> ShipmentItem { get; set; }
        public virtual DbSet<Warning> Warning { get; set; }
    }
}
