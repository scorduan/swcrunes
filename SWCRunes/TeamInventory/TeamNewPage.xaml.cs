namespace SWCRunes;

public partial class TeamNewPage : ContentPage
{
	public TeamNewPage(TeamInventoryViewModel viewModel)
    {
        this.BindingContext = viewModel;
        _viewModel = viewModel;
        InitializeComponent();
    }


    private TeamInventoryViewModel _viewModel;

    void Save_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SaveSelected();
        Shell.Current.GoToAsync("..");
    }
}
