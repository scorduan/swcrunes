namespace SWCRunesLib;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Request
{
    public string MonsterName { get; set; }

    public string PrimaryAttribute { get; set; }

    public string SecondaryAttribute { get; set; }

    public string TertiaryAttribute { get; set; }

    public string AcceptableSets { get; set; }
    public string ToJson()
    {
        return JsonSerializer.Serialize<Request>(this);

    }

    public static Request FromJson(string text)
    {
        return JsonSerializer.Deserialize<Request>(text);
    }

}

public class RequestStorage
{
    public List<Request> Requests = new List<Request>();

}