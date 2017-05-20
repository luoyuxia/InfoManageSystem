using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfoManageSystem.Domain.Entities
{
    [Table("Dealers")]
    public class Dealers
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(maximumLength:20)]
        public string Name { get; set; }

        [StringLength(maximumLength: 20)]
        public string Phone { get; set; }

        [StringLength(maximumLength: 50)]
        public string Address { get; set; }
    }
}
