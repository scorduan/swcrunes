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
        public MonsterInventoryViewModel(StorageService storageServ)
        {
          
            _storageServ = storageServ;
            _monsters = storageServ.GetMonsters() ;
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

        StorageService _storageServ;

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
    }
}

