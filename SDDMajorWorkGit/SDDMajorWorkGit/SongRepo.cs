using System;
using SQLite;
using SDDMajorWorkGit.Models;
namespace SDDMajorWorkGit
{
    public class SongRepo
    {
        private string _dbPath;
        private SQLiteConnection conn;

        //Get dbPath from MauiProgram class
        public SongRepo(string dbPath)
        {
            _dbPath = dbPath;
        }

        //Initialises database connection and creates database if one doesn't exist
        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Song>();
        }

        //Gets all entries from the database
        public List<Song> GetAllSongs()
        {
            Init();
            return conn.Table<Song>().ToList();
        }

        //Adds entry to the database
        public void Add(Song song)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(song);
        }

        //Deletes entries from the database based on Id primary key
        public void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new { Id = id });
        }
    }
}

