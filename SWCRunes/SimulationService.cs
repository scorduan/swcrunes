using System;
using SWCRunesLib;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace SWCRunes
{
    public class SimulationService
    {
        public SimulationService(ISimulation simulation)
        {
            _simulation = simulation;
            _simulation.LoadCompleteEvent += _simulation_LoadCompleteEvent;
            _simulation.LoadState(FileSystem.Current.AppDataDirectory);


        }

        private void _simulation_LoadCompleteEvent(object sender)
        {
            refreshMonsters();
            refreshRequests();
            refreshTeams();
        }

        private ISimulation _simulation;
        private ObservableCollection<Monster> _monsters = new ObservableCollection<Monster>();
        private ObservableCollection<Request> _requests = new ObservableCollection<Request>();
        private ObservableCollection<Rune> _runes = new ObservableCollection<Rune>();
        private ObservableCollection<Team> _teams = new ObservableCollection<Team>();
        private SortedList<Monster, Monster> _sortedMonsters = new SortedList<Monster, Monster>();
        private SortedList<Request, Request> _sortedRequests = new SortedList<Request, Request>();

        //Rune Maint
        public Rune GetNewRune()
        {
            return _simulation.GetNewRune();
        }

        public void UpdateRune(Rune rune)
        {
            _simulation.UpdateRune(rune);
            UpdateRuneList(_lastRuneType, _lastRuneSlot);
        }

        public void DeleteRune(Rune rune)
        {
            _simulation.DeleteRune(rune);
        }

        private RuneType _lastRuneType = RuneType.Energy;
        private RuneSlot _lastRuneSlot = RuneSlot.ONE;
        public void UpdateRuneList(RuneType runeType, RuneSlot runeSlot)
        {
            _lastRuneType = runeType;
            _lastRuneSlot = runeSlot;
            List<Rune> runes = _simulation.GetRunesByTypeSlot(runeType, runeSlot);
            _runes.Clear();
            foreach (Rune rune in runes)
            {
                _runes.Add(rune);
            }

        }



        public ObservableCollection<Rune> GetRunes()
        {
            return _runes;
        }

        //Monster Maint
        public Monster GetNewMonster()
        {
            return _simulation.GetNewMonster();
        }

        public void UpdateMonster(Monster monster)
        {
            _simulation.UpdateMonster(monster);
            refreshMonsters();
        }

        public void DeleteMonster(Monster monster)
        {

            _simulation.DeleteMonster(monster);
            refreshMonsters();
        }


        private void refreshMonsters()
        {
            _monsters.Clear();
            _sortedMonsters.Clear();
            List<Monster> monsters = _simulation.GetAllMonsters();
            foreach (Monster m in monsters)
            {
                _monsters.Add(m);
                _sortedMonsters.Add(m,m);
            }


        }

        public ObservableCollection<Monster> GetAllMonsters()
        {
            return _monsters;
        }

        public SortedList<Monster,Monster> GetSortedMonsters()
        {
            return _sortedMonsters;
        }

        // Request Maint

        public Request GetNewRequest()
        {
            return _simulation.GetNewRequest();
        }

        public void UpdateRequest(Request request)
        {
            _simulation.UpdateRequest(request);
            refreshRequests();
        }

        public void DeleteRequest(Request request)
        {
            _simulation.DeleteRequest(request);
            refreshRequests();
        }

        private void refreshRequests()
        {
            _requests.Clear();
            List<Request> requests = _simulation.GetAllRequests();
            foreach (Request request in requests)
                _requests.Add(request);
        }

        public ObservableCollection<Request> GetAllRequests()
        {
            return _requests;
        }


        //Recommendations
        public void Optimize(Request request)
        {
            _simulation.Optimize(request);
            DateTime time = DateTime.Now;
        }

        public List<RecommendedMonster> GetRecommendationPageForMonster(string monsterId, int pageNum, int pageSize, out int numPages)
        {
            return _simulation.GetRecommendationPageForMonster(monsterId, pageNum, pageSize, out numPages);
        }

        public void EquipRuneSet(string monsterId, RuneSet RuneSet)
        {
            _simulation.EquipRuneSet(monsterId, RuneSet);
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

        public Monster GetMonsterForId(string id)
        {
            return _simulation.GetMonsterForId(id);
        }

        public long CalcPerms(Request request)
        {
            return _simulation.CalculatePerms(request);
        }

        internal void UnequipAllMonster(Monster monster)
        {
            _simulation.UnequipRuneSet(monster.Id);
        }

        internal bool RequestHasRecommendations(Request request)
        {
            return _simulation.MonsterHasRecommendations(request.MonsterId);
        }

        internal int RecommendationCount(Request request)
        {
            int x = 0;
            if (request != null)
            {
                x = _simulation.RecommendationCount(request.MonsterId);
            }
            return x;
        }



        //Team Maint
        public Team GetNewTeam()
        {
            return _simulation.GetNewTeam();
        }

        public void UpdateTeam(Team team)
        {
            _simulation.UpdateTeam(team);
            refreshTeams();
        }

        public void DeleteTeam(Team team)
        {

            _simulation.DeleteTeam(team);
            refreshTeams();
        }


        private void refreshTeams()
        {
            _teams.Clear();
            List<Team> teams = _simulation.GetAllTeams();
            foreach (Team t in teams)
                _teams.Add(t);
        }

        public ObservableCollection<Team> GetAllTeams()
        {
            return _teams;
        }


    }
}
