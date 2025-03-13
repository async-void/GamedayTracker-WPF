using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamedayTracker.Factories;
using GamedayTracker.Interfaces;

namespace GamedayTracker.ViewModels
{
    public class PlayersViewModel(INavigator navigator, AppDbContextFactory dbFactory): ViewModelBase
    {
        private readonly INavigator? _navigator = navigator;
        private readonly AppDbContextFactory? _dbFactory = dbFactory;

    }
}
