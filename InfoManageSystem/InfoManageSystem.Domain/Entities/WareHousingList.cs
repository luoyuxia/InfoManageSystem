using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InfoManageSystem.Domain.Entities
{
    [Table("WareHousingList")]
    public class WareHousingList
    {
        [Key]
        public int Id { get; set; }
        public DateTime WareHousingTime { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<WareHousingItem> WareHousingItems { get; set; }

    }
}
