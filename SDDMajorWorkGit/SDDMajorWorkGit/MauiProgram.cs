using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace SDDMajorWorkGit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		string songDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "song_repo.db");
		string playlistDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "playlist_repo.db");

		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<SongRepo>(s, songDbPath));
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<PlaylistRepo>(s, playlistDbPath));

		builder.Services.AddSingleton(AudioManager.Current);
		builder.Services.AddSingleton<SearchPage>();
		builder.Services.AddSingleton<LibraryPage>();

        return builder.Build();
	}
}

