using SQLite;
using SDDMajorWorkGit.Models;
using System.Drawing;

namespace SDDMajorWorkGit;

public partial class App : Application
{
    public static SongRepo SongRepo { get; private set; }

    //Arrays used to fill SongRepo
    public string[] songNames = { "Am I Dreaming", "Mona Lisa", "I Wonder", "All That" };
    public string[] songArtists = { "Metro Boomin", "Dominic Fike", "Kanye West", "Benjamin Tissot" };
    public string[] songCovers = { "song_cover_placeholder.jpeg", "song_cover_placeholder.jpeg", "song_cover_placeholder.jpeg", "song_cover_placeholder.jpeg" };
    public string[] songMusic = { null, null, null, "allthat.mp3" };

    public int i = 0;
    public bool dbFilled;

    public App(SongRepo songRepo)
	{
		InitializeComponent();

		MainPage = new AppShell();

        //Initialises SongRepo
        SongRepo = songRepo;

        //Calls Init to initialise database connection
        SongRepo.GetAllSongs();

        //Sets dbFilled to false unless otherwise set by another Preferences class
        Preferences.Set("dbFilled", false);
        dbFilled = Preferences.Get("dbFilled", false);

        //Statement should only run when app is first opened
        if (dbFilled == false)
        {
            PopulateSongRepo();
            Preferences.Set("dbFilled", true);
            dbFilled = Preferences.Get("dbFilled", false);
        }
    }

    //Fills SongRepo from arrays
    public void PopulateSongRepo()
    {
        while (i < songNames.Length)
        {
            SongRepo.Add(new Song
            {
                Name = songNames[i],
                Artist = songArtists[i],
                Cover = songCovers[i],
                Music = songMusic[i]
            });

            i++;
        }
    }
}

