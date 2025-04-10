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
    internal class EmployeeWorkLogRepository : IEmployeeWorkLogRepository
    {
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public EmployeeWorkLog Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeWorkLog> GetAll(Expression<Func<EmployeeWorkLog, bool>> where = null)
        {
            throw new NotImplementedException();
        }

        public void Insert(EmployeeWorkLog entity)
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

        public void Update(EmployeeWorkLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
