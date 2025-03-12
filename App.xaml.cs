using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GamedayTracker.ViewModels;
using System.Windows;
using GamedayTracker.Factories;
using GamedayTracker.Interfaces;
using GamedayTracker.Navigation;
using GamedayTracker.Services;

namespace GamedayTracker
{
    /// <summary>
    /// This is created by the template
    /// make changes as needed
    /// Author: Async(void)
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<AppViewModel>();
                services.AddSingleton<INavigator, Navigator>();
                services.AddScoped<AppDbContextFactory>();
                services.AddSingleton<IDataProvider, DataServiceProvider>();
                services.AddSingleton<MainWindow>(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<AppViewModel>()
                });

            }).Build();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
