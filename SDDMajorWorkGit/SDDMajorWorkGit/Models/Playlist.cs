using System;
using SQLite;

namespace SDDMajorWorkGit.Models
{
	[Table("playlist")]
	public class Playlist
	{
		[PrimaryKey, AutoIncrement, Column("Id")]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Song1 { get; set; }
		public string Song2 { get; set; }
		public string Song3 { get; set; }
		public string Song4 { get; set; }
		public string Song5 { get; set; }
		public string Cover { get; set; }
	}
}

