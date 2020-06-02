using System;

namespace DealingWithTimezonesInMvcCore.Services
{
    public interface ITimeService
    {
        DateTime Now{ get; }
    }
}
