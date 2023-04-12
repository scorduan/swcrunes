using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SWCRunesLib;
using Microsoft.Maui.Controls.Compatibility;
using System.Reflection;

namespace SWCRunes
{
    public class MonsterInventoryViewModel : INotifyPropertyChanged
    {
        public MonsterInventoryViewModel(SimulationService simService, RequestInventoryViewModel requestInventoryViewModel)
        {

            
            _simulationService = simService;
            _requestInventoryViewModel = requestInventoryViewModel;
            VisibleMonsters = _simulationService.GetAllMonsters();
            NewMonster = _simulationService.GetNewMonster();
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;

        private RequestInventoryViewModel _requestInventoryViewModel;

        private Monster _selectedMonster;
        public Monster SelectedMonster
        {
            get => _selectedMonster;
            set
            {
                _selectedMonster = value;
                //_requestInventoryViewModel.SelectedRequest = _selectedMonster.Request;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
            }
        }

        // Binding Properties

        public ObservableCollection<Monster> VisibleMonsters { get; private set; }

        public Monster NewMonster { get; set; }

        private SimulationService _simulationService;

        // Simulation Updaters 


        public void AddNewMonster()
        {
            _simulationService.UpdateMonster(NewMonster);
            NewMonster = _simulationService.GetNewMonster();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewMonster"));
        }

        public void SaveSelected()
        {
            _simulationService.UpdateMonster(SelectedMonster);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
        }

        public void AddNewMonstersToList()
        {
            _simulationService.UpdateMonster(NewMonster);
            
            
        }

        public void RemoveSelected()
        {
            _simulationService.DeleteMonster(SelectedMonster);
        }

        internal void UnequipSelected()
        {
            _simulationService.UnequipAllMonster(SelectedMonster);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
        }

        internal void SelectNewMonster()
        {
            SelectedMonster = _simulationService.GetNewMonster();
            
        }
    }
}

