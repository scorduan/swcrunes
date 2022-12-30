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


		//Request Maint
		public IRequest GetNewRequest();

		public void UpdateRequest(IRequest request);

		public void DeleteRequest(string requestId);

		public List<IRequest> GetAllRequests();


		// Recommendations
		public void Optimize(string requestId);

		public List<IRecommendedMonster> GetRecommendationPageForMonster(string monsterId, out int numPages);

		public void EquipRuneSet(string monsterId, RuneSet runeSet);

		public void EquipRune(string monsterId, string runeId);



		// Global

		public void SaveState();

		public void LoadState(string baseLocation);


    }
}

