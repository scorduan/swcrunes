namespace SWCRunesLib;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public interface IRequest
{
    public string Id { get; set; }

    public string MonsterId { get; set; }

    public string PrimaryAttribute { get; set; }

    public string SecondaryAttribute { get; set; }

    public string TertiaryAttribute { get; set; }

    public RuneType RestrictSetOne { get; set; }

    public RuneType RestrictSetTwo { get; set; }

    public RuneType RestrictSetThree { get; set; }

    public List<string> FocusStats { get; set; } 
}

public class Request :IRequest
{

    public string MonsterId { get; set; }

    public string PrimaryAttribute { get; set; }

    public string SecondaryAttribute { get; set; }

    public string TertiaryAttribute { get; set; }

    public RuneType RestrictSetOne { get; set; } = RuneType.Null;

    public RuneType RestrictSetTwo { get; set; } = RuneType.Null;

    public RuneType RestrictSetThree { get; set; } = RuneType.Null;

    public List<string> FocusStats { get; set; } = new List<string>();

    public Request(string id="")
    {
        Id = id;

        MonsterId = "";
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

    
    public string Id { get; set; }

}

public class RequestStorage
{
    public List<Request> Requests = new List<Request>();

} 