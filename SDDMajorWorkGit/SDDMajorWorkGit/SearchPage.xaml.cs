using Microsoft.Maui.Controls;

namespace SDDMajorWorkGit;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        collectionView.ItemsSource = await App.Database.GetSongsAsync();
    }
}
