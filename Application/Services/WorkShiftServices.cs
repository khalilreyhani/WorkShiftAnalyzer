using Application.Interfaces;
using Context;
using Domain.Interfaces;
using Domain.Models.EmployeeWork;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WorkShiftServices: IWorkShiftServices
    {
        private IEmployeeWorkLogRepository _employeeWorkLogRepository;
        private IShiftRepository _shiftRepository;
        public WorkShiftServices(IShiftRepository shiftRepository,IEmployeeWorkLogRepository employeeWorkLogRepository)
        {
            _employeeWorkLogRepository = employeeWorkLogRepository; 
            _shiftRepository = shiftRepository;
            
        }

        public async Task<ServicesStatus> AddRangeAsync(List<EmployeeWorkLog> employeeWorkLogs)
        {
            try
            {
                await _employeeWorkLogRepository.AddRangeEmployeeWork(employeeWorkLogs);
                return ServicesStatus.sucsuccess;
            }
            catch (Exception ex)
            {
                return ServicesStatus.failed;

            }



        }

        public async Task<List<ExcessBreakCounts>> ExcessBreakCalc()
        {
           
            return await _employeeWorkLogRepository.GetAllExcessBreak();
   
               


           

        }

        public async Task<EmployeeWorkLogViewModel> GetAllUserAndDates()
        {
            if (_employeeWorkLogRepository == null)
            {
                throw new Exception("Repository is null!");
            }

            return new EmployeeWorkLogViewModel
            {
                Employees = await _employeeWorkLogRepository.GetAllUser() ?? new List<UserViewModel>(),
                DateTimes = await _employeeWorkLogRepository.GetDays() ?? new List<DateTime>()
            };
        }

        public async Task<EmployeeWorkLog> GetEmployeeWorkLog(string Ecode, DateTime Data)
        {
            
           return await _employeeWorkLogRepository.GetWorkLog(Ecode,Data);

        }

        public async Task<List<EmployeeWorkLog>> GetEmployeeWorkLogs()
        {
            
            
             return (List<EmployeeWorkLog>)await _employeeWorkLogRepository.GetAll();
        }

        public int GetShiftId(string name)
        {
           return _shiftRepository.GetShiftId(name);
        }

        public List<Shift> GetShifts()
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkDeficitCounts>> WorkDeficitCalc()
        {
            return await _employeeWorkLogRepository.GetAllWorkDeficit();
        }
    }
}
