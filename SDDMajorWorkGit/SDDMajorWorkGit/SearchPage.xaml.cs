using Microsoft.Maui.Controls;
using SDDMajorWorkGit.Models;
using Plugin.Maui.Audio;
using System.Threading;
using System.Diagnostics;

namespace SDDMajorWorkGit;

public partial class SearchPage : ContentPage
{
	private IAudioManager AudioManager;

	public Song selectedSong;
	public Playlist selectedPlaylist;
    public AudioPlayer audioPlayer;

    public string songAddress;
    public bool audioPlayerExists = false;
	public bool songPlaying = false;
    public string addToPlaylist;

    public SearchPage(IAudioManager audioManager)
	{
		InitializeComponent();

		AudioManager = audioManager;

		//Collection view gets content from SongRepo
		songList.ItemsSource = App.SongRepo.GetAllSongs();
		PlaylistList.ItemsSource = App.PlaylistRepo.GetAllPlaylists();

        AddToPlaylistDisable();
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

    async void SongList_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
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
            songPlaying = true;
            AddToPlaylistButton.IsVisible = true;

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
            songPlaying = true;

            //Animate progress bar for length of song
            await progressBar.ProgressTo(1, (uint)audioPlayer.Duration * 1000, Easing.Linear);
        }
    }

    void AddToPlaylistButton_Clicked(System.Object sender, System.EventArgs e)
    {
        AddToPlaylistEnable();
    }

    void PlaylistList_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        selectedPlaylist = e.CurrentSelection[0] as Playlist;

		if (selectedPlaylist.Song1 == null)
		{
			selectedPlaylist.Song1 = selectedSong.Name;

			App.PlaylistRepo.Update(selectedPlaylist);
		}
		else if (selectedPlaylist.Song2 == null)
        {
            selectedPlaylist.Song2 = selectedSong.Name;

            App.PlaylistRepo.Update(selectedPlaylist);
        }
        else if (selectedPlaylist.Song3 == null)
        {
            selectedPlaylist.Song3 = selectedSong.Name;

            App.PlaylistRepo.Update(selectedPlaylist);
        }
        else if (selectedPlaylist.Song4 == null)
        {
            selectedPlaylist.Song4 = selectedSong.Name;

            App.PlaylistRepo.Update(selectedPlaylist);
        }
        else if (selectedPlaylist.Song5 == null)
        {
            selectedPlaylist.Song5 = selectedSong.Name;

            App.PlaylistRepo.Update(selectedPlaylist);
        }
        else
        {
            DisplayAlert("PLAYLIST FULL", "Playlist capacity reached: 5 songs", "Ok");
        }

        AddToPlaylistDisable();
    }

    void AddToPlaylistCancel_Clicked(System.Object sender, System.EventArgs e)
    {
        AddToPlaylistDisable();
    }

    void PauseButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (songPlaying == true)
        {
            audioPlayer.Pause();
            songPlaying = false;
            progressBar.Progress = audioPlayer.CurrentPosition / audioPlayer.Duration * 1000;
        }
        else if (songPlaying == false)
        {
            audioPlayer.Play();
            songPlaying = true;
            progressBar.ProgressTo(1, (uint)(audioPlayer.Duration - audioPlayer.CurrentPosition) * 1000, Easing.Linear);
        }
    }

    public void AddToPlaylistEnable()
    {
        PlaylistList.ItemsSource = App.PlaylistRepo.GetAllPlaylists();

        PlaylistList.IsEnabled = true;
        AddToPlaylist.IsEnabled = true;
        AddToPlaylistCancel.IsEnabled = true;
        PlaylistList.IsVisible = true;
        AddToPlaylist.IsVisible = true;
        AddToPlaylistCancel.IsVisible = true;
    }

    public void AddToPlaylistDisable()
    {
        PlaylistList.IsEnabled = false;
        AddToPlaylist.IsEnabled = false;
        AddToPlaylistCancel.IsEnabled = false;
        PlaylistList.IsVisible = false;
        AddToPlaylist.IsVisible = false;
        AddToPlaylistCancel.IsVisible = false;
    }
}
