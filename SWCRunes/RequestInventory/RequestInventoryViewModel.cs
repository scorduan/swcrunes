using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SWCRunesLib;
using SWCRunes.Model;
using System.Collections.Generic;
using Microsoft.Maui.Controls.Compatibility;
using System.Reflection;


namespace SWCRunes
{
    public class RequestInventoryViewModel : INotifyPropertyChanged
    {
        public RequestInventoryViewModel(SimulationService simulationService, RecommendationInventoryViewModel recommendationInventoryViewModel)
        {

            _simulationService = simulationService;
            _recommendationInventoryViewModel = recommendationInventoryViewModel;
            VisibleRequests = _simulationService.GetAllRequests();
            VisibleMonsters = _simulationService.GetAllMonsters();
            

            AttributeList = new ObservableCollection<Stat>(Enum.GetValues(typeof(Stat)).Cast<Stat>().ToList());
;

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

        private RecommendationInventoryViewModel _recommendationInventoryViewModel;

        private ObservableRequest _selectedRequest;
        public ObservableRequest SelectedRequest
        {
            get => _selectedRequest;
            set
            {
                _selectedRequest = value;
                _recommendationInventoryViewModel.SelectedRequest = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedRequest"));
            }
        }

        public ObservableCollection<Stat> AttributeList { get; set; }

        public ObservableCollection<String> StatList { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<RuneType> TypeList { get; set; } = new ObservableCollection<RuneType>();

        public ObservableCollection<Object> SelectedStats { get; set; } = new ObservableCollection<Object>();
        public ObservableCollection<Object> NewSelectedStats { get; set; } = new ObservableCollection<Object>();

        public ObservableCollection<Monster> VisibleMonsters { get; set; }

        public Monster NewSelectedMonster { get; set; }


        private StatThreshold _selectedThreshold;
        public StatThreshold SelectedThreshold
        {
            get => _selectedThreshold;
            set
            {
                _selectedThreshold = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedThreshold"));
            }
        }

        public void SaveThreshold(StatThreshold threshold)
        {
            if (!SelectedRequest.Thresholds.Contains(threshold))
            {
                SelectedRequest.Thresholds.Add(threshold);
            }
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedRequest"));
        }

        internal void ProcessCurrent()
        {
           Task.Run(()=>_simulationService.Optimize(SelectedRequest));
            

            DateTime now = DateTime.Now;
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VisibleRequests"));
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


        internal void GeneralSelectedIndexChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RequestCount"));
        }

        internal void NewGeneralSelectedIndexChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewRequestCount"));
        }

        public void SelectNewRequest()
        {
            SelectedRequest = _simulationService.GetNewRequest();

        }

        public void SaveSelected()
        {
            try
            {

            
            _simulationService.UpdateRequest(SelectedRequest);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedRequest"));
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
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

        

        // Binding Properties


        public ObservableCollection<ObservableRequest> VisibleRequests { get; private set; }


        private SimulationService _simulationService;

        // Simulation Updaters 

        public SimulationService Service { get => _simulationService; }
        public void RemoveRequest(ObservableRequest req)
        {
            DeleteRequest(req);
        }

        public void SaveSelectedRequest()
        {
            SaveUpdatedRequest(SelectedRequest);
        }

        public void SaveUpdatedRequest(ObservableRequest request)
        {
            _simulationService.UpdateRequest(request);
        }


        public void DeleteRequest(ObservableRequest request)
        {
            
            _simulationService.DeleteRequest(request);
            
        }


        internal void RemoveThreshold(StatThreshold remove)
        {
            SelectedRequest.Thresholds.Remove(remove);
        }
    }
}

