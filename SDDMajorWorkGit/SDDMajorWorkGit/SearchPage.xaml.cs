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
}
