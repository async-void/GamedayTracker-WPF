using GamedayTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamedayTracker.Factories;

namespace GamedayTracker.ViewModels
{
    public class NewPlayerViewModel: ViewModelBase
    {
        private readonly INavigator? _navigator;
        private readonly AppDbContextFactory? _dbFactory;
        public ViewModelBase? SelectedViewModel => _navigator!.CurrentViewModel;

        public NewPlayerViewModel(INavigator? navigator, AppDbContextFactory dbFactory)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            _navigator!.CurrentViewModelChanged += OnSelectedViewModelChanged;
        }

        private void OnSelectedViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
