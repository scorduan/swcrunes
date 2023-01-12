namespace SWCRunesLib;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class RuneSerializer
{

    public static List<Rune> ReadRunesFromFile(string location)
    {
        List<Rune> runes = new List<Rune>();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            runes.Add(Rune.FromJson(line));
        }

        return runes;
    }

    public static List<Team> ReadTeamsFromFile(string location)
    {
        List<Team> teams = new List<Team>();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            teams.Add(Team.FromJson(line));
        }

        return teams;
    }

    public static List<Monster> ReadMonstersFromFile(string location)
    {
        List<Monster> monsters = new List<Monster>();
        foreach (string line in System.IO.File.ReadLines(location))
        {
            monsters.Add(Monster.FromJson(line));
        }

        return monsters;
    }

    public static List<Request> ReadRequestsFromFile(string location)
    {
        List<Request> requests = new List<Request>();
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

    public static async Task SaveRunes(List<Rune> runes, string location)
    {
        using StreamWriter file = new(location);

        foreach (Rune rune in runes)
        {

            await file.WriteLineAsync(rune.ToJson());

        }
    }

    public static async Task SaveMonsters(List<Monster> monsters, string location)
    {
        using StreamWriter file = new(location);

        foreach (Monster monster in monsters)
        {

            await file.WriteLineAsync(monster.ToJson());

        }
    }


    public static async Task SaveRequests(List<Request> requests, string location)
    {
        using StreamWriter file = new(location);

        foreach (Request request in requests)
        {

            await file.WriteLineAsync(request.ToJson());

        }
    }

    public static async Task SaveTeams(List<Team> teams, string location)
    {
        using StreamWriter file = new(location);

        foreach (Team team in teams)
        {

            await file.WriteLineAsync(team.ToJson());

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