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
        public RequestInventoryViewModel(OptimizationService optimServ,StorageService storageServ)
        {
          
            _storageServ = storageServ;
            _optimizationService = optimServ;
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



            _requests = storageServ.GetRequests() ;
        }
        
        private ObservableCollection<Request> _requests;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Request> Requests
        {
            get
            {
                return _requests;
            }

           
        }

        OptimizationService _optimizationService;

        StorageService _storageServ;

        public Request SelectedRequest { get; set; }

        public ObservableCollection<String> AttributeList { get; set; }

        public ObservableCollection<String> StatList { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<RuneType> TypeList { get; set; } = new ObservableCollection<RuneType>();

        public ObservableCollection<Object> SelectedStats { get; set; } = new ObservableCollection<Object>();


        public int RequestCount
        {
            get
            {
                return _optimizationService.CalculatePerms();
            }
        }    

        public void SaveNewRequest()
        {
            Request Request = new Request();
            _storageServ.SaveRequests(_requests);
            
        }

        public void SaveUpdatedRequest()
        {
            _storageServ.SaveRequests(_requests);
        }

        public void RemoveSelected()
        {
            _requests.Remove(SelectedRequest);
            SelectedRequest = null;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedRequest"));

        }

        public void AddNew()
        {
            _requests.Add(new Request());
        }

        internal void ChangeSelectedRequest(Request selectedItem)
        {


            //SelectedStats.Clear();
            SelectedRequest = selectedItem;

            ObservableCollection<Object> selectedStats = new ObservableCollection<object>();
            _optimizationService.UpdateRequest(selectedItem);
            /*
            foreach (string stat in SelectedRequest.FocusStats)
            {
                SelectedStats.Add(stat);
            }*/
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedRequest"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RequestCount"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedStats"));
        }

        internal void ProcessCurrent()
        {
            _optimizationService.ProcessRequest(SelectedRequest);
        }

        internal void UpdateSelectedStats(IReadOnlyList<object> currentSelection)
        {
            SelectedRequest.FocusStats.Clear();
                foreach (string stat in currentSelection)
                {
                    SelectedRequest.FocusStats.Add(stat);
                }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RequestCount"));
        }

        internal void GeneralSelectedIndexChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RequestCount"));
        }
    }
}

