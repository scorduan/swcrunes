using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SWCRunesLib;
using Microsoft.Maui.Controls.Compatibility;
using System.Reflection;


namespace SWCRunes
{
    public class RequestInventoryViewModel : INotifyPropertyChanged
    {
        public RequestInventoryViewModel(SimulationService simulationService)
        {

            _simulationService = simulationService;
            VisibleRequests = _simulationService.GetAllRequests();
            VisibleMonsters = _simulationService.GetAllMonsters();
            NewRequest = _simulationService.GetNewRequest();
            
            AttributeList = new ObservableCollection<string>();
            AttributeList.Add("ATK");
            AttributeList.Add("DEF");
            AttributeList.Add("HP");
            AttributeList.Add("SPD");
            AttributeList.Add("CR");
            AttributeList.Add("CD");
            AttributeList.Add("ACC");
            AttributeList.Add("RES");
            AttributeList.Add("PR");
            AttributeList.Add("EV");
            AttributeList.Add("EffectiveHP");
            AttributeList.Add("Survival");
            AttributeList.Add("Damage");
            AttributeList.Add("BasicDamage");

            StatList.Add("ATKP");
            StatList.Add("ATKF");

            StatList.Add("DEFP");
            StatList.Add("DEFF");

            StatList.Add("HPP");
            StatList.Add("HPF");

            StatList.Add("SPD");

            StatList.Add("CR");
            StatList.Add("CD");

            StatList.Add("ACC");
            StatList.Add("RES");

            StatList.Add("PR");
            StatList.Add("EV");

            TypeList.Add(RuneType.Null);

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



        public Request SelectedRequest { get; set; }

        public ObservableCollection<String> AttributeList { get; set; }

        public ObservableCollection<String> StatList { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<RuneType> TypeList { get; set; } = new ObservableCollection<RuneType>();

        public ObservableCollection<Object> SelectedStats { get; set; } = new ObservableCollection<Object>();
        public ObservableCollection<Object> NewSelectedStats { get; set; } = new ObservableCollection<Object>();

        public ObservableCollection<IMonster> VisibleMonsters { get; set; }

        public IMonster NewSelectedMonster { get; set; }

        public string SelectedMonsterName
        {
            get
            {
                string name = "";
                if ((SelectedRequest !=null)&&(SelectedRequest.MonsterId!=""))
                {
                    name= _simulationService.GetMonsterNameForId(SelectedRequest.MonsterId);
                }
                return name;
            }
        }

        internal void ProcessCurrent()
        {
            _simulationService.Optimize(SelectedRequest);
            DateTime time = DateTime.Now;

        }

        internal void UpdateSelectedStats(IReadOnlyList<object> currentSelection)
        {
            if (SelectedRequest != null)
            {
                SelectedRequest.FocusStats.Clear();
                foreach (string stat in currentSelection)
                {
                    SelectedRequest.FocusStats.Add(stat);
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RequestCount"));
        }

        internal void UpdateNewSelectedStats(IReadOnlyList<object> currentSelection)
        {
            NewRequest.FocusStats.Clear();
            foreach (string stat in currentSelection)
            {
                NewRequest.FocusStats.Add(stat);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewRequestCount"));
        }

        internal void GeneralSelectedIndexChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RequestCount"));
        }

        internal void NewGeneralSelectedIndexChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewRequestCount"));
        }

       

        public long RequestCount
        {
            get
            {
                long count = 0;
                if (SelectedRequest !=null)
                {
                    count=_simulationService.CalcPerms(SelectedRequest);
                }
                return count;
            }
        }

        public long NewRequestCount
        {
            get
            {
                return _simulationService.CalcPerms(NewRequest);
            }
        }

        // Binding Properties

        public ObservableCollection<IRequest> VisibleRequests { get; private set; }

        public IRequest NewRequest { get; set; }

        private SimulationService _simulationService;

        // Simulation Updaters 

        public SimulationService Service { get => _simulationService; }
        public void RemoveSelected()
        {
            DeleteRequest(SelectedRequest);
        }

        public void SaveSelectedRequest()
        {
            SaveUpdatedRequest(SelectedRequest);
        }

        public void SaveUpdatedRequest(IRequest request)
        {
            _simulationService.UpdateRequest(request);
        }

        public void AddNewRequestToList()
        {
            _simulationService.UpdateRequest(NewRequest);
            NewRequest = _simulationService.GetNewRequest();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewRequest"));
        }

        public void DeleteRequest(IRequest request)
        {
            _simulationService.DeleteRequest(request.Id);
        }

        internal void SelectedRequestChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedMonsterName"));
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedRequest"));
        }

        internal void UpdateNewRequestMonster()
        {
            NewRequest.MonsterId = NewSelectedMonster.Id;
            NewRequest.MonsterName = _simulationService.GetMonsterNameForId(NewRequest.MonsterId);
        }
    }
}

