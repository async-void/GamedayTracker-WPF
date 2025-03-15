using Microsoft.EntityFrameworkCore.Design;
using GamedayTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamedayTracker.Interfaces;
using GamedayTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace GamedayTracker.Factories
{
    public class AppDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        private readonly IDataProvider _dataProvider = new DataServiceProvider();
        public AppDbContext CreateDbContext(string[]? args = null)
        {
            var conStr = _dataProvider.GetConnectionString();
            var options = new DbContextOptionsBuilder();
            options.UseNpgsql(conStr.Value);
            return new AppDbContext(options.Options);
        }

    }
}
