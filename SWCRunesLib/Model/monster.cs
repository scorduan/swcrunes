namespace SWCRunesLib;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using SQLite;

[Table("Monster")]
public class Monster :IComparable<Monster>
{

    public Monster()
    {
        Id = "";
    }


    [JsonConstructor]
    public Monster(string id = "")
    {
        Id = id;

    }





    public string Name { get; set; } = "";

    [JsonIgnore]


    public List<Team> Teams { get; private set; } = new List<Team>();

    public void AddTeam(Team team)
    {
        Teams.Add(team);
        refreshWeight();
    }

    private void refreshWeight()
    {
        Weight = 0;
        foreach (Team team in Teams)
        {
            Weight = Weight + team.Weight;
        }
    }

    public void RemoveTeam(Team team)
    {
        Teams.Remove(team);
        refreshWeight();
    }

    

    public int Weight { get; private set; } = 0;

    [Ignore]
    public RuneSet Runes { get; set; } = new RuneSet();

    private int _baseATK;
    public int BaseATK
    {
        get => _baseATK;
        set
        {
            _baseATK = value;
            UpdateStats();
        }
    }

    private int _baseATKBoost;
    public int BaseATKBoost
    {
        get => _baseATKBoost;
        set
        {
            _baseATKBoost = value;
            UpdateStats();
        }
    }

    private int _baseDEF;
    public int BaseDEF
    {
        get => _baseDEF;
        set
        {
            _baseDEF = value;
            UpdateStats();
        }
    }

    private int _baseDEFBoost;
    public int BaseDEFBoost
    {
        get => _baseDEFBoost;
        set
        {
            _baseDEFBoost = value;
            UpdateStats();
        }
    }

    private int _baseHP;
    public int BaseHP
    {
        get => _baseHP;
        set
        {
            _baseHP = value;
            UpdateStats();
        }
    }

    private int _baseHPBoost;
    public int BaseHPBoost
    {
        get => _baseHPBoost;
        set
        {
            _baseHPBoost = value;
            UpdateStats();
        }
    }

    private int _baseSPD;
    public int BaseSPD
    {
        get => _baseSPD;
        set
        {
            _baseSPD = value;
            UpdateStats();
        }
    }

    //TODO: Base CD Boost


    private int _baseCR;
    public int BaseCR
    {
        get => _baseCR;
        set
        {
            _baseCR = value;
            UpdateStats();
        }
    }

    private int _baseCD;
    public int BaseCD
    {
        get => _baseCD;
        set
        {
            _baseCD = value;
            UpdateStats();
        }
    }

    private int _baseACC;
    public int BaseACC
    {
        get => _baseACC;
        set
        {
            _baseACC = value;
            UpdateStats();
        }
    }

    private int _baseRES;
    public int BaseRES
    {
        get => _baseRES;
        set
        {
            _baseRES = value;
            UpdateStats();
        }
    }

    private int _baseRESBoost;
    public int BaseRESBoost
    {
        get => _baseRESBoost;
        set
        {
            _baseRESBoost = value;
            UpdateStats();
        }
    }

    private int _basePR;
    public int BasePR
    {
        get => _basePR;
        set
        {
            _basePR = value;
            UpdateStats();
        }
    }

    private int _baseEV;
    public int BaseEV
    {
        get => _baseEV;
        set
        {
            _baseEV = value;
            UpdateStats();
        }
    }

    private int _baseEVBoost;
    public int BaseEVBoost
    {
        get => _baseEVBoost;
        set
        {
            _baseEVBoost = value;
            UpdateStats();
        }
    }


    public int ATK { get; private set; }
    public int ATKBoost { get; private set; }

    public int DEF { get; private set; }
    public int DEFBoost { get; private set; }

    public int HP { get; private set; }
    public int HPBoost { get; private set; }

    public int SPD { get; private set; }
    public int SPDBoost { get; private set; }

    public int CR { get; private set; }
    public int CRBoost { get; private set; }
    public int CD { get; private set; }
    public int CDBoost { get; private set; }

    public int ACC { get; private set; }
    public int ACCBoost { get; private set; }
    public int RES { get; private set; }
    public int RESBoost { get; private set; }

    public int PR { get; private set; }
    public int PRBoost { get; private set; }
    public int EV { get; private set; }
    public int EVBoost { get; private set; }



