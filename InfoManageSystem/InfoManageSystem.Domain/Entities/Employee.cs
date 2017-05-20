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
    public enum Role
    {
        Admin,User,Manager
    }

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(maximumLength:20)]
        public string Account { get; set; }

        [Required]
        [StringLength(maximumLength:200)]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength:20)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        [DefaultValue("DefaultAvatar")]
        public string Avatar { get; set; }

        public Role Role { get; set; }

        public DateTime BirthDay { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        public virtual ICollection<WareHousingList> WareHousingLists { get; set; }

    }
}
