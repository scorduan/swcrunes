namespace SWCRunes;
using SWCRunesLib;

public partial class RequestInventory : ContentPage
{
	public RequestInventory(RequestInventoryViewModel viewModel)
	{
		this.BindingContext = viewModel;
		this._viewModel = viewModel;
		InitializeComponent();
	}

    private RequestInventoryViewModel _viewModel;

	void requestList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
	{
        //requestDisplay.BindingContext = ((ListView)sender).SelectedItem;

        Request request = (Request)((ListView)sender).SelectedItem;
        List<object> selectedStats = new List<object>();
        foreach (object stat in statSelector.ItemsSource)
        {
            if (request.FocusStats.Contains(stat.ToString()))
            {
                selectedStats.Add(stat);
            }
            
        }
        _viewModel.ChangeSelectedRequest(request);
        statSelector.UpdateSelectedItems(selectedStats);
       // statSelector.SetBinding(statSelector.ItemsSource, new Bin)

    }

    void Save_Clicked(System.Object sender, System.EventArgs e)
    {
		_viewModel.SaveNewRequest();
    }

    void NewBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		_viewModel.AddNew();
    }

    void Del_Clicked(System.Object sender, System.EventArgs e)
    {
		_viewModel.RemoveSelected();
    }

    void Execute_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.ProcessCurrent();
    }

    void statSelector_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        _viewModel.UpdateSelectedStats(e.CurrentSelection);
    }

    void Picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        _viewModel.GeneralSelectedIndexChanged();
    }
}
