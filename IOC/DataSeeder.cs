using Context;
using Domain.Models.EmployeeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public class DataSeeder
    {
        public static void SeedShiftTypes(DBContext context)
        {
            // بررسی اینکه آیا شیفتی در دیتابیس وجود دارد یا نه
            if (!context.Shifts.Any())
            {
                var shifts = new[]
                {
                new Shift { ShiftName = "A", StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("18:00:00"), BreakDuration = TimeSpan.Parse("01:30:00") },
                new Shift { ShiftName = "B", StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("17:00:00"), BreakDuration = TimeSpan.Parse("01:30:00") },
                new Shift { ShiftName = "C", StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("19:00:00"), BreakDuration = TimeSpan.Parse("01:30:00") }
            };

                context.Shifts.AddRange(shifts);
                context.SaveChanges();
            }
        }
    }
}
