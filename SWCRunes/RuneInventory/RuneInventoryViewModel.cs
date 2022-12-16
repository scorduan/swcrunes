using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SWCRunesLib;
using Microsoft.Maui.Controls.Compatibility;
using System.Reflection;

namespace SWCRunes
{
    public class RuneInventoryViewModel : INotifyPropertyChanged
    {
        public RuneInventoryViewModel(StorageService storageServ)
        {
            SlotList = new List<Rune.RuneSlot>();
            SlotList.Add(Rune.RuneSlot.ONE);
            SlotList.Add(Rune.RuneSlot.TWO);
            SlotList.Add(Rune.RuneSlot.THREE);
            SlotList.Add(Rune.RuneSlot.FOUR);
            SlotList.Add(Rune.RuneSlot.FIVE);
            SlotList.Add(Rune.RuneSlot.SIX);

            TypeList = new List<Rune.RuneType>();
            TypeList.Add(Rune.RuneType.Energy);
            TypeList.Add(Rune.RuneType.Guard);
            TypeList.Add(Rune.RuneType.Blade);
            TypeList.Add(Rune.RuneType.Rage);
            TypeList.Add(Rune.RuneType.Fatal);
            TypeList.Add(Rune.RuneType.Swift);
            TypeList.Add(Rune.RuneType.Focus);
            TypeList.Add(Rune.RuneType.Endure);
            TypeList.Add(Rune.RuneType.Foresight);
            TypeList.Add(Rune.RuneType.Assemble);

            NewSlot = Rune.RuneSlot.ONE;
            NewType = Rune.RuneType.Energy;
            _storageServ = storageServ;
            _runes = storageServ.GetRunes() ;
        }
        
        private ObservableCollection<Rune> _runes;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Rune> Runes
        {
            get
            {
                return _runes;
            }

            //ToDO Handle Conversion of percs
        }

        StorageService _storageServ;

        public int NewATKP { get; set; }
        public int NewATKF { get; set; }

        public int NewDEFP { get; set; }
        public int NewDEFF { get; set; }

        public int NewHPP { get; set; }
        public int NewHPF { get; set; }

        public int NewSPD { get; set; }

        public int NewCR { get; set; }
        public int NewCD { get; set; }

        public int NewACC { get; set; }
        public int NewRES { get; set; }

        public int NewPR { get; set; }
        public int NewEV { get; set; }

        public Rune.RuneSlot NewSlot { get; set; }

        public Rune.RuneType NewType { get; set; }

        public List<Rune.RuneSlot> SlotList { get; set; }
        public List<Rune.RuneType> TypeList { get; set; }


        public void SaveNewRune()
        {
            Rune rune = new Rune();

            rune.Slot = NewSlot;
            rune.Type = NewType;

            rune.ATKP = NewATKP;
            rune.ATKF = NewATKF;

            rune.DEFP = NewDEFP;
            rune.DEFF = NewDEFF;

            rune.HPP = NewHPP;
            rune.HPF = NewHPF;

            rune.SPD = NewSPD;

            rune.CR = NewCR;
            rune.CD = NewCD;

            rune.ACC = NewACC;
            rune.RES = NewRES;

            rune.PR = NewPR;
            rune.EV = NewEV;

            _runes.Add(rune);
            _storageServ.SaveRunes(_runes);
            
        }

        public void SaveUpdatedRune()
        {
            _storageServ.SaveRunes(_runes);
        }

        public void RemoveRune(Rune r)
        {
            _runes.Remove(r);
            _storageServ.SaveRunes(_runes);
        }
    
    }
}

