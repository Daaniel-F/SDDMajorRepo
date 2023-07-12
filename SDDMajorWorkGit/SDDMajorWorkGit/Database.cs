using System;
using SQLite;
namespace SDDMajorWorkGit
{
	public class Database
	{
		private readonly SQLiteAsyncConnection _database;

		//Creates a table only if one does not already exist
		public Database(string dbPath)
		{
			_database = new SQLiteAsyncConnection(dbPath);
			_database.CreateTableAsync<Song>();
		}

		//Accesses database table
		public Task<List<Song>> GetSongsAsync()
		{
			return _database.Table<Song>().ToListAsync();
		}

		//Create new database entry
		public Task<int> SaveSongAsync(Song song)
		{
			return _database.InsertAsync(song);
		}
	}
}

