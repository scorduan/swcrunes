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
        public MonsterInventoryViewModel(StorageService storageServ, SimulationService simService)
        {
          
            _storageServ = storageServ;
            _monsters = storageServ.GetMonsters();
            _simulationService = simService;
        }
        
        private ObservableCollection<Monster> _monsters;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Monster> Monsters
        {
            get
            {
                return _monsters;
            }

           
        }

        private StorageService _storageServ;

        public Monster SelectedMonster { get; set; }


        public void SaveNewMonster()
        {
            Monster monster = new Monster();
            _storageServ.SaveMonsters(_monsters);
            
        }

        public void SaveUpdatedMonster()
        {
            _storageServ.SaveMonsters(_monsters);
        }

        public void RemoveSelected()
        {
            _monsters.Remove(SelectedMonster);
            SelectedMonster = null;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));

        }

        public void AddNew()
        {
            _monsters.Add(new Monster());
        }

        internal void ChangeSelectedMonster(Monster selectedItem)
        {
            SelectedMonster = selectedItem;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonster"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monsters"));
        }

        // Binding Properties

        public ObservableCollection<IMonster> VisibleMonsters;

        public IMonster NewMonster { get; set; }

        private SimulationService _simulationService;

        // Simulation Updaters 


        public void UpdateList()
        {
            List<IMonster> runeList = _simulationService.GetAllMonsters();

            VisibleMonsters = new ObservableCollection<IMonster>(runeList);
        }

        public void AddNewMonster()
        {
            NewMonster = _simulationService.GetNewMonster();
        }

        public void SaveUpdatedRune(IMonster monster)
        {
            _simulationService.UpdateMonster(monster);
        }

        public void AddNewRuneToList()
        {
            _simulationService.UpdateMonster(NewMonster);
            UpdateList();
            _simulationService.SaveState();
        }

        public void DeleteRune(IMonster monster)
        {
            _simulationService.DeleteRune(monster.Id);
            UpdateList();
        }
    }
}

