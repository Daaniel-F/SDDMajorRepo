using System;
using SQLite;
using SDDMajorWorkGit.Models;
namespace SDDMajorWorkGit
{
    public class SongRepo
    {
        string _dbPath;
        private SQLiteConnection conn;

        public SongRepo(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Song>();
        }

        public List<Song> GetAllSongs()
        {
            Init();
            return conn.Table<Song>().ToList();
        }

        public void Add(Song song)
        {
            Init();
            conn.Insert(song);
        }

        public void Delete(int id)
        {
            Init();
            conn.Delete(new { Id = id });
        }
    }
}

