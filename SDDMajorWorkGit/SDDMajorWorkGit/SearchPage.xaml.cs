using Microsoft.Maui.Controls;
using SDDMajorWorkGit.Models;
using Plugin.Maui.Audio;
using System.Threading;

namespace SDDMajorWorkGit;

public partial class SearchPage : ContentPage
{
	private IAudioManager AudioManager;

	public string songAddress;
	public Song selectedSong;

	public bool audioPlayerExists = false;
	public bool songPlaying = false;

	public AudioPlayer audioPlayer;

	public string addToPlaylist;

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

		//Checks if audioPlayer is already playing a song and disposes of it if so
		if (audioPlayerExists == false)
		{
			audioPlayerExists = true;

			//Creates a new audio player
            audioPlayer = (AudioPlayer)AudioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(songAddress));
            audioPlayer.Play();

            //Animate progress bar for length of song
            await progressBar.ProgressTo(1, (uint)audioPlayer.Duration * 1000, Easing.Linear);
        }
		else if (audioPlayerExists == true)
		{
			audioPlayer.Dispose();
			progressBar.Progress = 0;

            //Creates a new audio player
            audioPlayer = (AudioPlayer)AudioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(songAddress));
            audioPlayer.Play();

            //Animate progress bar for length of song
            await progressBar.ProgressTo(1, (uint)audioPlayer.Duration * 1000, Easing.Linear);
        }
    }

    async void addToPlaylist_Clicked(System.Object sender, System.EventArgs e)
    {
		addToPlaylist = await DisplayActionSheet("Add To Playlist", "Cancel", null, "Playlist 1", "Playlist 2");
    }
}
