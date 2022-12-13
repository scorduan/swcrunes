using System.Collections.Generic;
public class Optimizer
{
    public Optimizer(RuneStorage vRunes, MonsterStorage vMonsters, RequestStorage vRequests)
    {
        slottedRunes[Rune.RuneSlot.ONE]=new List<Rune>();
        slottedRunes[Rune.RuneSlot.TWO]=new List<Rune>();
        slottedRunes[Rune.RuneSlot.THREE]=new List<Rune>();
        slottedRunes[Rune.RuneSlot.FOUR]=new List<Rune>();
        slottedRunes[Rune.RuneSlot.FIVE]=new List<Rune>();

        slottedRunes[Rune.RuneSlot.SIX]=new List<Rune>();
        foreach (Rune aRune in vRunes.Runes)
        {
            slottedRunes[aRune.Slot].Add(aRune);
        }

        foreach (Monster monster in vMonsters.Monsters)
        {
            monsters.Add(monster.Name,monster);
        }

        requests=vRequests;

    }

    private Dictionary<Rune.RuneSlot,List<Rune>> slottedRunes = new Dictionary<Rune.RuneSlot, List<Rune>>();

    private Dictionary<string,Monster> monsters = new Dictionary<string, Monster>();

    private RequestStorage requests;

    private int level;

    public Request req;

    public List<Recommendation> Process()
    {
        List<Recommendation> recoms = new List<Recommendation>();
        foreach (Request req in requests.Requests)
        {
            Recommendation rec=ProcessReq(req);
            recoms.Add(rec);
        }

        return recoms;

    }

    public Recommendation ProcessReq(Request req)
    {
        Recommendation rec = new Recommendation();
        rec.MonsterName=req.MonsterName;
        string monsterJson = monsters[req.MonsterName].ToJson();
        List<RuneSet> runeSets = BuildRunePermutations();

        List<Monster> results = new List<Monster>();
        

        foreach (RuneSet set in runeSets)
        {
            Monster m = Monster.FromJson(monsterJson);
            m.Runes=set;
            Monster resultMon = m.GetModified();
            resultMon.Runes=set;
            results.Add(resultMon);
        }
        MonsterComparer comp = new MonsterComparer(req);

        this.req=req;
        level=1;
        results.Sort(CompareMonsters);

        rec.RecommendedSetup=results;

        return rec;
    }

    

    public List<RuneSet> BuildRunePermutations()
    {
        List<RuneSet> perms = new List<RuneSet>();

        foreach (Rune rune1 in slottedRunes[Rune.RuneSlot.ONE])
        {
            foreach (Rune rune2 in slottedRunes[Rune.RuneSlot.TWO])
            {
                foreach (Rune rune3 in slottedRunes[Rune.RuneSlot.THREE])
                {
                    foreach (Rune rune4 in slottedRunes[Rune.RuneSlot.FOUR])
                    {
                        foreach (Rune rune5 in slottedRunes[Rune.RuneSlot.FIVE])
                        {
                            foreach (Rune rune6 in slottedRunes[Rune.RuneSlot.SIX])
                            {
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
                    }
                }
            }
        }

        return perms;
    }


    public int CompareMonsters(Monster left, Monster right)
    {
        int result=0;
        int leftVal=0;
        int rightVal=0;
        int tolerance =0;
        string attr=req.PrimaryAttribute;
        if (level==2) attr = req.SecondaryAttribute;
        if (level==3) attr = req.TertiaryAttribute;

        if (attr=="ATK")
        {
            leftVal=left.ATK;
            rightVal=right.ATK;   

        }
        if (attr=="DEF")
        {
            leftVal=left.DEF;
            rightVal=right.DEF;

        }
        if (attr=="HP")
        {
            leftVal=left.HP;
            rightVal=right.HP;

        }
        if (attr=="SPD")
        {
            leftVal=left.SPD;
            rightVal=right.SPD;

        }
        if (attr=="CR")
        {
            leftVal=left.CR;
            rightVal=right.CR;
 
        }
        if (attr=="CD")
        {
            leftVal=left.CD;
            rightVal=right.CD;
 
        }
        if (attr=="ACC")
        {
            leftVal=left.ACC;
            rightVal=right.ACC;

        }
        if (attr=="RES")
        {
            leftVal=left.RES;
            rightVal=right.RES;

        }
        if (attr=="PR")
        {
            leftVal=left.PR;
            rightVal=right.PR;

        }
        if (attr=="EV")
        {
            leftVal=left.EV;
            rightVal=right.EV;

        }
        if (attr=="EffectiveHP")
        {
            leftVal=left.EffectiveHP;
            rightVal=right.EffectiveHP;
 
        }
        if (attr=="HPLoss100100")
        {
            leftVal=left.HPLoss100100;
            rightVal=right.HPLoss100100;

        }
        if (attr=="Damage")
        {
            leftVal=left.Damage;
            rightVal=right.Damage;
 
        }
        if (attr=="BasicDamage")
        {
            leftVal=left.BasicDamage;
            rightVal=right.BasicDamage;
 
        }

    
        //Might later calculate this as a percentage
        tolerance=(int)(0.005 * (double)leftVal);

        

        if (leftVal-tolerance > rightVal)
        {
            result=1;
        } else if (rightVal - tolerance > leftVal)
        {
            result=-1;
        }
        else
        {
            if (level<3)
            {
                level++;
                result = CompareMonsters(left,right);
            }

        }


        return result;
    }

}