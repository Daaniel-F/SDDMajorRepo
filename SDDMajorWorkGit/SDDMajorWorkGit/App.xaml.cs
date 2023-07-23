using SQLite;
using SDDMajorWorkGit.Models;

namespace SDDMajorWorkGit;

public partial class App : Application
{
    public static SongRepo SongRepo { get; private set; }

    //Arrays used to fill SongRepo
    public string[] songNames = { "Am I Dreaming", "Mona Lisa", "I Wonder" };
    public string[] songArtists = { "Metro Boomin", "Dominic Fike", "Kanye West" };

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
                Artist = songArtists[i]
            });

            i++;
        }
    }
}

