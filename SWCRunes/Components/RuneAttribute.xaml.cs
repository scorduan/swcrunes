namespace SWCRunes.Components;

public partial class RuneAttribute : ContentView
{
	public RuneAttribute()
	{
		InitializeComponent();


        valueLabel.BindingContext = this;
        valueLabel.SetBinding(Label.TextProperty,"Value");
        
    }

    public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(string),typeof(RuneAttribute),"");
	public string Value
	{
		get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty,value);
    }

    public void updateLabel(string text)
    {
        textLabel.Text = text;
    }

}
