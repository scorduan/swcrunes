namespace SWCRunes;

public partial class MonsterInventory : ContentPage
{
	public MonsterInventory(MonsterInventoryViewModel viewModel)
	{
		this.BindingContext = viewModel;
		this._viewModel = viewModel;
		InitializeComponent();
	}

    private MonsterInventoryViewModel _viewModel;

	void monsterList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
	{
		monsterDisplay.BindingContext = ((ListView)sender).SelectedItem;
	}

    void Save_Clicked(System.Object sender, System.EventArgs e)
    {
		_viewModel.SaveNewMonster();
    }
}
