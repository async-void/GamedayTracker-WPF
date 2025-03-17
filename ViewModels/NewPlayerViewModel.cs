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
    public class NewPlayerViewModel: ViewModelBase
    {
        private readonly INavigator? _navigator;
        private readonly AppDbContextFactory? _dbFactory;
        public ViewModelBase? SelectedViewModel => _navigator!.CurrentViewModel;

        public ICommand? NavigateBackCommand { get; }
        public ICommand? SavePlayerCommand { get; }
        public ICommand? CancelCommand { get; }
        public NewPlayerViewModel(INavigator? navigator, AppDbContextFactory dbFactory)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            _navigator!.CurrentViewModelChanged += OnSelectedViewModelChanged;
            NavigateBackCommand = new NavigateCommand<PlayersViewModel>(_navigator, () => new PlayersViewModel(_navigator, _dbFactory));
            SavePlayerCommand = new RelayCommand(SavePlayer);
            CancelCommand = new RelayCommand(CancelAddNewPlayer);
        }

        private void CancelAddNewPlayer()
        {
            throw new NotImplementedException();
        }

        private void SavePlayer()
        {
            throw new NotImplementedException();
        }

        private void OnSelectedViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
