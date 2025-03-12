using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GamedayTracker.Enums;
using GamedayTracker.Interfaces;
using GamedayTracker.Models;

namespace GamedayTracker.Services
{
    public class DataServiceProvider : IDataProvider
    {
        public Result<string, SystemError<DataServiceProvider>> GetConnectionString()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Json", "config.json");
            var json = File.ReadAllText(path);
            var conStr = JsonSerializer.Deserialize<ConfigJson>(json);

            if (conStr == null)
            { 
                return Result<string, SystemError<DataServiceProvider>>.Ok(conStr!.ConnectionString!);
            }

            return Result<string, SystemError<DataServiceProvider>>.Err(new SystemError<DataServiceProvider>
            {
                ErrorMessage = "Error reading config.json",
                ErrorType = ErrorType.INFORMATION,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = this
            });
        }
    }
}
