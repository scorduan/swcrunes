namespace SWCRunes;

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
		_viewModel.Optimize();
    }
}
