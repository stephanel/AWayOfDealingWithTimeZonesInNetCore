using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealingWithTimezonesInMvcCore.Services
{
    public class TimeService : ITimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
