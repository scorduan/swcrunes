namespace SWCRunesLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RuneSerializer
{

    public static RuneStorage ReadRunesFromFile(string location)
    {
        RuneStorage runes = new RuneStorage();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            runes.Runes.Add(Rune.FromJson(line));
        }

        return runes;
    }

    public static MonsterStorage ReadMonstersFromFile(string location)
    {
        MonsterStorage monsters = new MonsterStorage();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            monsters.Monsters.Add(Monster.FromJson(line));
        }

        return monsters;
    }

    public static RequestStorage ReadRequestsFromFile(string location)
    {
        RequestStorage requests = new RequestStorage();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            requests.Requests.Add(Request.FromJson(line));
        }

        return requests;
    }
    
    public static void WriteRecommendations(List<Recommendation> recoms, string location)
    {
        foreach (Recommendation rec in recoms)
        {
            Console.WriteLine(rec.ToJson());
        }
    }   
    
}