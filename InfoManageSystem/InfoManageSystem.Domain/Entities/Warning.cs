using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManageSystem.Domain.Entities
{
    public class Warning
    {
        [Key]
        public int Id { get; set; }
        public int GoodsId { get; set; }

        [ForeignKey("GoodsId")]
        public virtual Goods Goods { get; set; }
    }
}
