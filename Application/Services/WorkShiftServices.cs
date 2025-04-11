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

        public int GetShiftId(string name)
        {
          var item= _shiftRepository.GetAll(x=>x.ShiftName==name);
            if(item!=null)
                return item.Id;

            return 0;
        }

        public List<Shift> GetShifts()
        {
            throw new NotImplementedException();
        }

        public Task<List<WorkDeficitCounts>> WorkDeficitCalc()
        {
            throw new NotImplementedException();
        }
    }
}
