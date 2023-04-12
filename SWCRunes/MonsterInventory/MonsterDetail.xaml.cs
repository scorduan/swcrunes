namespace SWCRunes;
using SWCRunesLib;

public partial class MonsterDetail : ContentPage
{
	public MonsterDetail(MonsterInventoryViewModel viewModel)
	{
        try
        {
        
		_viewModel = viewModel;
		InitializeComponent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }

    }

	private MonsterInventoryViewModel _viewModel;

    protected override void OnAppearing()
    {
        this.BindingContext = _viewModel.SelectedMonster;
    }

    void save_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SaveSelected();
        Shell.Current.GoToAsync("..");
    }

    void editRequest_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            Shell.Current.GoToAsync("//requests/detail");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
        
    }

    void viewReccome_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("//recommendations");
    }
}
