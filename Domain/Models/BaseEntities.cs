using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class BaseEntities
    {
        [Key]
        [Display(Name = "Id")]
        [MaxLength(10)]

        public int Id { get; set; }

        [Display(Name = "DateTimeCreateDate")]
        [MaxLength(20)]

        public DateTime DateTimeCreateDate { get; set; } = DateTime.Now;
        [MaxLength(10)]

        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
