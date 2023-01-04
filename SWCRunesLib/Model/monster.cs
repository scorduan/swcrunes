namespace SWCRunesLib;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

public interface IMonster : ICloneable
{
    public string Id { get; set; }

    public IRuneSet Runes { get; set; }

    public void EquipSet(IRuneSet IRuneSet);

    public void UnequipSlot(RuneSlot slot);

    public void UnequipAll();

    public void EquipOne(IRune rune);


    public string Name
    {
        get; set;
    }

    public int ATK { get; set; }

    public int ATKBoost { get; set; }

    public int DEFBoost { get; set; }

    public int DEF { get; set; }

    public int HP { get; set; }

    public int HPBoost { get; set; }

    public int SPD { get; set; }

    public int CR { get; set; }
    public int CD { get; set; }
    public int ACC { get; set; }
    public int RES { get; set; }
    public int RESBoost { get; set; }
    public int PR { get; set; }
    public int EV { get; set; }

    public int EffectiveHP
    {
        get;
    }
    public int Survival
    {

        get;
    }

    public int Damage
    {
        get;
    }

    public int BasicDamage
    {
        get;
    }

    


}
public class Monster : IMonster
{
    [JsonConstructor]
    public Monster(string id = "")
    {
        Id = id;

    }





    public string Name { get; set; } = "";

    [JsonConverter(typeof(InterfaceConverter<RuneSet, IRuneSet>))]
    public IRuneSet Runes { get; set; } = new RuneSet();

    public int ATK { get; set; }

    public int ATKBoost { get; set; }

    public int DEFBoost { get; set; }

    public int DEF { get; set; }

    public int HP { get; set; }

    public int HPBoost { get; set; }

    public int SPD {get; set; }

    public int CR { get; set; }
    public int CD { get; set; }
    public int ACC { get; set; }
    public int RES { get; set; }
    public int RESBoost { get; set; }
    public int PR { get; set; }
    public int EV { get; set; }
    public int EVBoost { get; set; }

    
    
    public string Id { get; set;  }

    public int EffectiveHP 
    { 
        get
        {
            double dblHP = (double)HP;
            double dblDEF = (double)DEF;
            double effectiveHP = dblHP*(1140d+(dblDEF*3.5d))/1000d;

           return (int)effectiveHP;
        } 
    }
    public int Survival
    { 
         
        get
        {
            //Assume enemy with 80 PR

            double effectiveEV = Math.Max(EV - 800, 0d);

            double rawDamage = 100d;
            double unevadedPerc = (1000d - effectiveEV) /1000d;

            int numAttacksThrough = (int)Math.Ceiling(EffectiveHP / (unevadedPerc * rawDamage));

            //(1-EV)*numAttacksThrough*rawDamage=EHP
            //numAttacksThrough=EHP/rawDamage*(1-EV)


            return numAttacksThrough;
        }
    }

    public int Damage
    {
        get
        {
            int damage = ATK;
            double dblCR = (double)CR/1000d;
            double dblCD = (double)CD/1000d;
            int bonusDamage=(int)Math.Floor((double)damage * dblCR * dblCD);
            return damage + bonusDamage;
        }
    }

    public int BasicDamage
    { 
        get
        {
            return SPD*Damage;
        }
    }


