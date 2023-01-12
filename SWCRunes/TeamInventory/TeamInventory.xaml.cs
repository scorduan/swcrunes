using SWCRunesLib;

namespace SWCRunes;

public partial class TeamInventory : ContentPage
{
	public TeamInventory(TeamInventoryViewModel viewModel)
	{
		this.BindingContext = viewModel;
		_viewModel = viewModel;
		InitializeComponent();
	}


	private TeamInventoryViewModel _viewModel;

    void add_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SelectNewTeam();
        Shell.Current.GoToAsync("//teams/new");

    }

    void edit_Clicked(System.Object sender, System.EventArgs e)
    {
        Team team = (Team)((Button)sender).BindingContext;
        _viewModel.ChangeSelectedTeam(team);
        Shell.Current.GoToAsync("//teams/new");
    }

    void deleted_Clicked(System.Object sender, System.EventArgs e)
    {
        Team team = (Team)((Button)sender).BindingContext;
        _viewModel.DeleteTeam(team);
    }
}
