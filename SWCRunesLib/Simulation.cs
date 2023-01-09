using System;
using System.Collections.ObjectModel;
using System.Text;

namespace SWCRunesLib
{
    public class Simulation : ISimulation
    {
        public Simulation()
        {
            _typedSlottedRunes[RuneType.Energy] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Energy]);
            _typedSlottedRunes[RuneType.Guard] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Guard]);

            _typedSlottedRunes[RuneType.Rage] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Rage]);
            _typedSlottedRunes[RuneType.Blade] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Blade]);

            _typedSlottedRunes[RuneType.Fatal] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Fatal]);
            _typedSlottedRunes[RuneType.Swift] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Swift]);

            _typedSlottedRunes[RuneType.Focus] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Focus]);
            _typedSlottedRunes[RuneType.Endure] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Endure]);

            _typedSlottedRunes[RuneType.Foresight] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Foresight]);
            _typedSlottedRunes[RuneType.Assemble] = new Dictionary<RuneSlot, List<IRune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Assemble]);


        }

        private void initSlottedRunes(Dictionary<RuneSlot, List<IRune>> slottedRunes)
        {
            slottedRunes[RuneSlot.ONE] = new List<IRune>();
            slottedRunes[RuneSlot.TWO] = new List<IRune>();
            slottedRunes[RuneSlot.THREE] = new List<IRune>();
            slottedRunes[RuneSlot.FOUR] = new List<IRune>();
            slottedRunes[RuneSlot.FIVE] = new List<IRune>();
            slottedRunes[RuneSlot.SIX] = new List<IRune>();

        }

        private Dictionary<string, IMonster> _monsters = new Dictionary<string, IMonster>();

        private Dictionary<string, IRequest> _requests = new Dictionary<string, IRequest>();

        private Dictionary<string, IRune> _allRunes = new Dictionary<string, IRune>();

        private Dictionary<RuneType, Dictionary<RuneSlot, List<IRune>>> _typedSlottedRunes = new Dictionary<RuneType, Dictionary<RuneSlot, List<IRune>>>();

        private Dictionary<string, List<IRecommendedMonster>> _recommendedMonsters = new Dictionary<string, List<IRecommendedMonster>>();

        private string _monstersFile = "";

        private string _requestsFile = "";

        private string _runesFile = "";


        public void DeleteMonster(string monsterId)
        {
            _monsters.Remove(monsterId);
            SaveState();
        }

        public void DeleteRequest(string requestId)
        {
            _requests.Remove(requestId);
            SaveState();
        }

        public void DeleteRune(string runeId)
        {
            IRune rune = _allRunes[runeId];
            _allRunes.Remove(runeId);
            _typedSlottedRunes[rune.Type][rune.Slot].Remove(rune);
            SaveState();
        }

        public void EquipRune(string monsterId, string runeId)
        {
            IRune rune = _allRunes[runeId];
            _monsters[monsterId].EquipOne(rune);
            SaveState();

        }

        public void EquipIRuneSet(string monsterId, IRuneSet IRuneSet)
        {
            _monsters[monsterId].EquipSet(IRuneSet);
            SaveState();
        }

        public void UnequipRuneSet(string monsterId)
        {
            _monsters[monsterId].UnequipAll();
            SaveState();
        }

        public List<IMonster> GetAllMonsters()
        {
            return _monsters.Values.ToList<IMonster>();
        }

        public List<IRequest> GetAllRequests()
        {
            return _requests.Values.ToList<IRequest>();
        }

        public IMonster GetNewMonster()
        {

            return new Monster(GetNewMonsterId());
        }

        public IRequest GetNewRequest()
        {
            return new Request(GetNewRequestId());
        }

        public IRune GetNewRune()
        {
            return new Rune(GetNewRuneId());
        }

        public List<IRecommendedMonster> GetRecommendationPageForMonster(string monsterId, int pageNum, int pageSize, out int numPages)
        {
            
            List<IRecommendedMonster> foundMonsters = new List<IRecommendedMonster>();
            numPages = 0;
            if (_recommendedMonsters.ContainsKey(monsterId))
            {
                List<IRecommendedMonster> allRecommends = _recommendedMonsters[monsterId];
                int totalMonsters = allRecommends.Count();
                numPages = (int)Math.Ceiling((float)totalMonsters / (float)pageSize);
                int startingPoint = (pageNum - 1) * pageSize;
                int endingPoint = Math.Min(pageNum * pageSize, numPages * pageSize);
                for (int i = startingPoint; i < endingPoint; i++)
                {
                    foundMonsters.Add(allRecommends[i]);
                }
            }

            return foundMonsters;

        }

        public List<IRune> GetRunesByTypeSlot(RuneType runeType, RuneSlot runeSlot)
        {
            return _typedSlottedRunes[runeType][runeSlot];
        }



        public void UpdateMonster(IMonster monster)
        {
            _monsters[monster.Id] = monster;
            SaveState();
        }

        public void UpdateRequest(IRequest request)
        {
            _requests[request.Id] = request;
            SaveState();
        }

        public void UpdateRune(IRune rune)
        {
            if (_allRunes.ContainsKey(rune.Id))
            {
                IRune oldRune = _allRunes[rune.Id];
                _typedSlottedRunes[oldRune.Type][oldRune.Slot].Remove(oldRune);

            }

            _allRunes[rune.Id] = rune;
            _typedSlottedRunes[rune.Type][rune.Slot].Add(rune);
            SaveState();

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

        public void Optimize(IRequest request)
        {
            Optimizer optimizer = new Optimizer(_allRunes.Values.ToList());
            List<IRecommendedMonster> recommendedMonsters= optimizer.ProcessReq(request, _monsters[request.MonsterId]);
            _recommendedMonsters[request.MonsterId] = recommendedMonsters;
        }

        public void LoadState(string baseLocation)
        {
            _monstersFile = System.IO.Path.Combine(baseLocation, "monsters.data");
            _runesFile = System.IO.Path.Combine(baseLocation, "runes.data");
            _requestsFile = System.IO.Path.Combine(baseLocation, "requests.data");

            List<IMonster> mons = RuneSerializer.ReadMonstersFromFile(_monstersFile);
            List<IRune> runes = RuneSerializer.ReadRunesFromFile(_runesFile);
            List<IRequest> requests = RuneSerializer.ReadRequestsFromFile(_requestsFile);

            foreach (IMonster monster in mons)
            {
                if (monster.Id == "") monster.Id = GetNewMonsterId();
                _monsters.Add(monster.Id, monster);
            }

            foreach (IRequest request in requests)
            {
                if (request.Id == "") request.Id = GetNewRequestId();
                if (request.MonsterId != "") request.MonsterName = _monsters[request.MonsterId].Name;
                _requests.Add(request.Id, request);
            }

            foreach (IRune rune in runes)
            {
                if (rune.Id == "") rune.Id = GetNewRuneId();
                _allRunes.Add(rune.Id, rune);
                _typedSlottedRunes[rune.Type][rune.Slot].Add(rune);
                if (rune.EquippedOn!="")
                {
                    if (_monsters.ContainsKey(rune.EquippedOn))
                    {
                        _monsters[rune.EquippedOn].EquipOne(rune);
                    }
                }
            }
        }

        private async Task SaveState()
        {
            await RuneSerializer.SaveRunes(_allRunes.Values.ToList(), _runesFile);
            await RuneSerializer.SaveMonsters(_monsters.Values.ToList(), _monstersFile);
            await RuneSerializer.SaveRequests(_requests.Values.ToList(), _requestsFile);
        }

        public long CalculatePerms(IRequest request)
        {
            Optimizer optimizer = new Optimizer(_allRunes.Values.ToList());
            optimizer.UpdateReq(request);
            return optimizer.CalculatePerms();
        }


        public IMonster GetMonsterForId(string id)
        {
            return _monsters[id];
        }

        public bool MonsterHasRecommendations(string monsterId)
        {
            return _recommendedMonsters.ContainsKey(monsterId);
        }

        public int RecommendationCount(string monsterId)
        {
            int count = 0;
            if (MonsterHasRecommendations(monsterId))
            {
                if (_recommendedMonsters[monsterId] != null)
                {
                    count = _recommendedMonsters[monsterId].Count;
                }
                
            }
            return count;
        }
    }
}

