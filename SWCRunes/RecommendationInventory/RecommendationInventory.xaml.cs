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
        IRecommendedMonster recommendedMonster = (IRecommendedMonster)((ListView)sender).SelectedItem;
        origMonsterDisplay.BindingContext = recommendedMonster.Original;
        newMonsterDisplay.BindingContext = recommendedMonster.Updated;

        
        _viewModel.ChangeSelectedMonster(recommendedMonster);
        

    }

    void recommendList_Refreshing(System.Object sender, System.EventArgs e)
    {
        //_viewModel.AddAdditional();
    }

    void equipBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.EquipSelectedSet();
    }

    void requestList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        _viewModel.ChangeSelectedRequest();
        
    }
}
