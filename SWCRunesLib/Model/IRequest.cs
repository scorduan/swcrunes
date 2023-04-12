namespace SWCRunesLib
{
    public interface IRequest
    {
        string MonsterId { get; set; }
        string MonsterName { get; set; }
        RequestStatus Status { get; set; }
        long PossiblePermutations { get; set; }
        long PermCount { get; set; }
        long ResultCount { get; set; }
        Monster Monster { get; set; }
        Stat PrimaryAttribute { get; set; }
        Stat SecondaryAttribute { get; set; }
        Stat TertiaryAttribute { get; set; }
        RuneType RestrictSetOne { get; set; }
        RuneType RestrictSetTwo { get; set; }
        RuneType RestrictSetThree { get; set; }
        bool StealLowerPriority { get; set; }
        List<StatThreshold> Thresholds { get; set; }
        string ThresholdJSON { get; set; }
        List<string> FocusStats { get; set; }
        string FocusStatString { get; set; }
        string Id { get; set; }
        public DateTime LastRun { get; set;}
        public long FilteredCount { get; set; }
        public int PermProgress { get; set; }
        int CompareTo(Request? other);
        bool Equals(Request? other);
    }
}