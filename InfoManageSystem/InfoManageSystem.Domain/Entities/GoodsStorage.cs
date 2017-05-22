using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InfoManageSystem.Domain.Entities
{
    [Table("GoodsStorage")]
    public class GoodsStorage
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int WareHouseId { get; set; }

        public int GoodsId { get; set; }

        [ForeignKey("WareHouseId")]
        public WareHouse WareHouse { get; set; }

        [ForeignKey("GoodsId")]
        public Goods Goods { get; set; }
    }
}
