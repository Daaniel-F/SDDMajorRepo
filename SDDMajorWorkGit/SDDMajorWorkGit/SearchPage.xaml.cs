using Microsoft.Maui.Controls;
using SDDMajorWorkGit.Models;
using Plugin.Maui.Audio;

namespace SDDMajorWorkGit;

public partial class SearchPage : ContentPage
{
	private IAudioManager AudioManager;

	public string songAddress;
	public Song selectedSong;

	public SearchPage(IAudioManager audioManager)
	{
		InitializeComponent();

		AudioManager = audioManager;

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

    async void songList_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
		//Gets database entries attached to selected song
		selectedSong = e.CurrentSelection[0] as Song;

		songAddress = selectedSong.Music;

		//Creates a new audio player
		var audioPlayer = AudioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(songAddress));
        audioPlayer.Play();
    }
}
