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
            SelectedRequest = selectedItem;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedRequest"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Requests"));
        }

        internal void ProcessCurrent()
        {
            _optimizationService.ProcessRequest(SelectedRequest);
        }
    }
}