    public Monster GetModified()
    {
        Monster monster = new Monster();

        Dictionary<RuneType,int> setCount = new Dictionary<RuneType, int>();
        setCount[RuneType.Null]=0;
        setCount[RuneType.Energy]=0;
        setCount[RuneType.Guard]=0;
        setCount[RuneType.Blade]=0;
        setCount[RuneType.Rage]=0;
        setCount[RuneType.Fatal]=0;
        setCount[RuneType.Swift]=0;
        setCount[RuneType.Focus]=0;
        setCount[RuneType.Endure]=0;
        setCount[RuneType.Foresight]=0;
        setCount[RuneType.Assemble]=0;


        setCount[Runes.RuneOne.Type]++;
        setCount[Runes.RuneTwo.Type]++;
        setCount[Runes.RuneThree.Type]++;
        setCount[Runes.RuneFour.Type]++;
        setCount[Runes.RuneFive.Type]++;
        setCount[Runes.RuneSix.Type]++;

        int numEnergySets= (int)Math.Floor((double)setCount[RuneType.Energy]/2d);
        int numGuardSets= (int)Math.Floor((double)setCount[RuneType.Guard]/2d);
        int numBladeSets= (int)Math.Floor((double)setCount[RuneType.Blade]/2d);
        int numRageSets= (int)Math.Floor((double)setCount[RuneType.Rage]/4d);
        int numFatalSets= (int)Math.Floor((double)setCount[RuneType.Fatal]/4d);
        int numSwiftSets= (int)Math.Floor((double)setCount[RuneType.Swift]/4d);
        int numFocusSets= (int)Math.Floor((double)setCount[RuneType.Focus]/2d);
        int numEndureSets= (int)Math.Floor((double)setCount[RuneType.Endure]/2d);
        int numForesightSets= (int)Math.Floor((double)setCount[RuneType.Foresight]/2d);
        int numAssembleSets= (int)Math.Floor((double)setCount[RuneType.Assemble]/2d);

        

        int atkp = Runes.RuneOne.ATKP+Runes.RuneTwo.ATKP+Runes.RuneThree.ATKP+Runes.RuneFour.ATKP+Runes.RuneFive.ATKP+Runes.RuneSix.ATKP;
        int atkf = Runes.RuneOne.ATKF+Runes.RuneTwo.ATKF+Runes.RuneThree.ATKF+Runes.RuneFour.ATKF+Runes.RuneFive.ATKF+Runes.RuneSix.ATKF;

        int defp = Runes.RuneOne.DEFP+Runes.RuneTwo.DEFP+Runes.RuneThree.DEFP+Runes.RuneFour.DEFP+Runes.RuneFive.DEFP+Runes.RuneSix.DEFP+(numGuardSets*150);
        int deff = Runes.RuneOne.DEFF+Runes.RuneTwo.DEFF+Runes.RuneThree.DEFF+Runes.RuneFour.DEFF+Runes.RuneFive.DEFF+Runes.RuneSix.DEFF;

        int hpp = Runes.RuneOne.HPP+Runes.RuneTwo.HPP+Runes.RuneThree.HPP+Runes.RuneFour.HPP+Runes.RuneFive.HPP+Runes.RuneSix.HPP+(numEnergySets*150);
        int hpf = Runes.RuneOne.HPF+Runes.RuneTwo.HPF+Runes.RuneThree.HPF+Runes.RuneFour.HPF+Runes.RuneFive.HPF+Runes.RuneSix.HPF;

        monster.ATKBoost=calcBonus(ATK,atkp,atkf+ATKBoost);
        monster.ATK=ATK+monster.ATKBoost;
        monster.DEFBoost=calcBonus(DEF,defp,deff+DEFBoost);
        monster.DEF=DEF+monster.DEFBoost;
        monster.HPBoost=calcBonus(HP,hpp,hpf+HPBoost);
        monster.HP=HP+monster.HPBoost;
  
        monster.SPD=SPD + Runes.RuneOne.SPD+Runes.RuneTwo.SPD+Runes.RuneThree.SPD+Runes.RuneFour.SPD+Runes.RuneFive.SPD+Runes.RuneSix.SPD;

        monster.CR=CR + Runes.RuneOne.CR+Runes.RuneTwo.CR+Runes.RuneThree.CR+Runes.RuneFour.CR+Runes.RuneFive.CR+Runes.RuneSix.CR + (numBladeSets * 120);
        monster.CD=CD + Runes.RuneOne.CD+Runes.RuneTwo.CD+Runes.RuneThree.CD+Runes.RuneFour.CD+Runes.RuneFive.CD+Runes.RuneSix.CD + (numRageSets * 400);

        monster.ACC=ACC + Runes.RuneOne.ACC+Runes.RuneTwo.ACC+Runes.RuneThree.ACC+Runes.RuneFour.ACC+Runes.RuneFive.ACC+Runes.RuneSix.ACC + (numFocusSets * 150);
        monster.RESBoost=Runes.RuneOne.RES+Runes.RuneTwo.RES+Runes.RuneThree.RES+Runes.RuneFour.RES+Runes.RuneFive.RES+Runes.RuneSix.RES+RESBoost + (numEndureSets * 150);
        monster.RES=RES + monster.RESBoost;

        monster.PR=PR + Runes.RuneOne.PR+Runes.RuneTwo.PR+Runes.RuneThree.PR+Runes.RuneFour.PR+Runes.RuneFive.PR+Runes.RuneSix.PR + (numAssembleSets * 150);
        monster.EVBoost=Runes.RuneOne.EV+Runes.RuneTwo.EV+Runes.RuneThree.EV+Runes.RuneFour.EV+Runes.RuneFive.EV+Runes.RuneSix.EV + EVBoost + (numForesightSets * 150);
        monster.EV=EV + monster.EVBoost;




        

        return monster;
    }

