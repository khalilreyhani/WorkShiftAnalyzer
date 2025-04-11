using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }

        public string EmployeeName { get; set; }
    }
}
