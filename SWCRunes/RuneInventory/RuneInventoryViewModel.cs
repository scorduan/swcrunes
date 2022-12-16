using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SWCRunesLib;
namespace SWCRunes
{
    public class RuneInventoryViewModel : INotifyPropertyChanged
    {
        public RuneInventoryViewModel(StorageService storageServ)
        {
            NewSlot = Rune.RuneSlot.ONE;
            NewType = Rune.RuneType.Energy;
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

        public Rune.RuneSlot NewSlot { get; set; }

        public Rune.RuneType NewType { get; set; }


        public void SaveNewRune()
        {
            Rune rune = new Rune();

            rune.Slot = NewSlot;
            rune.Type = NewType;

            rune.ATKP = NewATKP;
            rune.ATKF = NewATKF;

            rune.DEFP = NewDEFP;
            rune.DEFF = NewDEFF;

            rune.HPP = NewHPP;
            rune.HPF = NewHPF;

            rune.SPD = NewSPD;

            rune.CR = NewCR;
            rune.CD = NewCD;

            rune.ACC = NewACC;
            rune.RES = NewRES;

            rune.PR = NewPR;
            rune.EV = NewEV;

            _runes.Add(rune);
            _storageServ.SaveRunes(_runes);
            
        }

    
    }
}

