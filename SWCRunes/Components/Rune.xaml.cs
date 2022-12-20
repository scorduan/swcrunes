namespace SWCRunes.Components;
using SWCRunesLib;


public partial class Rune : ContentView
{
    public Rune()
    {



        InitializeComponent();
        runeAttributes.Add(attr1);
        runeAttributes.Add(attr2);
        runeAttributes.Add(attr3);
        runeAttributes.Add(attr4);
        runeAttributes.Add(attr5);
        runeAttributes.Add(attr5);
        runeAttributes.Add(attr5);
        runeAttributes.Add(attr5);
        runeAttributes.Add(attr5);
        runeAttributes.Add(attr5);
        this.BindingContextChanged += new EventHandler(BindingContext_Changed);
    }

    private void BindingContext_Changed(object sender, EventArgs e)
    {
        if (this.BindingContext!=null) AddAttributes((SWCRunesLib.Rune)this.BindingContext);
    }

    private List<RuneAttribute> runeAttributes = new List<RuneAttribute>();

    private void AddAttributes(SWCRunesLib.Rune r)
    {
        int i=0;
        
        //<components:RuneAttribute Text="ATK: " Value="{Binding ATKP, Converter={StaticResource int3ToPerc}, StringFormat='{0}%'}" WidthRequest="75"/>
        if (r.ATKP > 0) runeAttributes[i++].UpdateSettings("ATK: ", convert(r.ATKP)+"%");
        if (r.ATKF > 0) runeAttributes[i++].UpdateSettings("ATK: ", r.ATKF.ToString());
        if (r.DEFP > 0) runeAttributes[i++].UpdateSettings("DEF: ", convert(r.DEFP)+"%");
        if (r.DEFF > 0) runeAttributes[i++].UpdateSettings("DEF: ", r.DEFF.ToString());
        if (r.HPP > 0) runeAttributes[i++].UpdateSettings("HP: ", convert(r.HPP)+"%");
        if (r.HPF > 0) runeAttributes[i++].UpdateSettings("HP: ", r.HPF.ToString()) ;
        if (r.SPD > 0) runeAttributes[i++].UpdateSettings("SPD: ", r.SPD.ToString());
        if (r.CR > 0) runeAttributes[i++].UpdateSettings("CR: ", convert(r.CR)+"%");
        if (r.CD > 0) runeAttributes[i++].UpdateSettings("CD: ", convert(r.CD)+"%");
        if (r.ACC > 0) runeAttributes[i++].UpdateSettings("ACC: ", convert(r.ACC)+"%");
        if (r.RES > 0) runeAttributes[i++].UpdateSettings("RES: ", convert(r.RES)+"%");
        if (r.PR > 0) runeAttributes[i++].UpdateSettings("PR: ", convert(r.PR)+"%");
        if (r.EV > 0) runeAttributes[i++].UpdateSettings("EV: ", convert(r.EV)+"%");

    }

    
    private string convert(int value)
    {
        return ((int)value / 10f).ToString();
    }

}
