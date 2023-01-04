namespace SWCRunesLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class RuneSerializer
{

    public static List<IRune> ReadRunesFromFile(string location)
    {
        List<IRune> runes = new List<IRune>();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            runes.Add(Rune.FromJson(line));
        }

        return runes;
    }

    public static List<IMonster> ReadMonstersFromFile(string location)
    {
        List<IMonster> monsters = new List<IMonster>();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            monsters.Add(Monster.FromJson(line));
        }

        return monsters;
    }

    public static List<IRequest> ReadRequestsFromFile(string location)
    {
        List<IRequest> requests = new List<IRequest>();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            requests.Add(Request.FromJson(line));
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

    public static async Task SaveRunes(List<IRune> runes, string location)
    {
        using StreamWriter file = new(location);

        foreach (Rune rune in runes)
        {

            await file.WriteLineAsync(rune.ToJson());

        }
    }

    public static async Task SaveMonsters(List<IMonster> monsters, string location)
    {
        using StreamWriter file = new(location);

        foreach (Monster monster in monsters)
        {

            await file.WriteLineAsync(monster.ToJson());

        }
    }


    public static async Task SaveRequests(List<IRequest> requests, string location)
    {
        using StreamWriter file = new(location);

        foreach (Request request in requests)
        {

            await file.WriteLineAsync(request.ToJson());

        }
    }

}


public class InterfaceConverter<M, I> : JsonConverter<I> where M : class, I
{
    public override I Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<M>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, I value, JsonSerializerOptions options) => JsonSerializer.Serialize<I>(writer, value, options);
}