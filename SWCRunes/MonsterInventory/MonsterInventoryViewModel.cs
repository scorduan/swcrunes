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

        public String NewName { get; set; }

        public int NewATK { get; set; }
        public int NewATKB { get; set; }

        public int NewDEF { get; set; }
        public int NewDEFB { get; set; }

        public int NewHP { get; set; }
        public int NewHPB { get; set; }

        public int NewSPD { get; set; }
        public int NewSPDB { get; set; }


        public int NewCR { get; set; }
        public int NewCRB { get; set; }
        public int NewCD { get; set; }
        public int NewCDB { get; set; }

        public int NewACC { get; set; }
        public int NewACCB { get; set; }
        public int NewRES { get; set; }
        public int NewRESB { get; set; }

        public int NewPR { get; set; }
        public int NewPRB { get; set; }
        public int NewEV { get; set; }
        public int NewEVB { get; set; }


        public void SaveNewMonster()
        {
            Monster monster = new Monster();

            monster.Name = NewName;

            monster.ATK = NewATK;
            monster.ATKBoost = NewATKB;

            monster.DEF = NewDEF;
            monster.DEFBoost = NewDEFB;

            monster.HP = NewHP;
            monster.HPBoost = NewHPB;

            monster.SPD = NewSPD;
            

            monster.CR = NewCR;
            
            monster.CD = NewCD;


            monster.ACC = NewACC;
            monster.RES = NewRES;
            monster.RESBoost = NewRESB;

            monster.PR = NewPR;
            monster.EV = NewEV;
            monster.EVBoost = NewEVB;

            _monsters.Add(monster);
            _storageServ.SaveMonsters(_monsters);
            
        }

        public void SaveUpdatedMonster()
        {
            _storageServ.SaveMonsters(_monsters);
        }

        public void RemoveMonster(Monster r)
        {
            _monsters.Remove(r);
            _storageServ.SaveMonsters(_monsters);
        }
    
    }
}

