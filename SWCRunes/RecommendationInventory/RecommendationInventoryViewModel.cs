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

            Monsters = new ObservableCollection<RecommendedMonster>();
            loadFromService();
        }




        private void _optService_OptimizationCompletedEvent(object sender, Recommendation recommendation)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Recomm"));
            loadFromService();
        }

        private OptimizationService _optService;

        public ObservableCollection<RecommendedMonster> Monsters { get; set; }

        public Recommendation Recomm
        {
            get
            {
                return _optService.Recommended;
            }
        }

        public RecommendedMonster SelectedMonster { get; set; }

        public void ChangeSelectedMonster(RecommendedMonster monster)
        {
            SelectedMonster = monster;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
        }

        private void loadFromService()
        {
            //Monsters = null;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
            //Monsters = new ObservableCollection<Monster>();
            
            
            if (_optService.Recommended != null)
            {
                Monsters.Clear();
                currentIndex = 0;
                AddAdditional();

            }
            

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Recomm"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
        }

        int currentIndex = 0;
        public void AddAdditional()
        {
            int maxIndex = currentIndex + 20;
            if (maxIndex>_optService.Recommended.RecommendedSetup.Count)
            {
                maxIndex = _optService.Recommended.RecommendedSetup.Count;
            }

            for (int counter = currentIndex; counter < maxIndex; counter++)
            {
                Monsters.Add(_optService.Recommended.RecommendedSetup[counter]);
            }

            currentIndex = maxIndex;
        }

        internal void EquipSelectedSet()
        {
            SelectedMonster.OriginalMonster.EquipSet(SelectedMonster.Runes);
        }
    }
}

