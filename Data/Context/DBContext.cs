

using Domain.Models.EmployeeWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }


        #region EmployeeWork


        public DbSet<EmployeeWorkLog> employeeWorkLogs { get; set; }
        public DbSet<Shift> Shifts { get; set; }
       



        #endregion

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeWorkLog>()
                .HasQueryFilter(u => !u.IsDeleted);
              
               modelBuilder.Entity<Shift>()
                .HasQueryFilter(u => !u.IsDeleted);
              
            
     

            base.OnModelCreating(modelBuilder);
        }
     

    }

   
}
