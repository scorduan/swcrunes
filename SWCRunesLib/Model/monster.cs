namespace SWCRunesLib;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
public class Monster
{

    public string Name {  get; set; }

    public RuneSet Runes { get; set; }

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

        Dictionary<Rune.RuneType,int> setCount = new Dictionary<Rune.RuneType, int>();
        setCount[Rune.RuneType.Null]=0;
        setCount[Rune.RuneType.Energy]=0;
        setCount[Rune.RuneType.Guard]=0;
        setCount[Rune.RuneType.Blade]=0;
        setCount[Rune.RuneType.Rage]=0;
        setCount[Rune.RuneType.Fatal]=0;
        setCount[Rune.RuneType.Swift]=0;
        setCount[Rune.RuneType.Focus]=0;
        setCount[Rune.RuneType.Endure]=0;
        setCount[Rune.RuneType.Foresight]=0;
        setCount[Rune.RuneType.Assemble]=0;


        setCount[Runes.RuneOne.Type]++;
        setCount[Runes.RuneTwo.Type]++;
        setCount[Runes.RuneThree.Type]++;
        setCount[Runes.RuneFour.Type]++;
        setCount[Runes.RuneFive.Type]++;
        setCount[Runes.RuneSix.Type]++;

        int numEnergySets= (int)Math.Floor((double)setCount[Rune.RuneType.Energy]/2d);
        int numGuardSets= (int)Math.Floor((double)setCount[Rune.RuneType.Guard]/2d);
        int numBladeSets= (int)Math.Floor((double)setCount[Rune.RuneType.Blade]/2d);
        int numRageSets= (int)Math.Floor((double)setCount[Rune.RuneType.Rage]/4d);
        int numFatalSets= (int)Math.Floor((double)setCount[Rune.RuneType.Fatal]/4d);
        int numSwiftSets= (int)Math.Floor((double)setCount[Rune.RuneType.Swift]/4d);
        int numFocusSets= (int)Math.Floor((double)setCount[Rune.RuneType.Focus]/2d);
        int numEndureSets= (int)Math.Floor((double)setCount[Rune.RuneType.Endure]/2d);
        int numForesightSets= (int)Math.Floor((double)setCount[Rune.RuneType.Foresight]/2d);
        int numAssembleSets= (int)Math.Floor((double)setCount[Rune.RuneType.Assemble]/2d);

        

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

    public void EquipSet(RuneSet runeSet)
    {
        if (Runes != null)
        {
            if (Runes.RuneOne != null) Runes.RuneOne.EquippedOn = "";
            if (Runes.RuneTwo != null) Runes.RuneOne.EquippedOn = "";
            if (Runes.RuneThree != null) Runes.RuneOne.EquippedOn = "";
            if (Runes.RuneFour != null) Runes.RuneOne.EquippedOn = "";
            if (Runes.RuneFive != null) Runes.RuneOne.EquippedOn = "";
            if (Runes.RuneSix != null) Runes.RuneOne.EquippedOn = "";
        }
        

        Runes = runeSet;
        Runes.RuneOne.EquippedOn = this.Name;
        Runes.RuneTwo.EquippedOn = this.Name;
        Runes.RuneThree.EquippedOn = this.Name;
        Runes.RuneFour.EquippedOn = this.Name;
        Runes.RuneFive.EquippedOn = this.Name;
        Runes.RuneSix.EquippedOn = this.Name;

    }
}

public class MonsterStorage
{
    public List<Monster> Monsters = new List<Monster>();

}

