namespace SWCRunes.Components;

public partial class RuneAttribute : ContentView
{
	public RuneAttribute()
	{
		InitializeComponent();
        
    }


    public void UpdateSettings(string text, string value)
    {
        textLabel.Text = text;
        valueLabel.Text = value;
    }

}
