namespace SWCRunesLib;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Recommendation
{
    public string MonsterName { get; set; }

    public List<Monster> RecommendedSetup  { get; set; }

    public Request InitiatingRequest { get; set; }
    public string ToJson()
    {
        return JsonSerializer.Serialize<Recommendation>(this);

    }

    public static Recommendation FromJson(string text)
    {
        return JsonSerializer.Deserialize<Recommendation>(text);
    }

}

public class RecommendationStorage
{
    public List<Recommendation> Requests = new List<Recommendation>();

    public string ToJson()
    {
        return JsonSerializer.Serialize<RecommendationStorage>(this);

    }

}