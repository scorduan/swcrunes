namespace SWCRunesLib;
using System.Collections.Generic;
public class MonsterComparer : IComparer<Monster>
{
    public MonsterComparer(Request pReq)
    {
        req=pReq;
        level=1;
    }

    private Request req;
    int level;
    public int Compare(Monster left, Monster right)
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
            tolerance = 50;
        }
        if (attr=="DEF")
        {
            leftVal=left.DEF;
            rightVal=right.DEF;
            tolerance = 50; 
        }
        if (attr=="HP")
        {
            leftVal=left.HP;
            rightVal=right.HP;
            tolerance = 500;   
        }
        if (attr=="SPD")
        {
            leftVal=left.SPD;
            rightVal=right.SPD;
            tolerance = 5;   
        }
        if (attr=="CR")
        {
            leftVal=left.CR;
            rightVal=right.CR;
            tolerance = 5;   
        }
        if (attr=="CD")
        {
            leftVal=left.CD;
            rightVal=right.CD;
            tolerance = 5;   
        }
        if (attr=="ACC")
        {
            leftVal=left.ACC;
            rightVal=right.ACC;
            tolerance = 5;   
        }
        if (attr=="RES")
        {
            leftVal=left.RES;
            rightVal=right.RES;
            tolerance = 5;  
        }
        if (attr=="PR")
        {
            leftVal=left.PR;
            rightVal=right.PR;
            tolerance = 5;
        }
        if (attr=="EV")
        {
            leftVal=left.EV;
            rightVal=right.EV;
            tolerance = 5;   
        }
        if (attr=="EffectiveHP")
        {
            leftVal=left.EffectiveHP;
            rightVal=right.EffectiveHP;
            tolerance = 500;   
        }
        if (attr=="HPLoss100100")
        {
            leftVal=left.HPLoss100100;
            rightVal=right.HPLoss100100;
            tolerance = 500;   
        }
        if (attr=="Damage")
        {
            leftVal=left.Damage;
            rightVal=right.Damage;
            tolerance = 50;   
        }
        if (attr=="BasicDamage")
        {
            leftVal=left.BasicDamage;
            rightVal=right.BasicDamage;
            tolerance = 1000;   
        }

        

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
                result = Compare(left,right);
            }

        }


        return result;
    }
}