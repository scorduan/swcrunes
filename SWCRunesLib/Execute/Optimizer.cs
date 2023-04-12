namespace SWCRunesLib;

using System;
using System.Collections.Generic;
public class Optimizer
{
    public Optimizer(List<Rune> vRunes)
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


    private Request _req;


    public void UpdateReq(Request inReq)
    {
        _req = inReq;
    }

    public SortedSet<RecommendedMonster> ProcessReq(Request inReq, Monster origMonster)
    {
        DateTime time = DateTime.Now;
        _req = inReq;

        _req.PossiblePermutations = CalculatePerms();
        _req.PermCount = 0;
        _req.ResultCount = 0;
        _req.FilteredCount = 0;
        _req.PermProgress = 0;

        List<RuneSet> runeSets = BuildRunePermutations();

        time = DateTime.Now;
        SortedSet<RecommendedMonster> results = new SortedSet<RecommendedMonster>();


        _req.Status = RequestStatus.FilteringAndSorting;
        int counter = 0;
        foreach (RuneSet set in runeSets)
        {
            Monster m = (Monster)origMonster.Clone();
            // Ensure that anything that happens to the clone doesn't happen...
            m.EquipSet(set, true);

            if (beatsThresholds(m, inReq))
            {
                RecommendedMonster recMon = new RecommendedMonster(origMonster, m, _req);
                results.Add(recMon);
            }
            counter++;
            if (counter % 10000 == 0)
            {
                _req.FilteredCount = counter;
                _req.ResultCount = results.Count();
            }
        }
        _req.FilteredCount = counter;
        _req.ResultCount = results.Count();
        _req.LastRun = DateTime.Now;
        _req.Status = RequestStatus.Completed;
        return results;
    }

    private bool beatsThresholds(Monster m, Request inReq)
    {
        bool exceeds = true;
        foreach (StatThreshold threshold in inReq.Thresholds)
        {
            if (m.Stats[threshold.CheckStat] < threshold.Threshold)
            {
                exceeds = false;
                break;
            }
        }

        return exceeds;
    }


    public List<RuneSet> BuildRunePermutations()
    {
        List<RuneSet> perms = new List<RuneSet>();


        List<RuneType> typeList = new List<RuneType>();

        List<string> statList;

        statList = buildStatList();


        typeList = buildTypeList();
        _req.Status = RequestStatus.BuildingPermutations;
        HashSet<string> used1 = new HashSet<string>();
        HashSet<string> used2 = new HashSet<string>();
        HashSet<string> used3 = new HashSet<string>();
        HashSet<string> used4 = new HashSet<string>();
        HashSet<string> used5 = new HashSet<string>();
        HashSet<string> used6 = new HashSet<string>();
        DateTime time = DateTime.Now;
        int counter = 0;
        bool steal = _req.StealLowerPriority;
        int weight = _req.Monster.Weight;
        int runeOneCounter = 0;
        int runeOneTotal = 0;

        foreach (RuneType type1 in typeList)
        {

            foreach (string stat1 in statList)
            {
                runeOneTotal = runeOneTotal + typedStattedSlottedRunes[type1][stat1][RuneSlot.ONE].Count;
            }
        }

        foreach (RuneType type1 in typeList)
        {



            foreach (string stat1 in statList)
            {

                foreach (Rune rune1 in typedStattedSlottedRunes[type1][stat1][RuneSlot.ONE])
                {
                    runeOneCounter++;
                    if (used1.Contains(rune1.Id)) continue;

                    // We can use this rune if:
                    // It's not equipped
                    // It's equipped on this monsters
                    // It's equipped on a lower weight monster and we're set to steal

                    if (!((rune1.EquippedOn == "") || (rune1.EquippedOn == _req.MonsterId) || (steal && (rune1.EquippedMonster?.Weight < weight)))) continue;
                    used1.Add(rune1.Id);

                    foreach (RuneType type2 in typeList)
                    {
                        foreach (string stat2 in statList)
                        {

                            foreach (Rune rune2 in typedStattedSlottedRunes[type2][stat2][RuneSlot.TWO])
                            {
                                if (used2.Contains(rune2.Id)) continue;
                                if (!((rune2.EquippedOn == "") || (rune2.EquippedOn == _req.MonsterId) || (steal && (rune2.EquippedMonster?.Weight < weight)))) continue;
                                used2.Add(rune2.Id);

                                foreach (RuneType type3 in typeList)
                                {
                                    foreach (string stat3 in statList)
                                    {
                                        foreach (Rune rune3 in typedStattedSlottedRunes[type3][stat3][RuneSlot.THREE])
                                        {
                                            if (used3.Contains(rune3.Id)) continue;
                                            if (!((rune3.EquippedOn == "") || (rune3.EquippedOn == _req.MonsterId) || (steal && (rune3.EquippedMonster?.Weight < weight)))) continue;
                                            used3.Add(rune3.Id);

                                            foreach (RuneType type4 in typeList)
                                            {
                                                foreach (string stat4 in statList)
                                                {


                                                    foreach (Rune rune4 in typedStattedSlottedRunes[type4][stat4][RuneSlot.FOUR])
                                                    {

                                                        if (used4.Contains(rune4.Id)) continue;
                                                        if (!((rune4.EquippedOn == "") || (rune4.EquippedOn == _req.MonsterId) || (steal && (rune4.EquippedMonster?.Weight < weight)))) continue;
                                                        used4.Add(rune4.Id);

                                                        foreach (RuneType type5 in typeList)
                                                        {
                                                            foreach (string stat5 in statList)
                                                            {
                                                                foreach (Rune rune5 in typedStattedSlottedRunes[type5][stat5][RuneSlot.FIVE])
                                                                {

                                                                    if (used5.Contains(rune5.Id)) continue;
                                                                    if (!((rune5.EquippedOn == "") || (rune5.EquippedOn == _req.MonsterId) || (steal && (rune5.EquippedMonster?.Weight < weight)))) continue;
                                                                    used5.Add(rune5.Id);

                                                                    foreach (RuneType type6 in typeList)
                                                                    {
                                                                        foreach (string stat6 in statList)
                                                                        {
                                                                            foreach (Rune rune6 in typedStattedSlottedRunes[type6][stat6][RuneSlot.SIX])
                                                                            {

                                                                                if (used6.Contains(rune6.Id)) continue;
                                                                                if (!((rune6.EquippedOn == "") || (rune6.EquippedOn == _req.MonsterId) || (steal && (rune6.EquippedMonster?.Weight < weight)))) continue;
                                                                                used6.Add(rune6.Id);

                                                                                RuneSet set = new RuneSet();

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
                        _req.PermCount = counter;
                    }

                    _req.PermProgress = (int)(((float)runeOneCounter ) / ((float)runeOneTotal)*100);
                }
            }
            used1.Clear();

        }
        _req.PermProgress = (int)(((float)runeOneCounter) / ((float)runeOneTotal) * 100);
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

        long result = runeOneCount * runeTwoCount * runeThreeCount * runeFourCount * runeFiveCount * runeSixCount;

        return result;
    }


}