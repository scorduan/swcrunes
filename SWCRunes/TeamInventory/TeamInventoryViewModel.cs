using System;
using SWCRunesLib;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SWCRunes
{
	public class TeamInventoryViewModel : INotifyPropertyChanged
	{
		public TeamInventoryViewModel(SimulationService simService)
		{
			_simulationService = simService;
			AllTeams = _simulationService.GetAllTeams();
            AllMonsters = _simulationService.GetAllMonsters();
            
        }

		private SimulationService _simulationService;

        public event PropertyChangedEventHandler PropertyChanged;

        public Team SelectedTeam { get; private set; }

        public Monster SelectedSoulLink { get; set; }

        public Monster SelectedOther1 { get; set; }

        public Monster SelectedOther2 { get; set; }

		public ObservableCollection<Team> AllTeams { get; set; }

        public ObservableCollection<Monster> AllMonsters { get; set; }


        public void SelectNewTeam()
        {
            ChangeSelectedTeam(_simulationService.GetNewTeam());

        }

        public void ChangeSelectedTeam(Team team)
        {
            SelectedTeam = team;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTeam"));
        }

        public void SaveSelected()
        {
            try
            {

            
            if (SelectedTeam.SoulMonster!=null) SelectedTeam.SoulMonsterId = SelectedTeam.SoulMonster.Id;
                if (SelectedTeam.OtherMonster1 != null)  SelectedTeam.OtherMonster1Id = SelectedTeam.OtherMonster1.Id;
                if (SelectedTeam.OtherMonster2 != null)  SelectedTeam.OtherMonster2Id = SelectedTeam.OtherMonster2.Id;
            _simulationService.UpdateTeam(SelectedTeam);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AllTeams"));
            }
            catch (Exception e)
            {

            }


        }

        public void DeleteTeam(Team team)
        {
            _simulationService.DeleteTeam(team);
            
        }
    }
}