    [PrimaryKey]
    public string Id { get; set; }

    public int EffectiveHP
    {
        get;

        private set;
    }
    public int Survival
    {

        get;

        private set;
    }

    public int Damage
    {
        get;

        private set;
    }

    public int BasicDamage
    {
        get;

        private set;
    }

    public int DEFDamageR
    {
        get;

        private set;
    }

    public int HPDamageR
    {
        get;

        private set;
    }

    private Dictionary<RuneType, int> _setCount = new Dictionary<RuneType, int>();



    private void updateSetCounts()
    {
        _setCount[RuneType.Null] = 0;
        _setCount[RuneType.Energy] = 0;
        _setCount[RuneType.Guard] = 0;
        _setCount[RuneType.Blade] = 0;
        _setCount[RuneType.Rage] = 0;
        _setCount[RuneType.Fatal] = 0;
        _setCount[RuneType.Swift] = 0;
        _setCount[RuneType.Focus] = 0;
        _setCount[RuneType.Endure] = 0;
        _setCount[RuneType.Foresight] = 0;
        _setCount[RuneType.Assemble] = 0;

        if (Runes != null)
        {
            if (Runes.RuneOne != null) _setCount[Runes.RuneOne.Type]++;
            if (Runes.RuneTwo != null) _setCount[Runes.RuneTwo.Type]++;
            if (Runes.RuneThree != null) _setCount[Runes.RuneThree.Type]++;
            if (Runes.RuneFour != null) _setCount[Runes.RuneFour.Type]++;
            if (Runes.RuneFive != null) _setCount[Runes.RuneFive.Type]++;
            if (Runes.RuneSix != null) _setCount[Runes.RuneSix.Type]++;
        }
    }

