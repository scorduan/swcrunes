using System;
namespace SWCRunesLib
{
	public interface ISimulation
	{
        


		//Rune Maint
		public IRune GetNewRune();

		public void UpdateRune(IRune rune);

		public void DeleteRune(string runeId);

		public List<IRune> GetRunesByTypeSlot(RuneType runeType, RuneSlot runeSlot);



		//Monster Maint
		public IMonster GetNewMonster();

		public void UpdateMonster(IMonster monster);

		public void DeleteMonster(string monsterId);

		public List<IMonster> GetAllMonsters();

		public void UnequipRuneSet(string monsterId);


		//Request Maint
		public IRequest GetNewRequest();

		public void UpdateRequest(IRequest request);

		public void DeleteRequest(string requestId);

		public List<IRequest> GetAllRequests();


		// Recommendations
		public void Optimize(IRequest request);

		public List<IRecommendedMonster> GetRecommendationPageForMonster(string monsterId, int pageNum, int pageSize, out int numPages);

		public void EquipIRuneSet(string monsterId, IRuneSet IRuneSet);

		public void EquipRune(string monsterId, string runeId);



		// Global


		public void LoadState(string baseLocation);

		public long CalculatePerms(IRequest request);
		public IMonster GetMonsterForId(string id);

		public bool MonsterHasRecommendations(string requestId);

		public int RecommendationCount(string requestId);
    }
}

