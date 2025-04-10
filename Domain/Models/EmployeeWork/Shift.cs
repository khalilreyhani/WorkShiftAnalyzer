using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EmployeeWork
{
    public class Shift : BaseEntities
    {
        [Required]
        public string ShiftName { get; set; }  // نام شیفت (A, B, C)

        [Required]
        public TimeSpan StartTime { get; set; }  // ساعت شروع

        [Required]
        public TimeSpan EndTime { get; set; }    // ساعت پایان

        [Required]
        public TimeSpan BreakDuration { get; set; }  // مدت استراحت مجاز
    }
}
