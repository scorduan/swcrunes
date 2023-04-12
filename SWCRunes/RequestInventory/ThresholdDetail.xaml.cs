namespace SWCRunes;

public partial class ThresholdDetail : ContentPage
{
	public ThresholdDetail(RequestInventoryViewModel viewModel)
	{
		
		InitializeComponent();
        _viewModel = viewModel;
         this.BindingContext = _viewModel;
    }
	private RequestInventoryViewModel _viewModel;

    protected override void OnAppearing()
    {
       

       

    }

    void save_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SaveThreshold(_viewModel.SelectedThreshold);
        Shell.Current.GoToAsync("..");
    }
}
