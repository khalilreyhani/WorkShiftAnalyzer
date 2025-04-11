using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGneralRepository<T> where T : BaseEntities
    {
       
          Task  <IEnumerable<T>> GetAll(Expression<Func<T,bool>> where = null);
            T Get(int Id);
            void Insert(T entity);
            void Update(T entity);
            void Delete(int Id);
            bool IsExist(int Id);
        void SaveChanges();


        }
    


    
}
