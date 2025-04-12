using Domain.Models.EmployeeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShiftRepository:IGneralRepository<Shift>
{
        public int GetShiftId(string shift);
}
}
