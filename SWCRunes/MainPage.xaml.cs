namespace SWCRunes;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		/*
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
		*/
		
		MonsterStorage monStore = RuneSerializer.ReadMonstersFromFile("monsters.data");
        RuneStorage runeStore = RuneSerializer.ReadRunesFromFile("runes.data");
        RequestStorage reqStore = RuneSerializer.ReadRequestsFromFile("requests.data");

    }
}


