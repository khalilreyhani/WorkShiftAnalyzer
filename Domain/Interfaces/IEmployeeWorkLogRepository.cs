using Domain.Models.EmployeeWork;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmployeeWorkLogRepository:IGneralRepository<EmployeeWorkLog>
{

        public Task AddRangeEmployeeWork(List<EmployeeWorkLog> employeeWorkLogs);

        public Task<List<ExcessBreakCounts>> GetAllExcessBreak();
        public Task<List<WorkDeficitCounts>> GetAllWorkDeficit();
        public Task<List<UserViewModel>> GetAllUser();
        public Task<List<DateTime>> GetDays();
        public Task<EmployeeWorkLog> GetWorkLog(string Ecode, DateTime Data);

    }


}
