namespace SWCRunes;
using SWCRunesLib;

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
		_viewModel.ChangeSelectedMonster((Monster)((ListView)sender).SelectedItem);

    }

    void Save_Clicked(System.Object sender, System.EventArgs e)
    {
		_viewModel.SaveNewMonster();
    }

    void NewBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		_viewModel.AddNew();
    }

    void Del_Clicked(System.Object sender, System.EventArgs e)
    {
		_viewModel.RemoveSelected();
    }
}
