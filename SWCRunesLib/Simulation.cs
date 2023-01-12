using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace SWCRunesLib
{
    public class Simulation : ISimulation
    {
        public Simulation()
        {
            _typedSlottedRunes[RuneType.Energy] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Energy]);
            _typedSlottedRunes[RuneType.Guard] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Guard]);

            _typedSlottedRunes[RuneType.Rage] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Rage]);
            _typedSlottedRunes[RuneType.Blade] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Blade]);

            _typedSlottedRunes[RuneType.Fatal] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Fatal]);
            _typedSlottedRunes[RuneType.Swift] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Swift]);

            _typedSlottedRunes[RuneType.Focus] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Focus]);
            _typedSlottedRunes[RuneType.Endure] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Endure]);

            _typedSlottedRunes[RuneType.Foresight] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Foresight]);
            _typedSlottedRunes[RuneType.Assemble] = new Dictionary<RuneSlot, List<Rune>>();
            initSlottedRunes(_typedSlottedRunes[RuneType.Assemble]);


        }

        private SimulationDatabase db;

        private void initSlottedRunes(Dictionary<RuneSlot, List<Rune>> slottedRunes)
        {
            slottedRunes[RuneSlot.ONE] = new List<Rune>();
            slottedRunes[RuneSlot.TWO] = new List<Rune>();
            slottedRunes[RuneSlot.THREE] = new List<Rune>();
            slottedRunes[RuneSlot.FOUR] = new List<Rune>();
            slottedRunes[RuneSlot.FIVE] = new List<Rune>();
            slottedRunes[RuneSlot.SIX] = new List<Rune>();

        }

        private Dictionary<string, Monster> _monsters = new Dictionary<string, Monster>();

        private Dictionary<string, Request> _requests = new Dictionary<string, Request>();

        private Dictionary<string, Team> _teams = new Dictionary<string, Team>();

        private Dictionary<string, Rune> _allRunes = new Dictionary<string, Rune>();

        private Dictionary<RuneType, Dictionary<RuneSlot, List<Rune>>> _typedSlottedRunes = new Dictionary<RuneType, Dictionary<RuneSlot, List<Rune>>>();

        private Dictionary<string, List<RecommendedMonster>> _recommendedMonsters = new Dictionary<string, List<RecommendedMonster>>();

        private string _monstersFile = "";

        private string _requestsFile = "";

        private string _runesFile = "";

        private string _teamsFile = "";
        public void DeleteTeam(Team team)
        {
            _teams.Remove(team.Id);
            db.DeleteTeam(team);
        }

        public void DeleteMonster(Monster monster)
        {
            _monsters.Remove(monster.Id);
            db.DeleteMonster(monster);
        }

        public void DeleteRequest(Request request)
        {
            _requests.Remove(request.Id);
            db.DeleteRequest(request);
        }

        public void DeleteRune(Rune rune)
        {

            _allRunes.Remove(rune.Id);
            _typedSlottedRunes[rune.Type][rune.Slot].Remove(rune);
            db.DeleteRune(rune);
        }

        public void EquipRune(string monsterId, string runeId)
        {
            Rune rune = _allRunes[runeId];
            Rune? oldRune=_monsters[monsterId].EquipOne(rune);
            db.SaveMonster(_monsters[monsterId]);
            db.SaveRune(oldRune);
            db.SaveRune(rune);

        }

        public void EquipRuneSet(string monsterId, RuneSet RuneSet)
        {
            RuneSet oldRunes=_monsters[monsterId].EquipSet(RuneSet);
            db.SaveMonster(_monsters[monsterId]);
            db.SaveRune(oldRunes.RuneOne);
            db.SaveRune(RuneSet.RuneOne);
            db.SaveRune(oldRunes.RuneTwo);
            db.SaveRune(RuneSet.RuneTwo);
            db.SaveRune(oldRunes.RuneThree);
            db.SaveRune(RuneSet.RuneThree);
            db.SaveRune(oldRunes.RuneFour);
            db.SaveRune(RuneSet.RuneFour);
            db.SaveRune(oldRunes.RuneFive);
            db.SaveRune(RuneSet.RuneFive);
            db.SaveRune(oldRunes.RuneSix);
            db.SaveRune(RuneSet.RuneFive);
        }

        public void UnequipRuneSet(string monsterId)
        {
            RuneSet oldRunes=_monsters[monsterId].UnequipAll();
            db.SaveMonster(_monsters[monsterId]);
            db.SaveRune(oldRunes.RuneOne);
            
            db.SaveRune(oldRunes.RuneTwo);
            
            db.SaveRune(oldRunes.RuneThree);
            
            db.SaveRune(oldRunes.RuneFour);
            
            db.SaveRune(oldRunes.RuneFive);

            db.SaveRune(oldRunes.RuneSix);
        }


        public Team GetNewTeam()
        {
            return new Team(GetNewTeamId());
        }

        public List<Team> GetAllTeams()
        {
            return _teams.Values.ToList<Team>();
        }

        public List<Monster> GetAllMonsters()
        {
            return _monsters.Values.ToList<Monster>();
        }

        public List<Request> GetAllRequests()
        {
            return _requests.Values.ToList<Request>();
        }

        public Monster GetNewMonster()
        {

            return new Monster(GetNewMonsterId());
        }

        public Request GetNewRequest()
        {
            return new Request(GetNewRequestId());
        }

        public Rune GetNewRune()
        {
            return new Rune(GetNewRuneId());
        }

        public List<RecommendedMonster> GetRecommendationPageForMonster(string monsterId, int pageNum, int pageSize, out int numPages)
        {

            List<RecommendedMonster> foundMonsters = new List<RecommendedMonster>();
            numPages = 0;
            if (_recommendedMonsters.ContainsKey(monsterId))
            {
                List<RecommendedMonster> allRecommends = _recommendedMonsters[monsterId];
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

        public List<Rune> GetRunesByTypeSlot(RuneType runeType, RuneSlot runeSlot)
        {
            return _typedSlottedRunes[runeType][runeSlot];
        }

        public void UpdateTeam(Team team)
        {

            db.SaveTeam(team);
            _teams[team.Id] = team;
        }

        public void UpdateMonster(Monster monster)
        {
            db.SaveMonster(monster);
            _monsters[monster.Id] = monster;
        }

        public void UpdateRequest(Request request)
        {
            _requests[request.Id] = request;
            db.SaveRequest(request);
        }

        public void UpdateRune(Rune rune)
        {
            if (_allRunes.ContainsKey(rune.Id))
            {
                Rune oldRune = _allRunes[rune.Id];
                _typedSlottedRunes[oldRune.Type][oldRune.Slot].Remove(oldRune);

            }

            _allRunes[rune.Id] = rune;
            _typedSlottedRunes[rune.Type][rune.Slot].Add(rune);
            db.SaveRune(rune);

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

        internal string GetNewTeamId()
        {
            return Guid.NewGuid().ToString();
        }


        public void Optimize(Request request)
        {
            Optimizer optimizer = new Optimizer(_allRunes.Values.ToList());
            List<RecommendedMonster> recommendedMonsters = optimizer.ProcessReq(request, _monsters[request.MonsterId]);
            _recommendedMonsters[request.MonsterId] = recommendedMonsters;
        }


        // Declare the event.
        public event ISimulation.LoadCompleteHandler LoadCompleteEvent;

        public async Task LoadState(string baseLocation)
        {
            db = new SimulationDatabase(baseLocation);
            _monstersFile = System.IO.Path.Combine(baseLocation, "monsters.data");
            _runesFile = System.IO.Path.Combine(baseLocation, "runes.data");
            _requestsFile = System.IO.Path.Combine(baseLocation, "requests.data");
            _teamsFile = System.IO.Path.Combine(baseLocation, "teams.data");

            try
            {
                List<Monster> mons = await db.GetAllMonsters();
                List<Rune> runes = await db.GetAllRunes();
                List<Request> requests = await db.GetAllRequests();
                List<Team> teams = await db.GetAllTeams();



                foreach (Monster monster in mons)
                {
                    if (monster.Id == "") monster.Id = GetNewMonsterId();
                    _monsters.Add(monster.Id, monster);
                    await db.SaveMonster(monster);
                }

                foreach (Request request in requests)
                {
                    if (request.Id == "") request.Id = GetNewRequestId();
                    if (request.MonsterId != "") request.MonsterName = _monsters[request.MonsterId].Name;
                    _requests.Add(request.Id, request);
                    await db.SaveRequest(request);
                }

                foreach (Rune rune in runes)
                {
                    if (rune.Id == "") rune.Id = GetNewRuneId();
                    _allRunes.Add(rune.Id, rune);
                    _typedSlottedRunes[rune.Type][rune.Slot].Add(rune);
                    await db.SaveRune(rune);
                    if (rune.EquippedOn != "")
                    {
                        if (_monsters.ContainsKey(rune.EquippedOn))
                        {
                            _monsters[rune.EquippedOn].EquipOne(rune);
                        }
                    }
                }

                foreach (Team team in teams)
                {
                    if (team.SoulMonsterId != "")
                    {
                        team.SoulMonster = _monsters[team.SoulMonsterId];
                    }
                    if (team.OtherMonster1Id != "")
                    {
                        team.OtherMonster1 = _monsters[team.OtherMonster1Id];
                    }
                    if (team.OtherMonster2Id != "")
                    {
                        team.OtherMonster2 = _monsters[team.OtherMonster2Id];
                    }

                    _teams.Add(team.Id, team);
                    await db.SaveTeam(team);
                }
            }
            catch (Exception e)
            {

            }

            LoadCompleteEvent?.Invoke(this);
        }

        private async Task SaveState()
        {
            await RuneSerializer.SaveRunes(_allRunes.Values.ToList(), _runesFile);
            await RuneSerializer.SaveMonsters(_monsters.Values.ToList(), _monstersFile);
            await RuneSerializer.SaveRequests(_requests.Values.ToList(), _requestsFile);
            await RuneSerializer.SaveTeams(_teams.Values.ToList(), _teamsFile);
        }

        public long CalculatePerms(Request request)
        {
            Optimizer optimizer = new Optimizer(_allRunes.Values.ToList());
            optimizer.UpdateReq(request);
            return optimizer.CalculatePerms();
        }


        public Monster GetMonsterForId(string id)
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

