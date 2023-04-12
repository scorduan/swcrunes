namespace SWCRunes;
using SWCRunesLib;

public partial class RequestDetail : ContentPage
{
	public RequestDetail(RequestInventoryViewModel viewModel)
	{

        try
        {
            InitializeComponent();
            _viewModel = viewModel;
            this.BindingContext = viewModel;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

	private RequestInventoryViewModel _viewModel;

    protected override void OnAppearing()
    {
        try
        {

            List<object> selectedStats = new List<object>();
            foreach (object stat in statSelector.ItemsSource)
            {
                if (_viewModel.SelectedRequest.FocusStats.Contains(stat.ToString()))
                {
                    selectedStats.Add(stat);
                }

            }

            statSelector.UpdateSelectedItems(selectedStats);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

    }

    void statSelector_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        _viewModel?.UpdateSelectedStats(e.CurrentSelection);
    }

    void Execute_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.ProcessCurrent();

    }

    void save_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SaveSelected();
        Shell.Current.GoToAsync("..");
    }

    void Edit_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SelectedThreshold = (StatThreshold)((Button)sender).BindingContext;
        Shell.Current.GoToAsync("//requests/detail/threshold");
    }

    void Del_Clicked(System.Object sender, System.EventArgs e)
    {
        StatThreshold remove = (StatThreshold)((Button)sender).BindingContext;
        _viewModel.RemoveThreshold(remove);
    }

    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SelectedThreshold = new StatThreshold();
        Shell.Current.GoToAsync("//requests/detail/threshold");
    }
}
