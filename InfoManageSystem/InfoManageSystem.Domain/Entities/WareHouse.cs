using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoManageSystem.Domain.Entities
{
    public enum WareHouseCapacity
    {
        Low,Medium,High
    }

    [Table("WareHouse")]
    public class WareHouse
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        
        [StringLength(maximumLength: 50)]
        public string Location { get; set; }

        public WareHouseCapacity Capacity { get; set; }

        public virtual ICollection<GoodsStorage> GoodsStorages { get; set; }

        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }
    }

}
