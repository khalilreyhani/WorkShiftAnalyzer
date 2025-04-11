using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.EmployeeWork
{
    public class EmployeeWorkLog:BaseEntities
    {

        [Required]
        public string EmployeeCode { get; set; } // کد کارمند

        [Required]
        public string EmployeeName { get; set; } // نام کارمند

        [Required]
        public DateTime Date { get; set; } // تاریخ

        [Required]
        public TimeSpan WorkStart { get; set; } 
        public TimeSpan WorkEnd { get; set; }
        public TimeSpan WorkHours { get; set; } // مدت زمان کارکرد روزانه
        public TimeSpan Usefulwork { get; set; } // مدت زمان مفید کارکرد روزانه


        [Required]
        public TimeSpan BreakTime { get; set; } // مدت استراحت در حین کار
        public string FileName { get; set; }


        [Required]
        public int ShiftId { get; set; } // کلید خارجی برای شیفت

        #region Relations
        [ForeignKey("ShiftId")]
        public virtual Shift Shift { get; set; } // ارتباط با جدول Shift
        #endregion
    }

}
