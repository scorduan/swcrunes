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


        public ObservableCollection<Request> RequestList { get; set; }

        private SimulationService _simulationService;

        public ObservableCollection<RecommendedMonster> Monsters { get; set; }

        public Request SelectedRequest { get; set; }


        public RecommendedMonster SelectedMonster { get; set; }

        public bool RequestHasRecommendation { get => _simulationService.RequestHasRecommendations(SelectedRequest); }
        public int RequestRecommendationCount
        {
            get
            {
                try
                {
                    int retVal = _simulationService.RecommendationCount(SelectedRequest);
                }
                catch (Exception e)
                {

                }
                return 0;
            }
        }


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
            

            List<RecommendedMonster> recommendedMonsters= _simulationService.GetRecommendationPageForMonster(SelectedRequest.MonsterId, 1, 10, out int pages);
            Monsters = new ObservableCollection<RecommendedMonster>(recommendedMonsters);
           
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
        }

       

        internal void EquipSelectedSet()
        {
            _simulationService.EquipRuneSet(SelectedMonster.Original.Id, SelectedMonster.Updated.Runes);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));

        }

        internal void RefreshCounts()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster.Original"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster.Updated"));
        }
    }
}

