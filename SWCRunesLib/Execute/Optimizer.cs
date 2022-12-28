namespace SWCRunesLib;

using System;
using System.Collections.Generic;
public class Optimizer
{
    public Optimizer(RuneStorage vRunes, MonsterStorage vMonsters, RequestStorage vRequests)
    {


        typedStattedSlottedRunes[Rune.RuneType.Energy] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Energy]);
        typedStattedSlottedRunes[Rune.RuneType.Guard] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Guard]);


        typedStattedSlottedRunes[Rune.RuneType.Blade] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Blade]);
        typedStattedSlottedRunes[Rune.RuneType.Rage] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Rage]);

        typedStattedSlottedRunes[Rune.RuneType.Fatal] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Fatal]);
        typedStattedSlottedRunes[Rune.RuneType.Swift] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Swift]);

        typedStattedSlottedRunes[Rune.RuneType.Focus] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Focus]);
        typedStattedSlottedRunes[Rune.RuneType.Endure] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Endure]);


        typedStattedSlottedRunes[Rune.RuneType.Foresight] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Foresight]);
        typedStattedSlottedRunes[Rune.RuneType.Assemble] = new Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>();
        InitStattedSlottedRuneList(typedStattedSlottedRunes[Rune.RuneType.Assemble]);




        foreach (Rune aRune in vRunes.Runes)
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

        foreach (Monster monster in vMonsters.Monsters)
        {
            monsters.Add(monster.Name, monster);
        }

        requests = vRequests;

    }

    private void InitSlottedRuneList(Dictionary<Rune.RuneSlot, List<Rune>> list)
    {
        list[Rune.RuneSlot.ONE] = new List<Rune>();
        list[Rune.RuneSlot.TWO] = new List<Rune>();
        list[Rune.RuneSlot.THREE] = new List<Rune>();
        list[Rune.RuneSlot.FOUR] = new List<Rune>();
        list[Rune.RuneSlot.FIVE] = new List<Rune>();
        list[Rune.RuneSlot.SIX] = new List<Rune>();
    }

    private void InitStattedSlottedRuneList(Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>> list)
    {
        list["ATKP"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["ATKP"]);

        list["ATKF"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["ATKF"]);

        list["DEFP"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["DEFP"]);

        list["DEFF"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["DEFF"]);

        list["HPP"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["HPP"]);

        list["HPF"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["HPF"]);

        list["SPD"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["SPD"]);

        list["CR"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["CR"]);

        list["CD"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["CD"]);

        list["ACC"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["ACC"]);

        list["RES"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["RES"]);

        list["PR"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["PR"]);

        list["EV"] = new Dictionary<Rune.RuneSlot, List<Rune>>();
        InitSlottedRuneList(list["EV"]);
    }

    private Dictionary<string, Monster> monsters = new Dictionary<string, Monster>();
    private Dictionary<Rune.RuneType, Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>> typedStattedSlottedRunes = new Dictionary<Rune.RuneType, Dictionary<string, Dictionary<Rune.RuneSlot, List<Rune>>>>();

    private RequestStorage requests;

    private Request _req;

    public List<Recommendation> Process()
    {
        List<Recommendation> recoms = new List<Recommendation>();
        foreach (Request req in requests.Requests)
        {
            Recommendation rec = ProcessReq(req);
            recoms.Add(rec);
        }

        return recoms;

    }

    public void UpdateReq(Request inReq)
    {
        _req = inReq;
    }

    public Recommendation ProcessReq(Request inReq)
    {
        Recommendation rec = new Recommendation();
        _req = inReq;
        rec.MonsterName = _req.MonsterName;
        rec.InitiatingRequest = _req;
        string monsterJson = monsters[_req.MonsterName].ToJson();
        List<RuneSet> runeSets = BuildRunePermutations();

        List<RecommendedMonster> results = new List<RecommendedMonster>();


        foreach (RuneSet set in runeSets)
        {
            Monster m = Monster.FromJson(monsterJson);
            m.Name = _req.MonsterName;
            m.Runes = set;
            Monster resultMon = m.GetModified();
            resultMon.Runes = set;
            RecommendedMonster recMon = getRecommendedMonster(resultMon, _req);



            results.Add(recMon);
        }

        results.Sort(CompareMonsters);



        rec.RecommendedSetup = results;

        return rec;
    }

    private RecommendedMonster getRecommendedMonster(Monster m, Request req)
    {
        RecommendedMonster recMon = new RecommendedMonster(m);

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

    public List<RuneSet> BuildRunePermutations()
    {
        List<RuneSet> perms = new List<RuneSet>();


        List<Rune.RuneType> typeList = new List<Rune.RuneType>();

        List<string> statList;

        statList = buildStatList();


        typeList = buildTypeList();

        List<Rune> used1 = new List<Rune>();
        List<Rune> used2 = new List<Rune>();
        List<Rune> used3 = new List<Rune>();
        List<Rune> used4 = new List<Rune>();
        List<Rune> used5 = new List<Rune>();
        List<Rune> used6 = new List<Rune>();


        foreach (Rune.RuneType type1 in typeList)
        {
           
            foreach (string stat1 in statList)
            {

                foreach (Rune rune1 in typedStattedSlottedRunes[type1][stat1][Rune.RuneSlot.ONE])
                {
                    if (used1.Contains(rune1)) continue;
                    used1.Add(rune1);

                    foreach (Rune.RuneType type2 in typeList)
                    {
                        foreach (string stat2 in statList)
                        {

                            foreach (Rune rune2 in typedStattedSlottedRunes[type2][stat2][Rune.RuneSlot.TWO])
                            {
                                if (used2.Contains(rune2)) continue;
                                used2.Add(rune2);

                                foreach (Rune.RuneType type3 in typeList)
                                {
                                    foreach (string stat3 in statList)
                                    {
                                        foreach (Rune rune3 in typedStattedSlottedRunes[type3][stat3][Rune.RuneSlot.THREE])
                                        {
                                            if (used3.Contains(rune3)) continue;
                                            used3.Add(rune3);

                                            foreach (Rune.RuneType type4 in typeList)
                                            {
                                                foreach (string stat4 in statList)
                                                {


                                                    foreach (Rune rune4 in typedStattedSlottedRunes[type4][stat4][Rune.RuneSlot.FOUR])
                                                    {

                                                        if (used4.Contains(rune4)) continue;
                                                        used4.Add(rune4);

                                                        foreach (Rune.RuneType type5 in typeList)
                                                        {
                                                            foreach (string stat5 in statList)
                                                            {
                                                                foreach (Rune rune5 in typedStattedSlottedRunes[type5][stat5][Rune.RuneSlot.FIVE])
                                                                {

                                                                    if (used5.Contains(rune5)) continue;
                                                                    used5.Add(rune5);

                                                                    foreach (Rune.RuneType type6 in typeList)
                                                                    {
                                                                        foreach (string stat6 in statList)
                                                                        {
                                                                            foreach (Rune rune6 in typedStattedSlottedRunes[type6][stat6][Rune.RuneSlot.SIX])
                                                                            {

                                                                                if (used6.Contains(rune6)) continue;
                                                                                used6.Add(rune6);

                                                                                RuneSet set = new RuneSet();

                                                                                set.RuneOne = rune1;
                                                                                set.RuneTwo = rune2;
                                                                                set.RuneThree = rune3;
                                                                                set.RuneFour = rune4;
                                                                                set.RuneFive = rune5;
                                                                                set.RuneSix = rune6;
                                                                                perms.Add(set);


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

    private List<Rune.RuneType> buildTypeList()
    {
        List<Rune.RuneType> typeList = new List<Rune.RuneType>();

        if (_req.RestrictSetOne != Rune.RuneType.Null)
        {
            typeList.Add(_req.RestrictSetOne);
        }

        if (_req.RestrictSetTwo != Rune.RuneType.Null)
        {
            typeList.Add(_req.RestrictSetTwo);
        }

        if (_req.RestrictSetThree != Rune.RuneType.Null)
        {
            typeList.Add(_req.RestrictSetThree);
        }

        if (typeList.Count == 0)
        {
            typeList.Add(Rune.RuneType.Energy);
            typeList.Add(Rune.RuneType.Guard);

            typeList.Add(Rune.RuneType.Blade);
            typeList.Add(Rune.RuneType.Rage);

            typeList.Add(Rune.RuneType.Fatal);
            typeList.Add(Rune.RuneType.Swift);

            typeList.Add(Rune.RuneType.Focus);
            typeList.Add(Rune.RuneType.Endure);

            typeList.Add(Rune.RuneType.Foresight);
            typeList.Add(Rune.RuneType.Assemble);
        }

        return typeList;
    }

    public int CalculatePerms()
    {
       
        int runeOneCount = 0;
        int runeTwoCount = 0;
        int runeThreeCount = 0;
        int runeFourCount = 0;
        int runeFiveCount = 0;
        int runeSixCount = 0;


        List<Rune.RuneType> typeList = buildTypeList();
        List<string> statList = buildStatList();

        foreach (Rune.RuneType runeType in typeList)
        {
            foreach (string stat in statList)
            {
                runeOneCount += typedStattedSlottedRunes[runeType][stat][Rune.RuneSlot.ONE].Count();
                runeTwoCount += typedStattedSlottedRunes[runeType][stat][Rune.RuneSlot.TWO].Count();
                runeThreeCount += typedStattedSlottedRunes[runeType][stat][Rune.RuneSlot.THREE].Count();
                runeFourCount += typedStattedSlottedRunes[runeType][stat][Rune.RuneSlot.FOUR].Count();
                runeFiveCount += typedStattedSlottedRunes[runeType][stat][Rune.RuneSlot.FIVE].Count();
                runeSixCount += typedStattedSlottedRunes[runeType][stat][Rune.RuneSlot.SIX].Count();
            }
        }


        return runeOneCount*runeTwoCount*runeThreeCount*runeFourCount*runeFiveCount*runeSixCount;
    }

    public int CompareMonsters(RecommendedMonster left, RecommendedMonster right)
    {

        int result = 0;

        if (left.FirstValue > right.FirstValue)
        {
            result = 1;
        }
        else if (right.FirstValue > left.FirstValue)
        {
            result = -1;
        }
        else
        {
            if (left.SecondValue > right.SecondValue)
            {
                result = 1;
            }
            else if (right.SecondValue > left.SecondValue)
            {
                result = -1;
            }
            else
            {
                if (left.ThirdValue > right.ThirdValue)
                {
                    result = 1;
                }
                else if (right.ThirdValue > left.ThirdValue)
                {
                    result = -1;
                }
            }
        }


        return result * -1;
    }

}