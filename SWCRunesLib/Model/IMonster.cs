namespace SWCRunesLib
{
    public interface IMonster
    {
        string Name { get; set; }
        Request? Request { get; set; }
        List<Team> Teams { get; }
        int Weight { get; }
        RuneSet Runes { get; set; }
        int BaseATK { get; set; }
        int BaseATKBoost { get; set; }
        int BaseDEF { get; set; }
        int BaseDEFBoost { get; set; }
        int BaseHP { get; set; }
        int BaseHPBoost { get; set; }
        int BaseSPD { get; set; }
        int BaseCR { get; set; }
        int BaseCD { get; set; }
        int BaseACC { get; set; }
        int BaseRES { get; set; }
        int BaseRESBoost { get; set; }
        int BasePR { get; set; }
        int BaseEV { get; set; }
        int BaseEVBoost { get; set; }
        int ATK { get; }
        int ATKBoost { get; }
        int DEF { get; }
        int DEFBoost { get; }
        int HP { get; }
        int HPBoost { get; }
        int SPD { get; }
        int SPDBoost { get; }
        int CR { get; }
        int CRBoost { get; }
        int CD { get; }
        int CDBoost { get; }
        int ACC { get; }
        int ACCBoost { get; }
        int RES { get; }
        int RESBoost { get; }
        int PR { get; }
        int PRBoost { get; }
        int EV { get; }
        int EVBoost { get; }
        Dictionary<Stat, int> Stats { get; set; }
        string Id { get; set; }
        int EffectiveHP { get; }
        int Survival { get; }
        int Damage { get; }
        int BasicDamage { get; }
        int DEFDamageR { get; }
        int HPDamageR { get; }

        void AddTeam(Team team);
        Rune? EquipOne(Rune rune);
        RuneSet EquipSet(RuneSet RuneSet, bool isTemporary = false);
        void RemoveTeam(Team team);
        RuneSet UnequipAll();
        Rune? UnequipSlot(RuneSlot slot);
    }
}