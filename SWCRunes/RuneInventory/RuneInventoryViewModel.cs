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
        public RuneInventoryViewModel(SimulationService simulationService)
        {
            _simulationService = simulationService;

            VisibleRunes = _simulationService.GetRunes();
            NewRune = _simulationService.GetNewRune();

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

        }


        public event PropertyChangedEventHandler PropertyChanged;

        


        public List<RuneSlot> SlotList { get; set; }
        public List<RuneType> TypeList { get; set; }



        public void SaveNewRune()
        {
         

            SaveUpdatedRune(NewRune);
            NewRune = _simulationService.GetNewRune();
            NewRune.Slot = SelectedSlot;
            NewRune.Type = SelectedType;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewRune"));

        }


        // Bindable Properties
        public ObservableCollection<Rune> VisibleRunes { get; private set; }

        public RuneType SelectedType { get; set; } = RuneType.Energy;

        public RuneSlot SelectedSlot { get; set; } = RuneSlot.ONE;

        public Rune NewRune { get; set; }

        // Service updaters methods

        SimulationService _simulationService;

        public void UpdateList()
        {
            NewRune.Type = SelectedType;
            NewRune.Slot = SelectedSlot;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewRune"));
            _simulationService.UpdateRuneList(SelectedType, SelectedSlot);
        }


        public void SaveUpdatedRune(Rune rune)
        {
            _simulationService.UpdateRune(rune);
        }

        public void AddNewRuneToList()
        {
            _simulationService.UpdateRune(NewRune);
            UpdateList();
        }

        public void DeleteRune(Rune rune)
        {
            _simulationService.DeleteRune(rune);
            UpdateList();
        }
    
    }
}

