
using Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{

    public class GneralRepository<T> : IGneralRepository<T> where T : BaseEntities
    {
        #region property
        private readonly DBContext _applicationDbContext;
        private DbSet<T> entities;

        #endregion

       

        public GneralRepository(/*BoxCollection collection*/  DBContext ctx)
        {
            this._applicationDbContext = ctx;
            entities = _applicationDbContext.Set<T>();
           
        }

        public void Delete(int Id)
        {
            var MyModel = Get(Id);
            if (MyModel == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                entities.Remove(MyModel);
                SaveChanges();
            }
        }




        public T Get(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    return entities.SingleOrDefault(c => c.Id == Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where = null)
        {
            return entities.Where(where).AsEnumerable();
        }



        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public bool IsExist(int Id)
        {
            return entities.Where(x => x.Id == Id).Any();
        }


        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
