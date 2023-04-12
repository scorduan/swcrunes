using System;
using SWCRunesLib;
using SWCRunes.Model;
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
        private ObservableCollection<ObservableRequest> _requests = new ObservableCollection<ObservableRequest>();
        private ObservableCollection<Rune> _runes = new ObservableCollection<Rune>();
        private ObservableCollection<ObservableTeam> _teams = new ObservableCollection<ObservableTeam>();
        private SortedSet<Monster> _sortedMonsters = new SortedSet<Monster>();
        private SortedSet<ObservableRequest> _sortedRequests = new SortedSet<ObservableRequest>();

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
            try
            {
                _monsters.Clear();
                _sortedMonsters.Clear();
                List<Monster> monsters = _simulation.GetAllMonsters();
                foreach (Monster m in monsters)
                {
                    _monsters.Add(m);
                    _sortedMonsters.Add(m);
                }
                _monsters.Sort();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                throw;
            }


        }

        public ObservableCollection<Monster> GetAllMonsters()
        {
            return _monsters;
        }

        public SortedSet<ObservableRequest> GetSortedRequests()
        {
            return _sortedRequests;
        }

        public SortedSet<Monster> GetSortedMonsters()
        {
            return _sortedMonsters;
        }

        // Request Maint

        public ObservableRequest GetNewRequest()
        {
            return new ObservableRequest(_simulation.GetNewRequest());
        }

        public void UpdateRequest(ObservableRequest request)
        {
            _simulation.UpdateRequest(request.Request);
            refreshRequests();
        }

        public void DeleteRequest(ObservableRequest request)
        {
            _simulation.DeleteRequest(request.Request);
            refreshRequests();
        }

        private void refreshRequests()
        {
            _requests.Clear();
            _sortedRequests.Clear();
            List<Request> requests = _simulation.GetAllRequests();
            foreach (Request request in requests)
            {
                ObservableRequest newReq = new ObservableRequest(request);
                _requests.Add(newReq);
                _sortedRequests.Add(newReq);
            }

            _requests.Sort();
                
        }

        public ObservableCollection<ObservableRequest> GetAllRequests()
        {
            return _requests;
        }


        //Recommendations
        public void Optimize(ObservableRequest request)
        {
            _simulation.Optimize(request.Request);
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

        public long CalcPerms(ObservableRequest request)
        {
            return _simulation.CalculatePerms(request.Request);
        }

        internal void UnequipAllMonster(Monster monster)
        {
            _simulation.UnequipRuneSet(monster.Id);
        }

        internal bool RequestHasRecommendations(ObservableRequest request)
        {
            return _simulation.MonsterHasRecommendations(request.Request.MonsterId);
        }

        internal int RecommendationCount(ObservableRequest request)
        {
            int x = 0;
            if (request != null)
            {
                x = _simulation.RecommendationCount(request.Request.MonsterId);
            }
            return x;
        }



        //Team Maint
        public ObservableTeam GetNewTeam()
        {
            return new ObservableTeam(_simulation.GetNewTeam());
        }

        public void UpdateTeam(ObservableTeam team)
        {
            _simulation.UpdateTeam(team.Team);
            refreshTeams();
        }

        public void DeleteTeam(ObservableTeam team)
        {

            _simulation.DeleteTeam((team.Team));
            refreshTeams();
        }


        private void refreshTeams()
        {
            _teams.Clear();
            List<Team> teams = _simulation.GetAllTeams();
            foreach (Team t in teams)
                _teams.Add(new ObservableTeam(t));
        }

        public ObservableCollection<ObservableTeam> GetAllTeams()
        {
            return _teams;
        }





    }

    public static class ObservableCollectionExtensions
    {
        public static void Sort<T>(this ObservableCollection<T> collection)
where T : IComparable<T>, IEquatable<T>
        {
            List<T> sorted = collection.OrderBy(x => x).ToList();

            int ptr = 0;
            while (ptr < sorted.Count - 1)
            {
                if (!collection[ptr].Equals(sorted[ptr]))
                {
                    int idx = search(collection, ptr + 1, sorted[ptr]);
                    collection.Move(idx, ptr);
                }

                ptr++;
            }
        }

        public static int search<T>(ObservableCollection<T> collection, int startIndex, T other)
        {
            for (int i = startIndex; i < collection.Count; i++)
            {
                if (other.Equals(collection[i]))
                    return i;
            }

            return -1; // decide how to handle error case
        }
    }
}
