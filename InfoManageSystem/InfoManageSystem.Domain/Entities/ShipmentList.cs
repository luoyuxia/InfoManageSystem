using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace InfoManageSystem.Domain.Entities
{
    [Table("ShipmentList")]
    public class ShipmentList
    {
        [Key]
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ShipmentTime { get; set; }

        [StringLength(maximumLength:50)]
        [DefaultValue("无")]
        public string ShipmentAddress { get; set; }

        public virtual Dealers Dealers { get; set; }


        public virtual ICollection<ShipmentItem> ShipmentItems { get; set; }

       

    }
}
