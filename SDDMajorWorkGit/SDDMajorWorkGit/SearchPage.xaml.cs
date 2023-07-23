using Microsoft.Maui.Controls;
using SDDMajorWorkGit.Models;

namespace SDDMajorWorkGit;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();

		//Collection view gets content from SongRepo
		songList.ItemsSource = App.SongRepo.GetAllSongs();
	}

	//Runs when search bar text is changed
	void SearchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
		if (string.IsNullOrWhiteSpace(e.NewTextValue))
		{
            //Displays all entries in SongRepo when search bar is empty
            songList.ItemsSource = App.SongRepo.GetAllSongs();
		}
		else
		{
			//Displays entries in SongRepo that contain the search value in the Name column
			songList.ItemsSource = App.SongRepo.GetAllSongs().Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
		}
    }
}
