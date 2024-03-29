﻿namespace SWCRunes;

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
		_viewModel.SaveUpdatedRune();
	}

    void OnDelClicked(System.Object sender, System.EventArgs e)
    {
        _viewModel.RemoveRune((SWCRunesLib.Rune)((Button)sender).BindingContext);
    }

}
