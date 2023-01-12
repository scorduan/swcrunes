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
        RecommendedMonster recommendedMonster = (RecommendedMonster)((ListView)sender).SelectedItem;

        
        _viewModel.ChangeSelectedMonster(recommendedMonster);
        Shell.Current.GoToAsync("recommendations/details");

    }


    void requestList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        try
        {
        _viewModel.ChangeSelectedRequest();
        }
        catch (Exception ex)
        {

        }


    }

    void view_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.ChangeSelectedMonster((RecommendedMonster)((Button)sender).BindingContext);
        Shell.Current.GoToAsync("detail");
    }

}
