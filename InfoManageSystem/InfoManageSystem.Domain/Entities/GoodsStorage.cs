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

        public WareHouse WareHouse { get; set; }

        public Goods Goods { get; set; }
    }
}
