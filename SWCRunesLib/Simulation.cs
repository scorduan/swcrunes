using System;

namespace SWCRunesLib
{
	public class Simulation : ISimulation
	{
		public Simulation()
		{
		}

        public void DeleteMonster(string monsterId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRequest(string requestId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRune(string runeId)
        {
            throw new NotImplementedException();
        }

        public void EquipRune(string monsterId, string runeId)
        {
            throw new NotImplementedException();
        }

        public void EquipRuneSet(string monsterId, RuneSet runeSet)
        {
            throw new NotImplementedException();
        }

        public List<IMonster> GetAllMonsters()
        {
            throw new NotImplementedException();
        }

        public List<IRequest> GetAllRequests()
        {
            throw new NotImplementedException();
        }

        public IMonster GetNewMonster()
        {
            throw new NotImplementedException();
        }

        public IRequest GetNewRequest()
        {
            throw new NotImplementedException();
        }

        public IRune GetNewRune()
        {
            throw new NotImplementedException();
        }

        public List<IRecommendedMonster> GetRecommendationPageForMonster(string monsterId, out int numPages)
        {
            throw new NotImplementedException();
        }

        public List<IRune> GetRunesByTypeSlot(RuneType runeType, RuneSlot runeSlot)
        {
            throw new NotImplementedException();
        }

        public void LoadState(string baseLocation)
        {
            throw new NotImplementedException();
        }

        public void Optimize(string requestId)
        {
            throw new NotImplementedException();
        }

        public void SaveState()
        {
            throw new NotImplementedException();
        }

        public void UpdateMonster(IMonster monster)
        {
            throw new NotImplementedException();
        }

        public void UpdateRequest(IRequest request)
        {
            throw new NotImplementedException();
        }

        public void UpdateRune(IRune rune)
        {
            throw new NotImplementedException();
        }

        internal string GetNewRuneId()
        {
            return Guid.NewGuid().ToString();
        }

        internal string GetNewMonsterId()
        {
            return Guid.NewGuid().ToString();
        }

        internal string GetNewRequestId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

