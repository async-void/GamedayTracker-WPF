using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GamedayTracker.Interfaces;

namespace GamedayTracker.ViewModels
{
    public class HomeViewModel(INavigator navigator): ViewModelBase
    {
        private readonly INavigator? _navigator = navigator;
        
    }
}
