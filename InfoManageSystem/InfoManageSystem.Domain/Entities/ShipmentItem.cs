using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoManageSystem.Domain.Entities
{
    [Table("ShipmentItem")]
    public class ShipmentItem
    {
        [Key]
        public int Id { get; set; }

        public decimal SellPrice { get; set; }

        public int Quantity { get; set; }

        public virtual Goods Goods { get; set; }

        public virtual ShipmentList ShipmentList { get; set; }

        
        
    }
}
