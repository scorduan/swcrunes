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
            SlotList = new List<RuneSlot>();
            SlotList.Add(RuneSlot.ONE);
            SlotList.Add(RuneSlot.TWO);
            SlotList.Add(RuneSlot.THREE);
            SlotList.Add(RuneSlot.FOUR);
            SlotList.Add(RuneSlot.FIVE);
            SlotList.Add(RuneSlot.SIX);

            TypeList = new List<RuneType>();
            TypeList.Add(RuneType.Energy);
            TypeList.Add(RuneType.Guard);
            TypeList.Add(RuneType.Blade);
            TypeList.Add(RuneType.Rage);
            TypeList.Add(RuneType.Fatal);
            TypeList.Add(RuneType.Swift);
            TypeList.Add(RuneType.Focus);
            TypeList.Add(RuneType.Endure);
            TypeList.Add(RuneType.Foresight);
            TypeList.Add(RuneType.Assemble);

            NewSlot = RuneSlot.ONE;
            NewType = RuneType.Energy;
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

        public RuneSlot NewSlot { get; set; }

        public RuneType NewType { get; set; }

        public List<RuneSlot> SlotList { get; set; }
        public List<RuneType> TypeList { get; set; }


        public void SaveNewRune()
        {
            Rune rune = new Rune("");

            rune.Slot = NewSlot;
            rune.Type = NewType;

            rune.ATKP = NewATKP;
            NewATKP = 0;
            rune.ATKF = NewATKF;
            NewATKF = 0;

            rune.DEFP = NewDEFP;
            NewDEFP = 0;
            rune.DEFF = NewDEFF;
            NewDEFF = 0;

            rune.HPP = NewHPP;
            NewHPP = 0;
            rune.HPF = NewHPF;
            NewHPF = 0;

            rune.SPD = NewSPD;
            NewSPD = 0;

            rune.CR = NewCR;
            NewCR = 0;
            rune.CD = NewCD;
            NewCD = 0;

            rune.ACC = NewACC;
            NewACC = 0;
            rune.RES = NewRES;
            NewRES = 0;
            
            rune.PR = NewPR;
            NewPR = 0;
            rune.EV = NewEV;
            NewEV = 0;

            _runes.Add(rune);
            _storageServ.SaveRunes(_runes);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewATKP"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewATKF"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewDEFP"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewDEFF"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewHPP"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewHPF"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewSPD"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewCR"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewCD"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewACC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewRES"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewPR"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewEV"));


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

        // Bindable Properties
        public ObservableCollection<IRune> VisibleRunes;

        public RuneType SelectedType = RuneType.Energy;

        public RuneSlot SelectedSlot = RuneSlot.ONE;

        public IRune NewRune { get; set; }

        // Service updaters methods

        SimulationService _simulationService;

        public void UpdateList()
        {
            List<IRune> runeList = _simulationService.GetRunesByTypeSlot(SelectedType, SelectedSlot);
            
            VisibleRunes = new ObservableCollection<IRune>(runeList);
        }

        public void AddNewRune()
        {
            NewRune = _simulationService.GetNewRune();
        }

        public void SaveUpdatedRune(IRune rune)
        {
            _simulationService.UpdateRune(rune);
        }

        public void AddNewRuneToList()
        {
            _simulationService.UpdateRune(NewRune);
            UpdateList();
            _simulationService.SaveState();
        }

        public void DeleteRune(IRune rune)
        {
            _simulationService.DeleteRune(rune.Id);
            List<IRune> runeList = _simulationService.GetRunesByTypeSlot(SelectedType, SelectedSlot);
        }
    
    }
}