    public void UpdateStats()
    {



        updateSetCounts();

        int numEnergySets = (int)Math.Floor((double)_setCount[RuneType.Energy] / 2d);
        int numGuardSets = (int)Math.Floor((double)_setCount[RuneType.Guard] / 2d);
        int numBladeSets = (int)Math.Floor((double)_setCount[RuneType.Blade] / 2d);
        int numRageSets = (int)Math.Floor((double)_setCount[RuneType.Rage] / 4d);
        int numFatalSets = (int)Math.Floor((double)_setCount[RuneType.Fatal] / 4d);
        int numSwiftSets = (int)Math.Floor((double)_setCount[RuneType.Swift] / 4d);
        int numFocusSets = (int)Math.Floor((double)_setCount[RuneType.Focus] / 2d);
        int numEndureSets = (int)Math.Floor((double)_setCount[RuneType.Endure] / 2d);
        int numForesightSets = (int)Math.Floor((double)_setCount[RuneType.Foresight] / 2d);
        int numAssembleSets = (int)Math.Floor((double)_setCount[RuneType.Assemble] / 2d);

        Rune runeOne = new Rune();
        Rune runeTwo = new Rune();
        Rune runeThree = new Rune();
        Rune runeFour = new Rune();
        Rune runeFive = new Rune();
        Rune runeSix = new Rune();


        if (Runes != null)
        {
            if (Runes.RuneOne != null) runeOne = Runes.RuneOne;
            if (Runes.RuneTwo != null) runeTwo = Runes.RuneTwo;
            if (Runes.RuneThree != null) runeThree = Runes.RuneThree;
            if (Runes.RuneFour != null) runeFour = Runes.RuneFour;
            if (Runes.RuneFive != null) runeFive = Runes.RuneFive;
            if (Runes.RuneSix != null) runeSix = Runes.RuneSix;
        }



        int atkp = runeOne.ATKP + runeTwo.ATKP + runeThree.ATKP + runeFour.ATKP + runeFive.ATKP + runeSix.ATKP;
        int atkf = runeOne.ATKF + runeTwo.ATKF + runeThree.ATKF + runeFour.ATKF + runeFive.ATKF + runeSix.ATKF;

        int defp = runeOne.DEFP + runeTwo.DEFP + runeThree.DEFP + runeFour.DEFP + runeFive.DEFP + runeSix.DEFP + (numGuardSets * 150);
        int deff = runeOne.DEFF + runeTwo.DEFF + runeThree.DEFF + runeFour.DEFF + runeFive.DEFF + runeSix.DEFF;

        int hpp = runeOne.HPP + runeTwo.HPP + runeThree.HPP + runeFour.HPP + runeFive.HPP + runeSix.HPP + (numEnergySets * 150);
        int hpf = runeOne.HPF + runeTwo.HPF + runeThree.HPF + runeFour.HPF + runeFive.HPF + runeSix.HPF;

        ATKBoost = calcBonus(BaseATK - BaseATKBoost, atkp, atkf);
        ATK = BaseATK + ATKBoost;
        DEFBoost = calcBonus(BaseDEF - BaseDEFBoost, defp, deff);
        DEF = BaseDEF + DEFBoost;
        HPBoost = calcBonus(BaseHP - BaseHPBoost, hpp, hpf);
        HP = BaseHP + HPBoost;

        SPDBoost = runeOne.SPD + runeTwo.SPD + runeThree.SPD + runeFour.SPD + runeFive.SPD + runeSix.SPD;
        SPD = BaseSPD + SPDBoost;

        CRBoost = runeOne.CR + runeTwo.CR + runeThree.CR + runeFour.CR + runeFive.CR + runeSix.CR + (numBladeSets * 120);
        CR = BaseCR + CRBoost;

        CDBoost = runeOne.CD + runeTwo.CD + runeThree.CD + runeFour.CD + runeFive.CD + runeSix.CD + (numRageSets * 400);
        CD = BaseCD + CDBoost;

        ACCBoost = runeOne.ACC + runeTwo.ACC + runeThree.ACC + runeFour.ACC + runeFive.ACC + runeSix.ACC + (numFocusSets * 150);
        ACC = BaseACC + ACCBoost;


        RESBoost = runeOne.RES + runeTwo.RES + runeThree.RES + runeFour.RES + runeFive.RES + runeSix.RES + (numEndureSets * 150);
        RES = BaseRES + RESBoost;

        PRBoost = runeOne.PR + runeTwo.PR + runeThree.PR + runeFour.PR + runeFive.PR + runeSix.PR + (numAssembleSets * 150);
        PR = BasePR + PRBoost;

        EVBoost = runeOne.EV + runeTwo.EV + runeThree.EV + runeFour.EV + runeFive.EV + runeSix.EV + (numForesightSets * 150);
        EV = BaseEV + EVBoost;

        Damage = CalcDamage();
        EffectiveHP = CalcEffectiveHP();
        Survival = CalcSurvival();
        BasicDamage = SPD * Damage;
        DEFDamageR = CalcDEFDamageR();
        HPDamageR = CalcHPDamageR();

    }

    //TODO: Add debug chance stats, after generalizing stats
    /*
    private int CalcDebuffChance(int resist)
    {
        return 0;
    }

    private int CalcResistChance(int accuracy)
    {
        return 0;
    }
    */
    private int CalcDamage()
    {
        int damage = ATK;
        return damage + DamageBonusCalc(damage);
    }

    private int CalcDEFDamageR()
    {
        int damage = ATK / 2 + DEF;

        return damage + DamageBonusCalc(damage);
    }

    private int CalcHPDamageR()
    {
        int damage = HP/5;

        return damage + DamageBonusCalc(damage);
    }

    private int DamageBonusCalc(int baseDamage)
    {
        double dblCR = (double)CR / 1000d;
        double dblCD = (double)CD / 1000d;
        int bonusDamage = (int)Math.Floor((double)baseDamage * dblCR * dblCD);
        return bonusDamage;
    }

    private int CalcSurvival()
    {

        // Assuming an enemiy with 80 precision (800),
        // we need to subract out the enemy precision to get an
        // effective EV
        // This sets up a base threshold of 80 before EV becomes super effective
        double effectiveEV = Math.Max(EV - 800, 0d);

        // Assume the enemy is doing 690 damage raw... (unskilled Basic attack at 1000 ATK)
        double rawDamage = 690;

        // Converte from the evasion (percentage of misses) to a percentage of attacks that hit
        double unevadedPerc = (1000d - effectiveEV) / 1000d;

        // Calculate the number of attacks that it would take for the enemy's basic attack to kill 
        int numAttacksThrough = (int)Math.Ceiling(EffectiveHP / (unevadedPerc * rawDamage));

        //(1-EV)*numAttacksThrough*rawDamage=EHP
        //numAttacksThrough=EHP/rawDamage*(1-EV)

        return numAttacksThrough;
    }
    private int CalcEffectiveHP()
    {
        double dblHP = (double)HP;
        double dblDEF = (double)DEF;
        double effectiveHP = dblHP * (1140d + (dblDEF * 3.5d)) / 1000d;

        return (int)effectiveHP;
    }


