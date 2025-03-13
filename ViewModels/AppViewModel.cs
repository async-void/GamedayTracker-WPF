using GamedayTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GamedayTracker.Commands;
using GamedayTracker.Factories;

namespace GamedayTracker.ViewModels
{
    /// <summary>
    /// Created by the template
    /// make changes as needed
    /// </summary>
    public class AppViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        private readonly AppDbContextFactory? _dbFactory;
        public ViewModelBase? SelectedViewModel => _navigator!.CurrentViewModel;
        public ICommand? NavigateNewPlayerViewCommand { get; }
        public ICommand? NavigatePlayersViewCommand { get; }
        public ICommand? NavigateHomeCommand { get; }

        public AppViewModel(INavigator navigator, AppDbContextFactory dbFactory)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            _navigator!.CurrentViewModelChanged += OnSelectedViewModelChanged;
            NavigateNewPlayerViewCommand = new NavigateCommand<NewPlayerViewModel>(_navigator, () => new NewPlayerViewModel(_navigator));
            NavigatePlayersViewCommand = new NavigateCommand<PlayersViewModel>(_navigator, () => new PlayersViewModel(_navigator, _dbFactory));
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(_navigator, () => new HomeViewModel(_navigator));
        }

        private void OnSelectedViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
