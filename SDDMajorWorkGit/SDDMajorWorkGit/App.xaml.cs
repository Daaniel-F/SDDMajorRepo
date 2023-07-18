using SQLite;
using SDDMajorWorkGit.Models;

namespace SDDMajorWorkGit;

public partial class App : Application
{
    public static SongRepo SongRepo { get; private set; }

	public App(SongRepo songRepo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		SongRepo = songRepo;
    }
}

