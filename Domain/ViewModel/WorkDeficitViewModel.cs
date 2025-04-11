using Domain.Models.EmployeeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class WorkDeficitViewModel
    {
      
        public List<WorkDeficitCounts> WorkDeficitCounts { get; set; } 
        public List<ExcessBreakCounts> ExcessBreakCounts { get; set; } 
    }

    public class WorkDeficitCounts
    {
        public string EmployeeCode { get; set; }

        public string EmployeeName { get; set; }
        public int Counts { get; set; } 

       
    } 
    public class ExcessBreakCounts
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int Counts { get; set; } 

       
    }

    public class EmployeeWorkLogViewModel
    {
        public List<UserViewModel> Employees { get; set; }
        public List <DateTime> DateTimes { get; set; }
    }
}
