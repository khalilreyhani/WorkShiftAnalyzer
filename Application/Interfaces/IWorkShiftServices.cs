using Domain.Models.EmployeeWork;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWorkShiftServices
    {
        public Task<ServicesStatus> AddRangeAsync(List<EmployeeWorkLog> employeeWorkLogs);
        public List<Shift> GetShifts();

        public int GetShiftId(string name);



    }
}
