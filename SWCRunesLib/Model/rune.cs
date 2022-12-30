namespace SWCRunesLib;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public interface IRune
{
    public string Id { get; }
}

public class Rune :IRune
{

    

    internal Rune(string id = "")
    {
        _id = id;
    }


    public RuneSlot Slot {get;set;}
    public RuneType Type {get;set;}

    public int ATKP { get; set;}
    public int ATKF { get; set;}
    public int DEFP { get; set;}
    public int DEFF { get; set;}
    public int HPP { get; set;}
    public int HPF { get; set;}
    public int SPD { get; set;}
    public int CR { get; set;}
    public int CD { get; set;}
    public int ACC { get; set;}
    public int RES { get; set;}
    public int PR { get; set;}
    public int EV { get; set;}



    private string _id;

    public string Id { get => Id; }


    public string EquippedOn
    {
        get;
        set;
    } = "";

    public string ToJson()
    {
        return JsonSerializer.Serialize<Rune>(this);

    }

    public static Rune FromJson(string text)
    {
        return JsonSerializer.Deserialize<Rune>(text);
    }


}

public interface IRuneSet
{
    public Rune? RuneOne { get; set; }
    public Rune? RuneTwo { get; set; }
    public Rune? RuneThree { get; set; }
    public Rune? RuneFour { get; set; } 
    public Rune? RuneFive { get; set; } 
    public Rune? RuneSix { get; set; }

}


public class RuneSet : IRuneSet
{
    public Rune? RuneOne { get; set;} = null;
    public Rune? RuneTwo { get; set;} = null;
    public Rune? RuneThree { get; set;} = null;
    public Rune? RuneFour { get; set;} = null;
    public Rune? RuneFive { get; set;} = null;
    public Rune? RuneSix { get; set;}  = null;  
}

public class RuneStorage
{
    public List<Rune> Runes = new List<Rune>();



}

public enum RuneType
{
    Null, // 0
    Energy, // 1
    Guard, // 2
    Blade, // 3
    Rage, // 4
    Fatal, // 5
    Swift, // 6
    Focus, // 7
    Endure, // 8
    Foresight, // 9
    Assemble // 10


};
public enum RuneSlot
{
    ONE = 1,
    TWO = 2,
    THREE = 3,
    FOUR = 4,
    FIVE = 5,
    SIX = 6
};