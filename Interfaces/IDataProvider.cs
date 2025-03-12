using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamedayTracker.Models;
using GamedayTracker.Services;

namespace GamedayTracker.Interfaces
{
    public interface IDataProvider
    {
        Result<string, SystemError<DataServiceProvider>> GetConnectionString();
    }
}
