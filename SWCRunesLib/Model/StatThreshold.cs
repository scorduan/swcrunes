using System;
using System.Text.Json;

namespace SWCRunesLib
{
	public class StatThreshold
	{
		public StatThreshold()
		{
		}

		public Stat CheckStat { get; set; }

		public int Threshold { get; set; }


        public string ToJson()
        {
            return JsonSerializer.Serialize<StatThreshold>(this);

        }

        public static StatThreshold FromJson(string text)
        {
            return JsonSerializer.Deserialize<StatThreshold>(text);
        }

    }
}

