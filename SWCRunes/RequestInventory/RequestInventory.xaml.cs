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
		_viewModel.ChangeSelectedRequest((Request)((ListView)sender).SelectedItem);

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
}
