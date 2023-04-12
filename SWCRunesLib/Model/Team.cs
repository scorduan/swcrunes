using System;
using System.Text.Json;
using static SWCRunesLib.Team;
using System.Text.Json;
using System.Text.Json.Serialization;
using SQLite;

namespace SWCRunesLib
{


    public class Team : ITeam
    {
        public Team()
        {
            Id = "";
        }
        public Team(string id)
        {
            Id = id;
        }

        [PrimaryKey]
        public string Id { get; set; }

        public string Job { get; set; } = "";

        public int Weight { get; set; } = 0;

        public string SoulMonsterId { get; set; } = "";


        private Monster? _soulMonster;
        [JsonIgnore]
        [Ignore]
        public Monster? SoulMonster
        {
            get { return _soulMonster; }
            set
            {
                try
                {
                    if (_soulMonster != null) _soulMonster.RemoveTeam(this);
                    _soulMonster = value;
                    if (_soulMonster != null) _soulMonster.AddTeam(this);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }
        }


        public string OtherMonster1Id { get; set; } = "";

        private Monster? _otherMonster1;
        [JsonIgnore]
        [Ignore]
        public Monster? OtherMonster1
        {
            get { return _otherMonster1; }
            set
            {
                if (_otherMonster1 != null) _otherMonster1.RemoveTeam(this);
                _otherMonster1 = value;
                if (_otherMonster1 != null) _otherMonster1.AddTeam(this);
            }
        }

        public string OtherMonster2Id { get; set; } = "";

        private Monster? _otherMonster2;
        [JsonIgnore]
        [Ignore]
        public Monster? OtherMonster2
        {
            get { return _otherMonster2; }
            set
            {
                if (_otherMonster2 != null) _otherMonster2.RemoveTeam(this);
                _otherMonster2 = value;
                if (_otherMonster2 != null) _otherMonster2.AddTeam(this);
            }
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize<Team>(this);

        }

        public static Team? FromJson(string text)
        {
            return JsonSerializer.Deserialize<Team>(text);
        }

    }



}

