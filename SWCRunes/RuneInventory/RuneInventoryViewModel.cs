using System;
using System.ComponentModel;
using SWCRunesLib;
namespace SWCRunes
{
    public class RuneInventoryViewModel : INotifyPropertyChanged
    {
        public RuneInventoryViewModel(StorageService storageServ)
        {
            _runeStore = storageServ.RuneStore.Runes;
        }
        
        private List<Rune> _runeStore;
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Rune> Runes { get => _runeStore; }

        public int NewATKP { get; set; }

        public void SaveNewRune()
        {
            Rune rune = new Rune();
            rune.ATKP = NewATKP;
            Runes.Add(rune);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Runes"));
        }
    }
}

