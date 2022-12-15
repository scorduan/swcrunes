using System;
using SWCRunesLib;
using System.IO;
using System.Diagnostics;

namespace SWCRunes
{
    public class StorageService
    {
        public StorageService()
        {
            Console.WriteLine(FileSystem.Current.AppDataDirectory);
            string monstersFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "monsters.data");
            string runesFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "runes.data");
            string requestsFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "requests.data");

            //string monstersFile = System.IO.Path.Combine("~", "monsters.data");
            //string runesFile = System.IO.Path.Combine("~", "runes.data");
            //string requestsFile = System.IO.Path.Combine("~", "requests.data");

            if (!File.Exists(monstersFile))
            {
                File.Create(monstersFile);
            }

            if (!File.Exists(runesFile))
            {
                File.Create(runesFile);
            }

            if (!File.Exists(requestsFile))
            {
                File.Create(requestsFile);
            }



            _monStore = RuneSerializer.ReadMonstersFromFile(monstersFile);
            _runeStore = RuneSerializer.ReadRunesFromFile(runesFile);
            _reqStore = RuneSerializer.ReadRequestsFromFile(requestsFile);
        }

        private RuneStorage _runeStore;

        private MonsterStorage _monStore;

        private RequestStorage _reqStore;


        public RuneStorage RuneStore { get => _runeStore;  }

        public MonsterStorage MonStore { get => _monStore; }

        public RequestStorage ReqStore { get => _reqStore; }

    }
}

