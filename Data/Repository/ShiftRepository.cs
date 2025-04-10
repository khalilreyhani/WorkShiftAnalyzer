using Domain.Interfaces;
using Domain.Models.EmployeeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Shift Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shift> GetAll(Expression<Func<Shift, bool>> where = null)
        {
            throw new NotImplementedException();
        }

        public void Insert(Shift entity)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Shift entity)
        {
            throw new NotImplementedException();
        }
    }
}
