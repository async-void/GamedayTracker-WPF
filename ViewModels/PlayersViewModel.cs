using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using GamedayTracker.Commands;
using GamedayTracker.Factories;
using GamedayTracker.Interfaces;
using GamedayTracker.Models;

namespace GamedayTracker.ViewModels
{
    public class PlayersViewModel: ViewModelBase
    {
        private readonly INavigator? _navigator;
        private readonly AppDbContextFactory? _dbFactory;

        public ViewModelBase? SelectedViewModel => _navigator!.CurrentViewModel;
        public ICommand? NavigateAddNewPlayerCommand { get; }

        private ObservableCollection<Player>? _players;
        public ObservableCollection<Player>? Players
        {
            get => _players;
            set => OnPropertyChanged(ref _players, value);
        }

        /// <inheritdoc />
        public PlayersViewModel(INavigator navigator, AppDbContextFactory dbFactory)
        {
            _navigator = navigator;
            _dbFactory = dbFactory;
            _navigator!.CurrentViewModelChanged += OnSelectedViewModelChanged;
            NavigateAddNewPlayerCommand = new NavigateCommand<NewPlayerViewModel>(_navigator, () => new NewPlayerViewModel(_navigator, _dbFactory));
            _players = [];
            LoadPlayers();
        }

        private void OnSelectedViewModelChanged()
        {
            OnPropertyChanged(nameof(SelectedViewModel));
        }

        private void LoadPlayers()
        {
            for (int i = 0; i < 10; i++)
            {
                var player = new Player
                {
                    Name = "Test " + i,
                    Company = "Company " + i
                };
                _players.Add(player);
            }
        }
    }
}
