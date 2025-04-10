


using Domain.Interfaces;
using Data.Repository;
using Domain.Models.EmployeeWork;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;
using Data.Repository.Data.Repository;


namespace DependencyContainer
{
    public static class DependencyContainer
    {
        public static void ConfigureDependencies(this IServiceCollection service)
        {
            service.AddScoped<IEmployeeWorkLogRepository, EmployeeWorkLogRepository>();
            service.AddScoped<IShiftRepository, ShiftRepository>();


            //Services

            service.AddScoped<IWorkShiftServices, WorkShiftServices>();


        }
    }


}
