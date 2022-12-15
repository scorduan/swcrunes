using System;
using System.ComponentModel;
using SWCRunesLib;

namespace SWCRunes
{
    public class RecommendationInventoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        
        public RecommendationInventoryViewModel(OptimizationService service)
        {
            _optService = service;
        }

        private OptimizationService _optService;

        public void Optimize()
        {
            if (_recStore != null) _recStore.Clear();
            _recStore = _optService.Process();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RecStore"));

        }


        private List<Recommendation> _recStore;
        public List<Recommendation> RecStore { get { return _recStore; } }
        
    }
}

