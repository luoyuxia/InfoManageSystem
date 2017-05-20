using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoManageSystem.Domain.Entities
{
    [Table("Goods")]
    public class Goods
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        public string name;

        [DefaultValue(0)]
        [Required]
        public int minNum { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }

        //商品的存储地点
        public virtual ICollection<GoodsStorage> GoodsStorages { get; set; }

        

    }
}
