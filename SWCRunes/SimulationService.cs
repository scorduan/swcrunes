using System;
using SWCRunesLib;
namespace SWCRunes
{
	public class SimulationService : ISimulation
	{
		public SimulationService(ISimulation simulation)
		{
			_simulation = simulation;
		}

		private ISimulation _simulation;


        //Rune Maint
        public IRune GetNewRune()
        {
            return _simulation.GetNewRune();
        }

        public void UpdateRune(IRune rune)
        {
            _simulation.UpdateRune(rune);
        }

        public void DeleteRune(string runeId)
        {
            _simulation.DeleteRune(runeId);
        }


        public List<IRune> GetRunesByTypeSlot(RuneType runeType, RuneSlot runeSlot)
        {
            return _simulation.GetRunesByTypeSlot(runeType, runeSlot);
        }


        //Monster Maint
        public IMonster GetNewMonster()
        {
            return _simulation.GetNewMonster();
        }

        public void UpdateMonster(IMonster monster)
        {
            _simulation.UpdateMonster(monster);
        }

        public void DeleteMonster(string monsterId)
        {
            _simulation.DeleteMonster(monsterId);
        }

        public List<IMonster> GetAllMonsters()
        {
            return _simulation.GetAllMonsters();
        }


        // Request Maint

        public IRequest GetNewRequest()
        {
            return _simulation.GetNewRequest();
        }

        public void UpdateRequest(IRequest request)
        {
            _simulation.UpdateRequest(request);
        }

        public void DeleteRequest(string requestId)
        {
            _simulation.DeleteRequest(requestId);
        }

        public List<IRequest> GetAllRequests()
        {
            return _simulation.GetAllRequests();
        }

        //Recommendations
        public void Optimize(string requestId)
        {
            _simulation.Optimize(requestId);
        }

        public List<IRecommendedMonster> GetRecommendationPageForMonster(string monsterId, out int numPages)
        {
            return _simulation.GetRecommendationPageForMonster(monsterId, out numPages);
        }

        public void EquipRuneSet(string monsterId, RuneSet runeSet)
        {
            _simulation.EquipRuneSet(monsterId, runeSet);
        }

        public void EquipRune(string monsterId, string runeId)
        {
            _simulation.EquipRune(monsterId, runeId);
        }

        public void SaveState()
        {
            _simulation.SaveState();
        }

        public void LoadState(string baseLocation)
        {
            _simulation.LoadState(baseLocation);
        }




    }
}

