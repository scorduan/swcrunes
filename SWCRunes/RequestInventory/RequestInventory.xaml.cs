namespace SWCRunes;
using SWCRunesLib;

public partial class RequestInventory : ContentPage
{
	public RequestInventory(RequestInventoryViewModel viewModel, SimulationService simulationService)
	{
		this.BindingContext = viewModel;
		this._viewModel = viewModel;
        
        InitializeComponent();
	}

    private RequestInventoryViewModel _viewModel;


    void requestList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
	{
        
        _viewModel.SelectedRequestChanged();
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


    void Del_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.RemoveSelected();
    }

    void Upd_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SaveSelectedRequest();
    }

    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.AddNewRequestToList();
    }

    void Execute_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.ProcessCurrent();
        DateTime time = DateTime.Now;

    }

    void statSelector_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        _viewModel.UpdateSelectedStats(e.CurrentSelection);
    }

    void newStatSelector_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        _viewModel.UpdateNewSelectedStats(e.CurrentSelection);
    }

    void Picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        _viewModel.GeneralSelectedIndexChanged();
    }

    void NewPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        _viewModel.NewGeneralSelectedIndexChanged();
    }

    void monsterPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        _viewModel.UpdateNewRequestMonster();
    }
}
