using Plugin.Maui.Audio;
using SDDMajorWorkGit.Models;

namespace SDDMajorWorkGit;

public partial class LibraryPage : ContentPage
{
    public Playlist selectedPlaylist;
    public Song selectedSong;
    public AudioPlayer audioPlayer;

    public string playlistName;
    public bool audioPlayerExists;
    public string songAddress;

    public LibraryPage()
	{
		InitializeComponent();

        PlaylistList.ItemsSource = App.PlaylistRepo.GetAllPlaylists();
	}

    async void CreatePlaylist_Clicked(System.Object sender, System.EventArgs e)
    {
        playlistName = await DisplayPromptAsync("Create Playlist", "Please enter the playlist name");

        if (playlistName != null)
        {
            App.PlaylistRepo.Add(new Playlist
            {
                Name = playlistName
            });
        }

        PlaylistList.ItemsSource = App.PlaylistRepo.GetAllPlaylists();
    }

    void PlaylistList_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        selectedPlaylist = e.CurrentSelection[0] as Playlist;

        Song1.Text = selectedPlaylist.Song1;
        Song2.Text = selectedPlaylist.Song2;
        Song3.Text = selectedPlaylist.Song3;
        Song4.Text = selectedPlaylist.Song4;
        Song5.Text = selectedPlaylist.Song5;

        PlaylistContent.IsVisible = true;

        PlaylistList.ItemsSource = App.PlaylistRepo.GetAllPlaylists();
    }

    void PlayPlaylist_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}
