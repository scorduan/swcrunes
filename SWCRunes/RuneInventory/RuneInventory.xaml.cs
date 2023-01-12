using SWCRunesLib;
namespace SWCRunes;

public partial class RuneInventory : ContentPage
{
	public RuneInventory(RuneInventoryViewModel viewModel)
	{
		this.BindingContext = viewModel;
		_viewModel = viewModel;
		InitializeComponent();
	}

	private RuneInventoryViewModel _viewModel;

    void OnAddClicked(System.Object sender, System.EventArgs e)
    {
		_viewModel.SaveNewRune();
    }

	void OnSaveClicked(System.Object sender, System.EventArgs e)
	{
        Rune rune = (Rune)((Button)sender).BindingContext;
		_viewModel.SaveUpdatedRune(rune);
	}

    void OnDelClicked(System.Object sender, System.EventArgs e)
    {
		Rune rune = (Rune)((Button)sender).BindingContext;
		_viewModel.DeleteRune(rune);
    }

    void ListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
		_viewModel.UpdateList();
    }
}
