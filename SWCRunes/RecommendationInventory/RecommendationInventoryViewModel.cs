using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SWCRunesLib;

namespace SWCRunes
{
    public class RecommendationInventoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        public RecommendationInventoryViewModel(OptimizationService optim, StorageService storage)
        {

            _optService = optim;
            _optService.OptimizationCompletedEvent += _optService_OptimizationCompletedEvent;

            Monsters = new ObservableCollection<Monster>();
            loadFromService();
        }




        private void _optService_OptimizationCompletedEvent(object sender, Recommendation recommendation)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Recomm"));
            loadFromService();
        }

        private OptimizationService _optService;

        public ObservableCollection<Monster> Monsters { get; set; }

        public Recommendation Recomm
        {
            get
            {
                return _optService.Recommended;
            }
        }

        public Monster SelectedMonster { get; set; }

        public void ChangeSelectedMonster(Monster monster)
        {
            SelectedMonster = monster;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
        }

        private void loadFromService()
        {
            Monsters.Clear();

            if (_optService.Recommended != null)
            {
                foreach (Monster m in _optService.Recommended.RecommendedSetup)
                {
                    Monsters.Add(m);
                }
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
        }
    }
}