    public int calcBonus(int baseVal,float perc, int flat)
    {
        return calcPercBonus(baseVal,perc)+flat;
    }
    public int calcPercBonus(int baseVal, float perc)
    {
        double percDbl=perc/1000d;
        double percBoost=Math.Round((double)baseVal*percDbl);
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

    public void EquipSet(IRuneSet IRuneSet)
    {
        if (Runes != null)
        {
            if (Runes.RuneOne != null) Runes.RuneOne.EquippedOn = "";
            if (Runes.RuneTwo != null) Runes.RuneTwo.EquippedOn = "";
            if (Runes.RuneThree != null) Runes.RuneThree.EquippedOn = "";
            if (Runes.RuneFour != null) Runes.RuneFour.EquippedOn = "";
            if (Runes.RuneFive != null) Runes.RuneFive.EquippedOn = "";
            if (Runes.RuneSix != null) Runes.RuneSix.EquippedOn = "";
        }
        

        Runes = IRuneSet;
        if (Runes.RuneOne != null) Runes.RuneOne.EquippedOn = this.Id;
        if (Runes.RuneTwo != null) Runes.RuneTwo.EquippedOn = this.Id;
        if (Runes.RuneThree != null) Runes.RuneThree.EquippedOn = this.Id;
        if (Runes.RuneFour != null) Runes.RuneFour.EquippedOn = this.Id;
        if (Runes.RuneFive != null) Runes.RuneFive.EquippedOn = this.Id;
        if (Runes.RuneSix != null) Runes.RuneSix.EquippedOn = this.Id;

    }

    public void UnequipSlot(RuneSlot slot)
    {
        if (slot == RuneSlot.ONE)
        {
            if (Runes.RuneOne!=null) Runes.RuneOne.EquippedOn = "";
            Runes.RuneOne = null;
        }
        if (slot == RuneSlot.TWO)
        {
            if (Runes.RuneTwo != null) Runes.RuneTwo.EquippedOn = "";
            Runes.RuneTwo = null;
        }
        if (slot == RuneSlot.THREE)
        {
            if (Runes.RuneThree != null) Runes.RuneThree.EquippedOn = "";
            Runes.RuneThree = null;
        }
        if (slot == RuneSlot.FOUR)
        {
            if (Runes.RuneFour != null) Runes.RuneFour.EquippedOn = "";
            Runes.RuneFour = null;
        }
        if (slot == RuneSlot.FIVE)
        {
            if (Runes.RuneFive != null) Runes.RuneFive.EquippedOn = "";
            Runes.RuneFive = null;
        }
        if (slot == RuneSlot.SIX)
        {
            if (Runes.RuneSix != null) Runes.RuneSix.EquippedOn = "";
            Runes.RuneSix = null;
        }
    }

    public void UnequipAll()
    {
        UnequipSlot(RuneSlot.ONE);
        UnequipSlot(RuneSlot.TWO);
        UnequipSlot(RuneSlot.THREE);
        UnequipSlot(RuneSlot.FOUR);
        UnequipSlot(RuneSlot.FIVE);
        UnequipSlot(RuneSlot.SIX);
    }

    public void EquipOne(IRune rune)
    {
        if (rune.Slot==RuneSlot.ONE)
        {
            if (Runes.RuneOne != null) Runes.RuneOne.EquippedOn = "";
            Runes.RuneOne = rune;
            Runes.RuneOne.EquippedOn = this.Id;
        }

        if (rune.Slot == RuneSlot.TWO)
        {
            if (Runes.RuneTwo != null) Runes.RuneTwo.EquippedOn = "";
            Runes.RuneTwo = rune;
            Runes.RuneTwo.EquippedOn = this.Id;
        }

        if (rune.Slot == RuneSlot.THREE)
        {
            if (Runes.RuneThree != null) Runes.RuneThree.EquippedOn = "";
            Runes.RuneThree = rune;
            Runes.RuneThree.EquippedOn = this.Id;
        }

        if (rune.Slot == RuneSlot.FOUR)
        {
            if (Runes.RuneFour != null) Runes.RuneFour.EquippedOn = "";
            Runes.RuneFour = rune;
            Runes.RuneFour.EquippedOn = this.Id;
        }

        if (rune.Slot == RuneSlot.FIVE)
        {
            if (Runes.RuneFive != null) Runes.RuneFive.EquippedOn = "";
            Runes.RuneFive = rune;
            Runes.RuneFive.EquippedOn = this.Id;
        }

        if (rune.Slot == RuneSlot.SIX)
        {
            if (Runes.RuneSix != null) Runes.RuneSix.EquippedOn = "";
            Runes.RuneSix = rune;
            Runes.RuneSix.EquippedOn = this.Id;
        }
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}

public class MonsterStorage
{
    public List<Monster> Monsters = new List<Monster>();

}

