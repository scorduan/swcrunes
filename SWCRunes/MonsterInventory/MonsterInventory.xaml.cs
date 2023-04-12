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


    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            _viewModel.SelectNewMonster();
            Shell.Current.GoToAsync("//monsters/detail");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

    }

    void edit_Clicked(System.Object sender, System.EventArgs e)
    {
        try
        {

        _viewModel.SelectedMonster = (Monster)((Button)sender).BindingContext;
        Shell.Current.GoToAsync("//monsters/detail");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

}
