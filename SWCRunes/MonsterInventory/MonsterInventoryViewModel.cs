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
        public MonsterInventoryViewModel(SimulationService simService)
        {

            
            _simulationService = simService;
            VisibleMonsters = _simulationService.GetAllMonsters();
            NewMonster = _simulationService.GetNewMonster();
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;



        public Monster SelectedMonster { get; set; }



        internal void ChangeSelectedMonster(Monster selectedItem)
        {
            SelectedMonster = selectedItem;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
        }

        // Binding Properties

        public ObservableCollection<IMonster> VisibleMonsters { get; private set; }

        public IMonster NewMonster { get; set; }

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
            _simulationService.DeleteMonster(SelectedMonster.Id);
        }

        internal void UnequipSelected()
        {
            _simulationService.UnequipAllMonster(SelectedMonster);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
        }
    }
}

