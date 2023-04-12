using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SWCRunesLib;
namespace SWCRunes.Model
{
    public class ObservableTeam : ITeam, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void notifChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableTeam(Team team)
        {
            _team = team;
        }

        public Team Team { get => _team; }

        private Team _team;

        public string Id {
            get => ((ITeam)_team).Id;
            set { ((ITeam)_team).Id = value; notifChanged(); }
        }
        public string Job {
            get => ((ITeam)_team).Job;
            set { ((ITeam)_team).Job = value; notifChanged(); }
        }
        public int Weight { get => ((ITeam)_team).Weight; set { ((ITeam)_team).Weight = value; notifChanged(); } }
        public string SoulMonsterId { get => ((ITeam)_team).SoulMonsterId; set { ((ITeam)_team).SoulMonsterId = value; notifChanged(); } }
        public Monster SoulMonster { get => ((ITeam)_team).SoulMonster; set { ((ITeam)_team).SoulMonster = value; notifChanged(); } }
        public string OtherMonster1Id { get => ((ITeam)_team).OtherMonster1Id; set { ((ITeam)_team).OtherMonster1Id = value; notifChanged(); } }
        public Monster OtherMonster1 { get => ((ITeam)_team).OtherMonster1; set { ((ITeam)_team).OtherMonster1 = value; notifChanged(); } }
        public string OtherMonster2Id { get => ((ITeam)_team).OtherMonster2Id; set { ((ITeam)_team).OtherMonster2Id = value; notifChanged(); }}
        public Monster OtherMonster2 { get => ((ITeam)_team).OtherMonster2; set { ((ITeam)_team).OtherMonster2 = value; notifChanged(); }}
    }
}

