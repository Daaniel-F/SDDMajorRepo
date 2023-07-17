using SQLite;

namespace SDDMajorWorkGit;

public partial class App : Application
{
	private static Database database;

    public static Database Database
	{
		get
		{
			if (database == null)
			{
				database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "songs.db3"));

                string[] songNames = { "Baby Don't Hurt Me", "Cupid", "Am I Dreaming" };
                string[] songArtists = { "David Guetta", "FIFTY FIFTY", "Metro Boomin" };

                int i = 0;
                while (i <= songNames.Length)
				{
					App.Database.SaveSongAsync(new Song
					{
						Name = songNames[i],
						Artist = songArtists[i]
					});
					i++;
				}
			}

			return database;
		}
	}

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}

