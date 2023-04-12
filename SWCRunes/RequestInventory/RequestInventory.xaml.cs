namespace SWCRunes;
using SWCRunesLib;
using SWCRunes.Model;

public partial class RequestInventory : ContentPage
{
	public RequestInventory(RequestInventoryViewModel viewModel, SimulationService simulationService)
	{
		this.BindingContext = viewModel;
		this._viewModel = viewModel;
        
        InitializeComponent();
	}

    private RequestInventoryViewModel _viewModel;




    void Del_Clicked(System.Object sender, System.EventArgs e)
    {
        ObservableRequest req = (ObservableRequest)((Button)sender).BindingContext;
        _viewModel.RemoveRequest(req);
    }

    void Upd_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SaveSelectedRequest();
    }

    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SelectNewRequest();
        Shell.Current.GoToAsync("//requests/detail");
    }



    void Picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        _viewModel.GeneralSelectedIndexChanged();
    }

    void NewPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        _viewModel.NewGeneralSelectedIndexChanged();
    }



    void edit_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SelectedRequest=(ObservableRequest)((Button)sender).BindingContext;
        Shell.Current.GoToAsync("//requests/detail");
    }

    void run_Clicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.SelectedRequest = (ObservableRequest)((Button)sender).BindingContext;
            _viewModel.ProcessCurrent();
    }

    void bogus_Clicked(System.Object sender, System.EventArgs e)
    {
        foreach (ObservableRequest ob in _viewModel.VisibleRequests)
        {
            ob.LastRun = DateTime.Now;
        }
    }

}
