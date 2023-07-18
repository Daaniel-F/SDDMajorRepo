using Microsoft.Maui.Controls;
using SDDMajorWorkGit.Models;

namespace SDDMajorWorkGit;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();

		App.SongRepo.Add(new Song
		{
			Name = "Hello",
			Artist = "Test"
		});

        songList.ItemsSource = App.SongRepo.GetAllSongs();
	}
}
