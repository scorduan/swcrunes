namespace SWCRunesLib;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SQLite;
using SQLitePCL;


public class Request
{

    public string MonsterId { get; set; }

    public string MonsterName { get; set; }


    public string PrimaryAttribute { get; set; }

    public string SecondaryAttribute { get; set; }

    public string TertiaryAttribute { get; set; }

    public RuneType RestrictSetOne { get; set; } = RuneType.Null;

    public RuneType RestrictSetTwo { get; set; } = RuneType.Null;

    public RuneType RestrictSetThree { get; set; } = RuneType.Null;

    [Ignore]
    public List<string> FocusStats { get; set; } = new List<string>();

    public string FocusStatString
        {
        get
        {
            return string.Join(",", FocusStats.ToArray());
        }
        set
        {
            FocusStats.Clear();
            FocusStats.AddRange(value.Split(","));
        }
        }


    public Request()
    {

        MonsterId = "";
        MonsterName = "";
        PrimaryAttribute = "ATK";
        SecondaryAttribute = "DEF";
        TertiaryAttribute = "HP";
    }


    public Request(string id="")
    {
        Id = id;

        MonsterId = "";
        MonsterName = "";
        PrimaryAttribute = "ATK";
        SecondaryAttribute = "DEF";
        TertiaryAttribute = "HP";
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize<Request>(this);

    }

    public static Request? FromJson(string text)
    {
        return JsonSerializer.Deserialize<Request>(text);
    }

    [PrimaryKey]
    public string Id { get; set; }

}

public class RequestStorage
{
    public List<Request> Requests = new List<Request>();

} 