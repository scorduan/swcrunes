using System;
using SWCRunesLib;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SWCRunes.Model
{
	public class ObservableRequest: IRequest,IComparable<ObservableRequest>, IEquatable<ObservableRequest>, INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;
        private void notifChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CompareTo(Request other)
        {
            return ((IRequest)_request).CompareTo(other);
        }

        public bool Equals(Request other)
        {
            return ((IRequest)_request).Equals(other);
        }

        public int CompareTo(ObservableRequest other)
        {
            return ((IRequest)_request).CompareTo(other?.Request);
        }

        public bool Equals(ObservableRequest other)
        {
            return ((IRequest)_request).Equals(other?.Request);
        }


        public ObservableRequest(Request request)
        {
            _request = request;
            _request.StatusUpdate += statusUpdate;
        }

        public Request Request { get => _request; }

        private Request _request;

        public string MonsterId { get => ((IRequest)_request).MonsterId; set { ((IRequest)_request).MonsterId = value;  notifChanged(); } }
        public string MonsterName { get => ((IRequest)_request).MonsterName; set { ((IRequest)_request).MonsterName = value; notifChanged(); } }
        public RequestStatus Status { get => ((IRequest)_request).Status; set { ((IRequest)_request).Status = value; notifChanged(); } }
        public long PossiblePermutations { get => ((IRequest)_request).PossiblePermutations; set { ((IRequest)_request).PossiblePermutations = value; notifChanged(); } }
        public long PermCount { get => ((IRequest)_request).PermCount; set { ((IRequest)_request).PermCount = value; notifChanged(); } }
        public long ResultCount { get => ((IRequest)_request).ResultCount; set { ((IRequest)_request).ResultCount = value; notifChanged(); } }
        public Monster Monster { get => ((IRequest)_request).Monster; set { ((IRequest)_request).Monster = value; notifChanged(); } }
        public Stat PrimaryAttribute { get => ((IRequest)_request).PrimaryAttribute; set { ((IRequest)_request).PrimaryAttribute = value; notifChanged(); } }
        public Stat SecondaryAttribute { get => ((IRequest)_request).SecondaryAttribute; set { ((IRequest)_request).SecondaryAttribute = value; notifChanged(); } }
        public Stat TertiaryAttribute { get => ((IRequest)_request).TertiaryAttribute; set { ((IRequest)_request).TertiaryAttribute = value; notifChanged(); } }
        public RuneType RestrictSetOne { get => ((IRequest)_request).RestrictSetOne; set { ((IRequest)_request).RestrictSetOne = value; notifChanged(); } }
        public RuneType RestrictSetTwo { get => ((IRequest)_request).RestrictSetTwo; set { ((IRequest)_request).RestrictSetTwo = value; notifChanged(); } }
        public RuneType RestrictSetThree { get => ((IRequest)_request).RestrictSetThree; set { ((IRequest)_request).RestrictSetThree = value; notifChanged(); } }
        public bool StealLowerPriority { get => ((IRequest)_request).StealLowerPriority; set { ((IRequest)_request).StealLowerPriority = value; notifChanged(); } }
        public List<StatThreshold> Thresholds { get => ((IRequest)_request).Thresholds; set { ((IRequest)_request).Thresholds = value; notifChanged(); } }
        public string ThresholdJSON { get => ((IRequest)_request).ThresholdJSON; set { ((IRequest)_request).ThresholdJSON = value; notifChanged(); } }
        public List<string> FocusStats { get => ((IRequest)_request).FocusStats; set { ((IRequest)_request).FocusStats = value; notifChanged(); } }
        public string FocusStatString { get => ((IRequest)_request).FocusStatString; set { ((IRequest)_request).FocusStatString = value; notifChanged(); } }
        public string Id { get => ((IRequest)_request).Id; set { ((IRequest)_request).Id = value; notifChanged(); } }
        public DateTime LastRun { get => ((IRequest)_request).LastRun; set { ((IRequest)_request).LastRun = value; notifChanged(); } }
        public long FilteredCount { get => ((IRequest)_request).FilteredCount; set { ((IRequest)_request).FilteredCount = value; notifChanged(); } }

        public int PermProgress { get => ((IRequest)_request).PermProgress; set { ((IRequest)_request).PermProgress = value; notifChanged(); } }
        public void statusUpdate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PossiblePermutations"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PermCount"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ResultCount"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastRun"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilteredCount"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PermProgress"));
        }

    }
}

