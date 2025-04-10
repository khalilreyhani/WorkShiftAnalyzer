using Application.Interfaces;
using Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WorkShiftServices: IWorkShiftServices
    {
        private readonly DBContext _ctx;
        public WorkShiftServices( DBContext ctx)
        {
            _ctx = ctx;
        }
    }
}
