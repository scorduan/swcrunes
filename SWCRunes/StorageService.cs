using System;
using SWCRunesLib;
using System.IO;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace SWCRunes
{
    public class StorageService
    {
        public StorageService()
        {
            Console.WriteLine(FileSystem.Current.AppDataDirectory);
            monstersFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "monsters.data");
            runesFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "runes.data");
            requestsFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "requests.data");


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

        private readonly RuneStorage _runeStore;

        private readonly MonsterStorage _monStore;

        private readonly RequestStorage _reqStore;

        private string runesFile;
        private string monstersFile;
        private string requestsFile;


        public RuneStorage RuneStore { get => _runeStore;  }

        public MonsterStorage MonStore { get => _monStore; }

        public RequestStorage ReqStore { get => _reqStore; }


        public ObservableCollection<Rune> GetRunes()
        {
            ObservableCollection<Rune> runes = new ObservableCollection<Rune>();
            foreach (Rune r in _runeStore.Runes)
            {
                runes.Add(r);
            }

            return runes;
        }

        public void SaveRunes(ObservableCollection<Rune> runes)
        {
            _runeStore.Runes.Clear();
            foreach (Rune r in runes)
            {
                _runeStore.Runes.Add(r);
            }
            RuneSerializer.SaveRunes(_runeStore.Runes, runesFile);
        }

        public ObservableCollection<Monster> GetMonsters()
        {
            ObservableCollection<Monster> monsters = new ObservableCollection<Monster>();
            foreach (Monster m in _monStore.Monsters)
            {
                monsters.Add(m);
            }

            return monsters;
        }

        public void SaveMonsters(ObservableCollection<Monster> monsters)
        {
            _monStore.Monsters.Clear();
            foreach (Monster monster in monsters)
            {
                _monStore.Monsters.Add(monster);
            }
            RuneSerializer.SaveMonsters(_monStore.Monsters, monstersFile);
        }
    }
}

