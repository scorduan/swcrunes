using System;
namespace SWCRunesLib
{
	public interface ISimulation
	{
        


		//Rune Maint
		public Rune GetNewRune();

		public void UpdateRune(Rune rune);

		public void DeleteRune(Rune rune);

		public List<Rune> GetRunesByTypeSlot(RuneType runeType, RuneSlot runeSlot);



		//Monster Maint
		public Monster GetNewMonster();

		public void UpdateMonster(Monster monster);

		public void DeleteMonster(Monster monster);

		public List<Monster> GetAllMonsters();

		public void UnequipRuneSet(string monsterId);


		//Request Maint
		public Request GetNewRequest();

		public void UpdateRequest(Request request);

		public void DeleteRequest(Request request);

		public List<Request> GetAllRequests();


		// Recommendations
		public void Optimize(Request request);

		public List<RecommendedMonster> GetRecommendationPageForMonster(string monsterId, int pageNum, int pageSize, out int numPages);

		public void EquipRuneSet(string monsterId, RuneSet RuneSet);

		public void EquipRune(string monsterId, string runeId);



        //Team Maint
        public Team GetNewTeam();

        public void UpdateTeam(Team team);

        public void DeleteTeam(Team team);

        public List<Team> GetAllTeams();


        // Global


        public Task LoadState(string baseLocation);

		public long CalculatePerms(Request request);
		public Monster GetMonsterForId(string id);

		public bool MonsterHasRecommendations(string requestId);

		public int RecommendationCount(string requestId);

        // Declare the delegate (if using non-generic pattern).
        public delegate void LoadCompleteHandler(object sender);

        // Declare the event.
        public event LoadCompleteHandler LoadCompleteEvent;
    }
}

