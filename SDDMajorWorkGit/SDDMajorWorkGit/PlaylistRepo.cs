using System;
using SQLite;
using SDDMajorWorkGit.Models;
namespace SDDMajorWorkGit
{
	public class PlaylistRepo
	{
		private string dbPath;
		private SQLiteConnection conn;

		//Get dbPath from MauiProgram class
		public PlaylistRepo(string playlistDbPath)
		{
			dbPath = playlistDbPath;
		}

        //Initialises database connection and creates database if one doesn't exist
        public void Init()
		{
			conn = new SQLiteConnection(dbPath);
			conn.CreateTable<Playlist>();
		}

        //Gets all entries from the database
        public List<Playlist> GetAllPlaylists()
		{
			Init();
			return conn.Table<Playlist>().ToList();
		}

        //Adds entry to the database
        public void Add(Playlist playlist)
		{
			conn = new SQLiteConnection(dbPath);
			conn.Insert(playlist);
		}

        //Deletes entries from the database based on Id primary key
        public void Delete(int id)
		{
			conn = new SQLiteConnection(dbPath);
			conn.Delete(new { Id = id });
		}

		public int Update(Playlist playlist)
		{
			conn = new SQLiteConnection(dbPath);
			return conn.Update(playlist);
		}

		public List<Playlist> GetPlaylistNames(string name)
		{
			conn = new SQLiteConnection(dbPath);
			return conn.Table<Playlist>().Where(i => i.Name.Contains(name)).ToList();
		}
	}
}

