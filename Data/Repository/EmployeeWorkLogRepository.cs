using Context;
using Domain.Interfaces;
using Domain.Models.EmployeeWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
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
        public class EmployeeWorkLogRepository : IEmployeeWorkLogRepository
        {
            private readonly DBContext _ctx;
            public EmployeeWorkLogRepository(DBContext ctx)
            {
                _ctx = ctx;
            }

            public async Task AddRangeEmployeeWork(List<EmployeeWorkLog> employeeWorkLogs)
            {
                if (_ctx.EmployeeWorkLogs.Any())
                {
                    var existingEntries = await _ctx.EmployeeWorkLogs
                        .Where(e => employeeWorkLogs
                            .Select(w => new { w.EmployeeCode, w.Date })
                            .Any(log => log.EmployeeCode == e.EmployeeCode && log.Date == e.Date))
                        .ToListAsync();

                    var newEntries = employeeWorkLogs
                        .Where(log => !existingEntries.Any(e => e.EmployeeCode == log.EmployeeCode && e.Date == log.Date))
                        .ToList();

                    if (newEntries.Any())
                    {
                        await _ctx.EmployeeWorkLogs.AddRangeAsync(newEntries);
                        await _ctx.SaveChangesAsync();
                    }
                }
                else
                {
                    // اگر دیتابیس خالی است، تمام داده‌ها را اضافه می‌کنیم
                    await _ctx.EmployeeWorkLogs.AddRangeAsync(employeeWorkLogs);
                    await _ctx.SaveChangesAsync();
                }
            }


            public void Delete(int Id)
            {
                var item = Get(Id);
                if (item != null)
                {
                    item.IsDeleted = true;
                    Update(item);
                    SaveChanges(); // ذخیره تغییرات
                }
            }

            public EmployeeWorkLog Get(int Id)
            {
                return _ctx.EmployeeWorkLogs.FirstOrDefault(x => x.Id == Id);
            }

            public IEnumerable<EmployeeWorkLog> GetAll(Expression<Func<EmployeeWorkLog, bool>> where = null)
            {
                IQueryable<EmployeeWorkLog> query = _ctx.EmployeeWorkLogs;

                if (where != null)
                    query = query.Where(where);

                return query.ToList();
            }

            public void Insert(EmployeeWorkLog entity)
            {
                _ctx.Add(entity);
                SaveChanges();
            }

            public bool IsExist(int Id)
            {
                return _ctx.EmployeeWorkLogs.Any(x => x.Id == Id);
            }

            public void SaveChanges()
            {
                _ctx.SaveChanges();
            }

            public void Update(EmployeeWorkLog entity)
            {
                _ctx.Update(entity);
                SaveChanges();
            }
        }
    }

}
