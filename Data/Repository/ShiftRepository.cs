using Context;
using Domain.Interfaces;
using Domain.Models.EmployeeWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly DBContext _ctx;

        public ShiftRepository(DBContext ctx)
        {
            _ctx = ctx;
        }

        public void Delete(int Id)
        {
            var item = Get(Id);
            if (item != null)
            {
                item.IsDeleted = true;
                Update(item);
                SaveChanges();
            }
        }

        public Shift Get(int Id)
        {
            return _ctx.Shifts.FirstOrDefault(x => x.Id == Id);
        }

        public async Task <IEnumerable<Shift>> GetAll(Expression<Func<Shift, bool>> where = null)
        {
            IQueryable<Shift> query = _ctx.Shifts;

            if (where != null)
                query = query.Where(where);

            return query.ToList();
        }

        public int GetShiftId(string shift)
        {
            try
            {
                return _ctx.Shifts.FirstOrDefault(x => x.ShiftName == shift).Id;
            }
            catch
            {
                return 0;
            }
           
        }

        public void Insert(Shift entity)
        {
            _ctx.Shifts.Add(entity);
            SaveChanges();
        }

        public bool IsExist(int Id)
        {
            return _ctx.Shifts.Any(x => x.Id == Id);
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void Update(Shift entity)
        {
            _ctx.Shifts.Update(entity);
            SaveChanges();
        }
    }
}
