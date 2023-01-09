namespace SWCRunesLib;

using System;
using System.Collections.Generic;
public class Optimizer
{
    public Optimizer(List<IRune> vRunes)
    {


        typedStattedSlottedRunes[RuneType.Energy] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Energy]);
        typedStattedSlottedRunes[RuneType.Guard] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Guard]);


        typedStattedSlottedRunes[RuneType.Blade] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Blade]);
        typedStattedSlottedRunes[RuneType.Rage] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Rage]);

        typedStattedSlottedRunes[RuneType.Fatal] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Fatal]);
        typedStattedSlottedRunes[RuneType.Swift] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Swift]);

        typedStattedSlottedRunes[RuneType.Focus] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Focus]);
        typedStattedSlottedRunes[RuneType.Endure] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Endure]);


        typedStattedSlottedRunes[RuneType.Foresight] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Foresight]);
        typedStattedSlottedRunes[RuneType.Assemble] = new Dictionary<string, Dictionary<RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[RuneType.Assemble]);




        foreach (Rune aRune in vRunes)
        {


            if (aRune.ATKP > 0) typedStattedSlottedRunes[aRune.Type]["ATKP"][aRune.Slot].Add(aRune);
            if (aRune.ATKF > 0) typedStattedSlottedRunes[aRune.Type]["ATKF"][aRune.Slot].Add(aRune);

            if (aRune.DEFP > 0) typedStattedSlottedRunes[aRune.Type]["DEFP"][aRune.Slot].Add(aRune);
            if (aRune.DEFF > 0) typedStattedSlottedRunes[aRune.Type]["DEFF"][aRune.Slot].Add(aRune);

            if (aRune.HPP > 0) typedStattedSlottedRunes[aRune.Type]["HPP"][aRune.Slot].Add(aRune);
            if (aRune.HPF > 0) typedStattedSlottedRunes[aRune.Type]["HPF"][aRune.Slot].Add(aRune);

            if (aRune.SPD > 0) typedStattedSlottedRunes[aRune.Type]["SPD"][aRune.Slot].Add(aRune);

            if (aRune.CR > 0) typedStattedSlottedRunes[aRune.Type]["CR"][aRune.Slot].Add(aRune);
            if (aRune.CD > 0) typedStattedSlottedRunes[aRune.Type]["CD"][aRune.Slot].Add(aRune);

            if (aRune.ACC > 0) typedStattedSlottedRunes[aRune.Type]["ACC"][aRune.Slot].Add(aRune);
            if (aRune.RES > 0) typedStattedSlottedRunes[aRune.Type]["RES"][aRune.Slot].Add(aRune);

            if (aRune.PR > 0) typedStattedSlottedRunes[aRune.Type]["PR"][aRune.Slot].Add(aRune);
            if (aRune.EV > 0) typedStattedSlottedRunes[aRune.Type]["EV"][aRune.Slot].Add(aRune);
        }


    }

    private void InitSlottedRuneList(Dictionary<RuneSlot, List<Rune>> list)
    {
        list[RuneSlot.ONE] = new List<Rune>();
        list[RuneSlot.TWO] = new List<Rune>();
        list[RuneSlot.THREE] = new List<Rune>();
        list[RuneSlot.FOUR] = new List<Rune>();
        list[RuneSlot.FIVE] = new List<Rune>();
        list[RuneSlot.SIX] = new List<Rune>();
    }

    private void InitStattedSlottedRuneList(Dictionary<string, Dictionary<RuneSlot, List<Rune>>> list)
    {
        list["ATKP"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["ATKP"]);

        list["ATKF"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["ATKF"]);

        list["DEFP"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["DEFP"]);

        list["DEFF"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["DEFF"]);

        list["HPP"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["HPP"]);

        list["HPF"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["HPF"]);

        list["SPD"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["SPD"]);

        list["CR"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["CR"]);

        list["CD"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["CD"]);

        list["ACC"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["ACC"]);

        list["RES"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["RES"]);

        list["PR"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["PR"]);

        list["EV"] = new Dictionary<RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["EV"]);
    }

    
    private Dictionary<RuneType, Dictionary<string, Dictionary<RuneSlot, List<Rune>>>> typedStattedSlottedRunes = new Dictionary<RuneType, Dictionary<string, Dictionary<RuneSlot, List<Rune>>>>();

    
    private IRequest _req;


    public void UpdateReq(IRequest inReq)
    {
        _req = inReq;
    }

    public List<IRecommendedMonster> ProcessReq(IRequest inReq,IMonster origMonster)
    {
        DateTime time = DateTime.Now;
        _req = inReq;
        List<IRuneSet> runeSets = BuildRunePermutations();
        time = DateTime.Now;
        List<IRecommendedMonster> results = new List<IRecommendedMonster>();


        foreach (IRuneSet set in runeSets)
        {
            IMonster m = (IMonster)origMonster.Clone();
            // Ensure that anything that happens to the clone doesn't happen...
            m.EquipSet(set,true);
            
            RecommendedMonster recMon = getRecommendedMonster(origMonster, m, _req);



            results.Add(recMon);
        }
        time = DateTime.Now;
        results.Sort(CompareMonsters);

        time = DateTime.Now;

        int x = 0;
        x = x + 1;

        return results;
    }

    private RecommendedMonster getRecommendedMonster(IMonster origMonster, IMonster m, IRequest req)
    {
        RecommendedMonster recMon = new RecommendedMonster(origMonster, m);

        if (req.PrimaryAttribute == "ATK") recMon.FirstValue = m.ATK;
        if (req.PrimaryAttribute == "DEF") recMon.FirstValue = m.DEF;
        if (req.PrimaryAttribute == "HP") recMon.FirstValue = m.HP;

        if (req.PrimaryAttribute == "SPD") recMon.FirstValue = m.SPD;
        if (req.PrimaryAttribute == "CR") recMon.FirstValue = m.CR;

        if (req.PrimaryAttribute == "CD") recMon.FirstValue = m.CD;

        if (req.PrimaryAttribute == "ACC") recMon.FirstValue = m.ACC;
        if (req.PrimaryAttribute == "RES") recMon.FirstValue = m.RES;

        if (req.PrimaryAttribute == "PR") recMon.FirstValue = m.PR;
        if (req.PrimaryAttribute == "EV") recMon.FirstValue = m.EV;

        if (req.PrimaryAttribute == "Damage") recMon.FirstValue = m.Damage;
        if (req.PrimaryAttribute == "BasicDamage") recMon.FirstValue = m.BasicDamage;
        if (req.PrimaryAttribute == "Survival") recMon.FirstValue = m.Survival;
        if (req.PrimaryAttribute == "EffectiveHP") recMon.FirstValue = m.EffectiveHP;

        if (req.SecondaryAttribute == "ATK") recMon.SecondValue = m.ATK;
        if (req.SecondaryAttribute == "DEF") recMon.SecondValue = m.DEF;
        if (req.SecondaryAttribute == "HP") recMon.SecondValue = m.HP;

        if (req.SecondaryAttribute == "SPD") recMon.SecondValue = m.SPD;
        if (req.SecondaryAttribute == "CR") recMon.SecondValue = m.CR;

        if (req.SecondaryAttribute == "CD") recMon.SecondValue = m.CD;

        if (req.SecondaryAttribute == "ACC") recMon.SecondValue = m.ACC;
        if (req.SecondaryAttribute == "RES") recMon.SecondValue = m.RES;

        if (req.SecondaryAttribute == "PR") recMon.SecondValue = m.PR;
        if (req.SecondaryAttribute == "EV") recMon.SecondValue = m.EV;

        if (req.SecondaryAttribute == "Damage") recMon.SecondValue = m.Damage;
        if (req.SecondaryAttribute == "BasicDamage") recMon.SecondValue = m.BasicDamage;
        if (req.SecondaryAttribute == "Survival") recMon.SecondValue = m.Survival;
        if (req.SecondaryAttribute == "EffectiveHP") recMon.SecondValue = m.EffectiveHP;

        if (req.TertiaryAttribute == "ATK") recMon.ThirdValue = m.ATK;
        if (req.TertiaryAttribute == "DEF") recMon.ThirdValue = m.DEF;
        if (req.TertiaryAttribute == "HP") recMon.ThirdValue = m.HP;

        if (req.TertiaryAttribute == "SPD") recMon.ThirdValue = m.SPD;
        if (req.TertiaryAttribute == "CR") recMon.ThirdValue = m.CR;

        if (req.TertiaryAttribute == "CD") recMon.ThirdValue = m.CD;

        if (req.TertiaryAttribute == "ACC") recMon.ThirdValue = m.ACC;
        if (req.TertiaryAttribute == "RES") recMon.ThirdValue = m.RES;

        if (req.TertiaryAttribute == "PR") recMon.ThirdValue = m.PR;
        if (req.TertiaryAttribute == "EV") recMon.ThirdValue = m.EV;

        if (req.TertiaryAttribute == "Damage") recMon.ThirdValue = m.Damage;
        if (req.TertiaryAttribute == "BasicDamage") recMon.ThirdValue = m.BasicDamage;
        if (req.TertiaryAttribute == "Survival") recMon.ThirdValue = m.Survival;
        if (req.TertiaryAttribute == "EffectiveHP") recMon.ThirdValue = m.EffectiveHP;

        return recMon;
    }

    public List<IRuneSet> BuildRunePermutations()
    {
        List<IRuneSet> perms = new List<IRuneSet>();


        List<RuneType> typeList = new List<RuneType>();

        List<string> statList;

        statList = buildStatList();


        typeList = buildTypeList();

        HashSet<string> used1 = new HashSet<string>();
        HashSet<string> used2 = new HashSet<string>();
        HashSet<string> used3 = new HashSet<string>();
        HashSet<string> used4 = new HashSet<string>();
        HashSet<string> used5 = new HashSet<string>();
        HashSet<string> used6 = new HashSet<string>();
        DateTime time = DateTime.Now;
        int counter = 0;
        foreach (RuneType type1 in typeList)
        {
           
            foreach (string stat1 in statList)
            {

                foreach (Rune rune1 in typedStattedSlottedRunes[type1][stat1][RuneSlot.ONE])
                {
                    if (used1.Contains(rune1.Id)) continue;
                    if ((rune1.EquippedOn != "")&& (rune1.EquippedOn != _req.MonsterId)) continue;
                    used1.Add(rune1.Id);

                    foreach (RuneType type2 in typeList)
                    {
                        foreach (string stat2 in statList)
                        {

                            foreach (Rune rune2 in typedStattedSlottedRunes[type2][stat2][RuneSlot.TWO])
                            {
                                if (used2.Contains(rune2.Id)) continue;
                                if ((rune2.EquippedOn != "") && (rune2.EquippedOn != _req.MonsterId)) continue;
                                used2.Add(rune2.Id);

                                foreach (RuneType type3 in typeList)
                                {
                                    foreach (string stat3 in statList)
                                    {
                                        foreach (Rune rune3 in typedStattedSlottedRunes[type3][stat3][RuneSlot.THREE])
                                        {
                                            if (used3.Contains(rune3.Id)) continue;
                                            if ((rune3.EquippedOn != "") && (rune3.EquippedOn != _req.MonsterId)) continue;
                                            used3.Add(rune3.Id);

                                            foreach (RuneType type4 in typeList)
                                            {
                                                foreach (string stat4 in statList)
                                                {


                                                    foreach (Rune rune4 in typedStattedSlottedRunes[type4][stat4][RuneSlot.FOUR])
                                                    {

                                                        if (used4.Contains(rune4.Id)) continue;
                                                        if ((rune4.EquippedOn != "") && (rune4.EquippedOn != _req.MonsterId)) continue;
                                                        used4.Add(rune4.Id);

                                                        foreach (RuneType type5 in typeList)
                                                        {
                                                            foreach (string stat5 in statList)
                                                            {
                                                                foreach (Rune rune5 in typedStattedSlottedRunes[type5][stat5][RuneSlot.FIVE])
                                                                {

                                                                    if (used5.Contains(rune5.Id)) continue;
                                                                    if ((rune5.EquippedOn != "") && (rune5.EquippedOn != _req.MonsterId)) continue;
                                                                    used5.Add(rune5.Id);

                                                                    foreach (RuneType type6 in typeList)
                                                                    {
                                                                        foreach (string stat6 in statList)
                                                                        {
                                                                            foreach (Rune rune6 in typedStattedSlottedRunes[type6][stat6][RuneSlot.SIX])
                                                                            {

                                                                                if (used6.Contains(rune6.Id)) continue;
                                                                                if ((rune6.EquippedOn != "") && (rune6.EquippedOn != _req.MonsterId)) continue;
                                                                                used6.Add(rune6.Id);

                                                                                IRuneSet set = new RuneSet();

                                                                                set.RuneOne = rune1;
                                                                                set.RuneTwo = rune2;
                                                                                set.RuneThree = rune3;
                                                                                set.RuneFour = rune4;
                                                                                set.RuneFive = rune5;
                                                                                set.RuneSix = rune6;
                                                                                perms.Add(set);

                                                                                counter++;
                                                                            }
                                                                        }
                                                                        used6.Clear();
                                                                    }
                                                                }
                                                            }
                                                            used5.Clear();
                                                        }
                                                    }
                                                }
                                                used4.Clear();
                                            }
                                        }
                                    }
                                    used3.Clear();
                                }
                            }

                        }
                        used2.Clear();
                    }
                }
            }
            used1.Clear();
        }
        time = DateTime.Now;
        return perms;
    }

    private List<string> buildStatList()
    {
        List<string> statList = new List<string>();
        if (_req.FocusStats.Count > 0)
        {
            statList = _req.FocusStats;
        }
        else
        {
            statList = new List<string>();
            statList.Add("ATKP");
            statList.Add("ATKF");

            statList.Add("DEFP");
            statList.Add("DEFF");

            statList.Add("HPP");
            statList.Add("HPF");

            statList.Add("SPD");

            statList.Add("CR");
            statList.Add("CD");

            statList.Add("ACC");
            statList.Add("RES");

            statList.Add("PR");
            statList.Add("EV");
        }

        return statList;
    }

    private List<RuneType> buildTypeList()
    {
        List<RuneType> typeList = new List<RuneType>();

        if (_req.RestrictSetOne != RuneType.Null)
        {
            typeList.Add(_req.RestrictSetOne);
        }

        if (_req.RestrictSetTwo != RuneType.Null)
        {
            typeList.Add(_req.RestrictSetTwo);
        }

        if (_req.RestrictSetThree != RuneType.Null)
        {
            typeList.Add(_req.RestrictSetThree);
        }

        if (typeList.Count == 0)
        {
            typeList.Add(RuneType.Energy);
            typeList.Add(RuneType.Guard);

            typeList.Add(RuneType.Blade);
            typeList.Add(RuneType.Rage);

            typeList.Add(RuneType.Fatal);
            typeList.Add(RuneType.Swift);

            typeList.Add(RuneType.Focus);
            typeList.Add(RuneType.Endure);

            typeList.Add(RuneType.Foresight);
            typeList.Add(RuneType.Assemble);
        }

        return typeList;
    }

    public long CalculatePerms()
    {
       
        long runeOneCount = 0;
        long runeTwoCount = 0;
        long runeThreeCount = 0;
        long runeFourCount = 0;
        long runeFiveCount = 0;
        long runeSixCount = 0;


        List<RuneType> typeList = buildTypeList();
        List<string> statList = buildStatList();

        foreach (RuneType runeType in typeList)
        {
            foreach (string stat in statList)
            {
                runeOneCount += typedStattedSlottedRunes[runeType][stat][RuneSlot.ONE].Count();
                runeTwoCount += typedStattedSlottedRunes[runeType][stat][RuneSlot.TWO].Count();
                runeThreeCount += typedStattedSlottedRunes[runeType][stat][RuneSlot.THREE].Count();
                runeFourCount += typedStattedSlottedRunes[runeType][stat][RuneSlot.FOUR].Count();
                runeFiveCount += typedStattedSlottedRunes[runeType][stat][RuneSlot.FIVE].Count();
                runeSixCount += typedStattedSlottedRunes[runeType][stat][RuneSlot.SIX].Count();
            }
        }

        long result= runeOneCount * runeTwoCount * runeThreeCount * runeFourCount * runeFiveCount * runeSixCount;

        return result;
    }

    public int CompareMonsters(IRecommendedMonster left, IRecommendedMonster right)
    {
        //TODO: above target threshold is equal
        int result = 0;

        float thresholdPercent = .01f;
        int firstThreshAmount = (int)((float)Math.Max(left.FirstValue, right.FirstValue)*thresholdPercent);
        int secondThreshAmount = (int)((float)Math.Max(left.SecondValue, right.SecondValue) * thresholdPercent);
        int thirdThreshAmount = (int)((float)Math.Max(left.ThirdValue, right.ThirdValue) * thresholdPercent);

        if (left.FirstValue - firstThreshAmount > right.FirstValue)
        {
            result = 1;
        }
        else if (right.FirstValue - firstThreshAmount > left.FirstValue)
        {
            result = -1;
        }
        else
        {
            if (left.SecondValue - secondThreshAmount > right.SecondValue)
            {
                result = 1;
            }
            else if (right.SecondValue - secondThreshAmount > left.SecondValue)
            {
                result = -1;
            }
            else
            {
                if (left.ThirdValue - thirdThreshAmount > right.ThirdValue)
                {
                    result = 1;
                }
                else if (right.ThirdValue - thirdThreshAmount > left.ThirdValue)
                {
                    result = -1;
                }
            }
        }


        return result * -1;
    }

}