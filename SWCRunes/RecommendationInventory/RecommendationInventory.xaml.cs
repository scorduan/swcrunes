namespace SWCRunes;
using SWCRunesLib;

public partial class RecommendationInventory : ContentPage
{
	public RecommendationInventory(RecommendationInventoryViewModel viewModel)
	{
		BindingContext = viewModel;
		_viewModel = viewModel;
		InitializeComponent();
	}

	private RecommendationInventoryViewModel _viewModel;
    private void OnProcessClicked(object sender, EventArgs e)
    {
		//_viewModel.Optimize();
    }

    void recommendList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        monsterDisplay.BindingContext = ((ListView)sender).SelectedItem;
        _viewModel.ChangeSelectedMonster((RecommendedMonster)((ListView)sender).SelectedItem);

    }

    void recommendList_Refreshing(System.Object sender, System.EventArgs e)
    {
        //_viewModel.AddAdditional();
    }

    void equipBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.EquipSelectedSet();
    }
}