    public int calcBonus(int baseVal, float perc, int flat)
    {
        return calcPercBonus(baseVal, perc) + flat;
    }
    public int calcPercBonus(int baseVal, float perc)
    {
        double percDbl = perc / 1000d;
        double percBoost = Math.Round((double)baseVal * percDbl);
        return (int)percBoost;
    }



    public string ToJson()
    {
        return JsonSerializer.Serialize<Monster>(this);

    }

    public static Monster FromJson(string text)
    {
        return JsonSerializer.Deserialize<Monster>(text);
    }

    public RuneSet EquipSet(RuneSet RuneSet, bool isTemporary = false)
    {
        RuneSet oldRunes = Runes;
        if (!isTemporary)
        {
            if (Runes != null)
            {
                if (Runes.RuneOne != null)
                {
                    Runes.RuneOne.EquippedOn = "";
                    Runes.RuneOne.EquippedMonster = null;
                }
                if (Runes.RuneTwo != null)
                {
                    Runes.RuneTwo.EquippedOn = "";
                    Runes.RuneTwo.EquippedMonster = null;
                }
                if (Runes.RuneThree != null)
                {
                    Runes.RuneThree.EquippedOn = "";
                    Runes.RuneThree.EquippedMonster = null;
                }
                if (Runes.RuneFour != null)
                {
                    Runes.RuneFour.EquippedOn = "";
                    Runes.RuneFour.EquippedMonster = null;
                }
                if (Runes.RuneFive != null)
                {
                    Runes.RuneFive.EquippedOn = "";
                    Runes.RuneFive.EquippedMonster = null;
                }
                if (Runes.RuneSix != null)
                {
                    Runes.RuneSix.EquippedOn = "";
                    Runes.RuneSix.EquippedMonster = null;
                }
            }
        }
        
        Runes = RuneSet;
        if (!isTemporary)
        {
            if (Runes.RuneOne != null)
            {
                Runes.RuneOne.EquippedOn = this.Id;
                Runes.RuneOne.EquippedMonster = this;
            }
            if (Runes.RuneTwo != null)
            {
                Runes.RuneTwo.EquippedOn = this.Id;
                Runes.RuneTwo.EquippedMonster = this;
            }
            if (Runes.RuneThree != null)
            {
                Runes.RuneThree.EquippedOn = this.Id;
                Runes.RuneThree.EquippedMonster = this;
            }
            if (Runes.RuneFour != null)
            {
                Runes.RuneFour.EquippedOn = this.Id;
                Runes.RuneFour.EquippedMonster = this;
            }
            if (Runes.RuneFive != null)
            {
                Runes.RuneFive.EquippedOn = this.Id;
                Runes.RuneFive.EquippedMonster = this;
            }
            if (Runes.RuneSix != null)
            {
                Runes.RuneSix.EquippedOn = this.Id;
                Runes.RuneSix.EquippedMonster = this;
            }
        }
        UpdateStats();
        return oldRunes;
    }

