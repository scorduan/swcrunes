namespace SWCRunes.Components;
using SWCRunesLib;


public partial class Rune : ContentView
{
    public Rune()
    {
        InitializeComponent();
        this.BindingContextChanged += new EventHandler(BindingContext_Changed);
    }

    private void BindingContext_Changed(object sender, EventArgs e)
    {
        if (this.BindingContext!=null) AddAttributes((SWCRunesLib.Rune)this.BindingContext);
    }

    private void AddAttributes(SWCRunesLib.Rune r)
    {
        //<components:RuneAttribute Text="ATK: " Value="{Binding ATKP, Converter={StaticResource int3ToPerc}, StringFormat='{0}%'}" WidthRequest="75"/>
        if (r.ATKP > 0) setupAttribute(r, "ATK: ", "ATKP");
        if (r.ATKF > 0) setupAttribute(r, "ATK: ", "ATKF", false);
        if (r.DEFP > 0) setupAttribute(r, "DEF: ", "DEFP");
        if (r.DEFF > 0) setupAttribute(r, "DEF: ", "DEFF", false);
        if (r.HPP > 0) setupAttribute(r, "HP: ", "HPP");
        if (r.HPF > 0) setupAttribute(r, "HP: ", "HPF", false);
        if (r.SPD > 0) setupAttribute(r, "SPD: ", "SPD");
        if (r.CR > 0) setupAttribute(r, "CR: ", "CR");
        if (r.CD > 0) setupAttribute(r, "CD: ", "CD");
        if (r.ACC > 0) setupAttribute(r, "ACC: ", "ACC");
        if (r.RES > 0) setupAttribute(r, "RES: ", "RES");
        if (r.PR > 0) setupAttribute(r, "PR: ", "PR");
        if (r.EV > 0) setupAttribute(r, "EV: ", "EV");

    }

    private void setupAttribute(SWCRunesLib.Rune r, string text, string value, bool isPerc = true)
    {
        RuneAttribute ra = new RuneAttribute();

        
        ra.BindingContext = r;
        if (isPerc)
        {
            ra.SetBinding(RuneAttribute.ValueProperty, value, BindingMode.Default, new Int3ToPercConverter(), "{0}%");
        }
        else
        {
            ra.SetBinding(RuneAttribute.ValueProperty, value);
        }

        this.mainContainer.Add(ra);
        ra.updateLabel(text);
    }
}
