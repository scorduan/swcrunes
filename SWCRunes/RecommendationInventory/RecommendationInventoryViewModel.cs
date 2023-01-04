using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SWCRunesLib;

namespace SWCRunes
{
    public class RecommendationInventoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        public RecommendationInventoryViewModel(SimulationService simulation)
        {
            _simulationService = simulation;
            RequestList = simulation.GetAllRequests();
            loadFromService();
        }


        public ObservableCollection<IRequest> RequestList;

        private SimulationService _simulationService;

        public ObservableCollection<IRecommendedMonster> Monsters { get; set; }

        public IRequest SelectedRequest { get; set; }


        public RecommendedMonster SelectedMonster { get; set; }


        public void ChangeSelectedRequest()
        {
            loadFromService();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
        }

        public void ChangeSelectedMonster(RecommendedMonster monster)
        {
            SelectedMonster = monster;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
        }

        private void loadFromService()
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
            

            List<IRecommendedMonster> recommendedMonsters= _simulationService.GetRecommendationPageForMonster(SelectedRequest.MonsterId, 1, 10, out int pages);
            Monsters = new ObservableCollection<IRecommendedMonster>(recommendedMonsters);
           
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
        }

       

        internal void EquipSelectedSet()
        {
            _simulationService.EquipIRuneSet(SelectedMonster.Original.Id, SelectedMonster.Updated.Runes);
        }
    }
}

