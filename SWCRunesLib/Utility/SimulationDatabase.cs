using System;
using System.Collections.Generic;
using SQLite;

namespace SWCRunesLib
{

    internal class SimulationDatabase
    {
        SQLiteAsyncConnection? Database;

        public SimulationDatabase(string path)
        {
            databasePath = Path.Combine(path, Constants.DatabaseFilename);
        }

        private string databasePath;
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(databasePath, Constants.Flags);
            try
            {
                var result = await Database.CreateTableAsync<Rune>();
                result = await Database.CreateTableAsync<Monster>();
                result = await Database.CreateTableAsync<Request>();
                result = await Database.CreateTableAsync<Team>();

                
            }
            catch (Exception e)
            {

            }
        }

        internal async Task <List<Rune>> GetAllRunes()
        {
            await Init();
            Task<List<Rune>> myTask = Database.Table<Rune>().ToListAsync();
            myTask.Wait();

            return myTask.Result;
        }

        internal async Task <List<Monster> >GetAllMonsters()
        {
            await Init();
            Task<List<Monster>> myTask = Database.Table<Monster>().ToListAsync();
            await myTask;
            
            return myTask.Result;
        }

        internal async Task <List<Request>> GetAllRequests()
        {
            await Init();
            Task<List<Request>> myTask = Database.Table<Request>().ToListAsync();
            await myTask;

            return myTask.Result;
        }

        internal async Task <List<Team>> GetAllTeams()
        {
            await Init();
            Task<List<Team>> myTask = Database.Table<Team>().ToListAsync();
            await myTask;

            return myTask.Result;
        }

        internal async Task<int> SaveMonster(Monster monster)
        {

            await Init();

            return await Database.InsertOrReplaceAsync(monster);
        }

        internal async Task<int> DeleteMonster(Monster monster)
        {
            await Init();
            return await Database.DeleteAsync(monster);

        }

            internal async Task<int> SaveRune(Rune rune)
        {
            await Init();
            return await Database.InsertOrReplaceAsync(rune);
           
        }

        internal async Task<int> DeleteRune(Rune rune)
        {
            await Init();
            Task<int> result = Database.DeleteAsync(rune);
            await result;
            return result.Result;
        }

        internal async Task<int> SaveRequest(Request request)
        {
            await Init();
            Task<int> result = Database.InsertOrReplaceAsync(request);
            await result;
            return result.Result;
        }

        internal async Task<int> DeleteRequest(Request request)
        {
            await Init();
            Task<int> result = Database.DeleteAsync(request);
            await result;
            return result.Result;
        }

        internal async Task<int> SaveTeam(Team team)
        {
            await Init();
            Task<int> result = Database.InsertOrReplaceAsync(team);
            await result;
            return result.Result;
        }

        internal async Task<int> DeleteTeam(Team team)
        {
            await Init();
            Task<int> result = Database.DeleteAsync(team);
            await result;
            return result.Result;
        }
    }
}

