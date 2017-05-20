using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoManageSystem.Domain.Entities
{
    [Table("WareHousingItem")]
    public class WareHousingItem
    {
        [Key]
        public int Id { get; set; }
        public decimal PurchasePrice { get; set; }

        public int Quantity { get; set; }

        //所进的仓库
        public virtual WareHouse WareHouse { get; set; }


        public virtual Goods Goods { get; set; }

        public virtual WareHousingList WareHousingList { get; set; }

        
    }
}
