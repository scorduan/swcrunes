namespace SWCRunes;

public partial class RecommendationDetail : ContentPage
{
	public RecommendationDetail(RecommendationInventoryViewModel viewModel)
	{
        _viewModel = viewModel;
        InitializeComponent();
		
	}

	private RecommendationInventoryViewModel _viewModel;


	protected override void OnAppearing()
	{
		this.BindingContext = _viewModel.SelectedMonster;
	}
    void equipBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.EquipSelectedSet();
    }
}
