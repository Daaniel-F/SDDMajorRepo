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