    public Rune? UnequipSlot(RuneSlot slot)
    {
        Rune oldRune = null;
        if (slot == RuneSlot.ONE)
        {
            if (Runes.RuneOne != null)
            {
                oldRune = Runes.RuneOne;
                Runes.RuneOne.EquippedOn = "";
                Runes.RuneOne.EquippedMonster = null;
            }
            Runes.RuneOne = null;
        }
        if (slot == RuneSlot.TWO)
        {
            if (Runes.RuneTwo != null)
            {
                oldRune = Runes.RuneTwo;
                Runes.RuneTwo.EquippedOn = "";
                Runes.RuneTwo.EquippedMonster = null;
            }
            Runes.RuneTwo = null;
        }
        if (slot == RuneSlot.THREE)
        {
            if (Runes.RuneThree != null)
            {
                oldRune = Runes.RuneThree;
                Runes.RuneThree.EquippedOn = "";
                Runes.RuneThree.EquippedMonster = null;
            }
            Runes.RuneThree = null;
        }
        if (slot == RuneSlot.FOUR)
        {
            if (Runes.RuneFour != null)
            {
                oldRune = Runes.RuneFour;
                Runes.RuneFour.EquippedOn = "";
                Runes.RuneFour.EquippedMonster = null;
            }
            Runes.RuneFour = null;
        }
        if (slot == RuneSlot.FIVE)
        {
            if (Runes.RuneFive != null)
            {
                oldRune = Runes.RuneFive;
                Runes.RuneFive.EquippedOn = "";
                Runes.RuneFive.EquippedMonster = null;
            }
            Runes.RuneFive = null;
        }
        if (slot == RuneSlot.SIX)
        {
            if (Runes.RuneSix != null)
            {
                oldRune = Runes.RuneSix;
                Runes.RuneSix.EquippedOn = "";
                Runes.RuneSix.EquippedMonster = null;
            }
            Runes.RuneSix = null;
        }
        UpdateStats();

        return oldRune;
    }

    public RuneSet UnequipAll()
    {
        RuneSet oldRunes = new RuneSet();
        oldRunes.RuneOne= UnequipSlot(RuneSlot.ONE);
        oldRunes.RuneTwo = UnequipSlot(RuneSlot.TWO);
        oldRunes.RuneThree = UnequipSlot(RuneSlot.THREE);
        oldRunes.RuneFour = UnequipSlot(RuneSlot.FOUR);
        oldRunes.RuneFive = UnequipSlot(RuneSlot.FIVE);
        oldRunes.RuneSix = UnequipSlot(RuneSlot.SIX);

        return oldRunes;
    }

    public Rune? EquipOne(Rune rune)
    {
        Rune? oldRune = null;
        if (rune.Slot == RuneSlot.ONE)
        {
            if (Runes.RuneOne != null) Runes.RuneOne.EquippedOn = "";
            oldRune = Runes.RuneOne;
            Runes.RuneOne = rune;
            Runes.RuneOne.EquippedOn = this.Id;
            Runes.RuneOne.EquippedMonster = this;
        }

        if (rune.Slot == RuneSlot.TWO)
        {
            if (Runes.RuneTwo != null) Runes.RuneTwo.EquippedOn = "";
            oldRune = Runes.RuneOne;
            Runes.RuneTwo = rune;
            Runes.RuneTwo.EquippedOn = this.Id;
            Runes.RuneTwo.EquippedMonster = this;
        }

        if (rune.Slot == RuneSlot.THREE)
        {
            if (Runes.RuneThree != null) Runes.RuneThree.EquippedOn = "";
            oldRune = Runes.RuneThree;
            Runes.RuneThree = rune;
            Runes.RuneThree.EquippedOn = this.Id;
            Runes.RuneThree.EquippedMonster = this;
        }

        if (rune.Slot == RuneSlot.FOUR)
        {
            if (Runes.RuneFour != null) Runes.RuneFour.EquippedOn = "";
            oldRune = Runes.RuneFour;
            Runes.RuneFour = rune;
            Runes.RuneFour.EquippedOn = this.Id;
            Runes.RuneFour.EquippedMonster = this;
        }

        if (rune.Slot == RuneSlot.FIVE)
        {
            if (Runes.RuneFive != null) Runes.RuneFive.EquippedOn = "";
            oldRune = Runes.RuneFive;
            Runes.RuneFive = rune;
            Runes.RuneFive.EquippedOn = this.Id;
            Runes.RuneFive.EquippedMonster = this;
        }

        if (rune.Slot == RuneSlot.SIX)
        {
            if (Runes.RuneSix != null) Runes.RuneSix.EquippedOn = "";
            oldRune = Runes.RuneSix;
            Runes.RuneSix = rune;
            Runes.RuneSix.EquippedOn = this.Id;
            Runes.RuneSix.EquippedMonster = this;
        }
        UpdateStats();
        return oldRune;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }

    public int CompareTo(Monster? other)
    {
        return this.Weight.CompareTo(other?.Weight) * -1;
    }
}

public class MonsterStorage
{
    public List<Monster> Monsters = new List<Monster>();

}

