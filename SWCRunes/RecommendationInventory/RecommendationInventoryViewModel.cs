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
        }


        public ObservableCollection<IRequest> RequestList { get; set; }

        private SimulationService _simulationService;

        public ObservableCollection<IRecommendedMonster> Monsters { get; set; }

        public IRequest SelectedRequest { get; set; }


        public IRecommendedMonster SelectedMonster { get; set; }

        public bool RequestHasRecommendation { get => _simulationService.RequestHasRecommendations(SelectedRequest); }
        public int RequestRecommendationCount
        {
            get
            {

                //int retVal = _simulationService.RecommendationCount(SelectedRequest);
                return 0;
            }
        }


        public void ChangeSelectedRequest()
        {
            loadFromService();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
                
        }

        public void ChangeSelectedMonster(IRecommendedMonster monster)
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));

        }

        internal void RefreshCounts()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster.Original"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster.Updated"));
        }
    }
}

