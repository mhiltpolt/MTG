using MTG.CardMoth.ApiCaller.APIs.Scryfall;
using MTG.CardMoth.DataStorage.Models;
using MTG.CardMoth.WpfUi.Commands;
using MTG.CardMoth.WpfUi.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MTG.CardMoth.WpfUi.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ScryfallController _controller { get; set; }

        private ObservableCollection<SetEntity> _sets;
        public ObservableCollection<SetEntity> Sets
        {
            get { return _sets; }
            set
            {
                _sets = value;
                OnPropertyChanged(nameof(Sets));
            }
        }

        private ObservableCollection<CardEntity> _cards;
        public ObservableCollection<CardEntity> Cards
        {
            get { return _cards; }
            set 
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }

        private SetEntity _currentSet;
        public SetEntity CurrentSet
        {
            get { return _currentSet; }
            set 
            { 
                _currentSet = value;
                OnPropertyChanged(nameof(CurrentSet));
            }
        }

        private CardEntity _currentCard;
        public CardEntity CurrentCard
        {
            get { return _currentCard; }
            set
            {
                _currentCard = value;
                OnPropertyChanged(nameof(CurrentCard));
            }
        }

        public RelayCommand LoadSetsCommand { get; private set; }
        public RelayCommand LoadCardsCommand { get; private set; }

        public MainViewModel() : base()
        {
            _controller = new ScryfallController();
            LoadSetsCommand = new RelayCommand(LoadSets, CanLoadSets);
            LoadCardsCommand = new RelayCommand(LoadCards, CanLoadCards);
        }

        private async Task LoadSets(object obj)
        {
            Sets = new ObservableCollection<SetEntity>(await _controller.GetAllSets());
        }

        private bool CanLoadSets(object obj)
        {
            return Sets == null;
        }

        private async Task LoadCards(object obj)
        {
            CurrentSet.Cards = await _controller.GetCardsFromSet(CurrentSet);
            Cards = new ObservableCollection<CardEntity>(CurrentSet.Cards);
        }

        private bool CanLoadCards(object obj)
        {
            return CurrentSet != null;
        }
    }
}
