using System;
using SWCRunesLib;
using System.Collections.ObjectModel;
namespace SWCRunes
{
	public class SimulationService
	{
		public SimulationService(ISimulation simulation)
		{
			_simulation = simulation;
            _simulation.LoadState(FileSystem.Current.AppDataDirectory);
            refreshMonsters();
            refreshRequests();

		}

		private ISimulation _simulation;
        private ObservableCollection<IMonster> _monsters = new ObservableCollection<IMonster>();
        private ObservableCollection<IRequest> _requests = new ObservableCollection<IRequest>();
        private ObservableCollection<IRune> _runes = new ObservableCollection<IRune>();


        //Rune Maint
        public IRune GetNewRune()
        {
            return _simulation.GetNewRune();
        }

        public void UpdateRune(IRune rune)
        {
            _simulation.UpdateRune(rune);
            UpdateRuneList(_lastRuneType, _lastRuneSlot);
        }

        public void DeleteRune(string runeId)
        {
            _simulation.DeleteRune(runeId);
        }

        private RuneType _lastRuneType = RuneType.Energy;
        private RuneSlot _lastRuneSlot = RuneSlot.ONE;
        public void UpdateRuneList(RuneType runeType, RuneSlot runeSlot)
        {
            _lastRuneType = runeType;
            _lastRuneSlot = runeSlot;
            List<IRune> runes = _simulation.GetRunesByTypeSlot(runeType, runeSlot);
            _runes.Clear();
            foreach (IRune rune in runes)
            {
                _runes.Add(rune);
            }
            
        }


        public ObservableCollection<IRune> GetRunes()
        {
            return _runes;
        }

        //Monster Maint
        public IMonster GetNewMonster()
        {
            return _simulation.GetNewMonster();
        }

        public void UpdateMonster(IMonster monster)
        {
            _simulation.UpdateMonster(monster);
            refreshMonsters();
        }

        public void DeleteMonster(string monsterId)
        {
            
            _simulation.DeleteMonster(monsterId);
            refreshMonsters();
        }


        private void refreshMonsters()
        {
            _monsters.Clear();
            List<IMonster> monsters = _simulation.GetAllMonsters();
            foreach (IMonster m in monsters)
                _monsters.Add(m);
        }

        public ObservableCollection<IMonster> GetAllMonsters()
        {
            return _monsters;
        }


        // Request Maint

        public IRequest GetNewRequest()
        {
            return _simulation.GetNewRequest();
        }

        public void UpdateRequest(IRequest request)
        {
            _simulation.UpdateRequest(request);
            refreshRequests();
        }

        public void DeleteRequest(string requestId)
        {
            _simulation.DeleteRequest(requestId);
            refreshRequests();
        }

        private void refreshRequests()
        {
            _requests.Clear();
            List<IRequest> requests = _simulation.GetAllRequests();
            foreach (IRequest request in requests)
                _requests.Add(request);
        }

        public ObservableCollection<IRequest> GetAllRequests()
        {
            return _requests;
        }


        //Recommendations
        public void Optimize(IRequest request)
        {
            _simulation.Optimize(request);
        }

        public List<IRecommendedMonster> GetRecommendationPageForMonster(string monsterId, int pageNum, int pageSize, out int numPages)
        {
            return _simulation.GetRecommendationPageForMonster(monsterId, pageNum, pageSize, out numPages);
        }

        public void EquipIRuneSet(string monsterId, IRuneSet IRuneSet)
        {
            _simulation.EquipIRuneSet(monsterId, IRuneSet);
        }

        public void EquipRune(string monsterId, string runeId)
        {
            _simulation.EquipRune(monsterId, runeId);
        }


        public void LoadState(string baseLocation)
        {
            _simulation.LoadState(baseLocation);
        }

        public string GetMonsterNameForId(string id)
        {

            return _simulation.GetMonsterForId(id).Name;
        }

        public IMonster GetMonsterForId(string id)
        {
            return _simulation.GetMonsterForId(id);
        }

        public int CalcPerms(IRequest request)
        {
            return _simulation.CalculatePerms(request);
        }

    }
}

