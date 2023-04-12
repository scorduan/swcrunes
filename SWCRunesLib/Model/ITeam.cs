namespace SWCRunesLib
{
    public interface ITeam
    {
        string Id { get; set; }
        string Job { get; set; }
        int Weight { get; set; }
        string SoulMonsterId { get; set; }
        Monster? SoulMonster { get; set; }
        string OtherMonster1Id { get; set; }
        Monster? OtherMonster1 { get; set; }
        string OtherMonster2Id { get; set; }
        Monster? OtherMonster2 { get; set; }
    }
}