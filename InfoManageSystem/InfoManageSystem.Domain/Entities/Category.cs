using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;
namespace InfoManageSystem.Domain.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 20)]
        public string Name { get; set; }

        [StringLength(maximumLength: 100)]
        [Required]
        [DefaultValue("无")]
        public string Description { get; set; }

        public virtual ICollection<Goods> GoodsList { get; set; }

        
    }
}
