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

    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.AddNewMonster();
    }

    void Upd_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SaveSelected();
    }


    void Del_Clicked(System.Object sender, System.EventArgs e)
    {
        
		_viewModel.RemoveSelected();
    }

    void unequipBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.UnequipSelected();
    }

}
