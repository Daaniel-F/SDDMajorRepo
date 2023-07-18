using System;
using SQLite;
namespace SDDMajorWorkGit.Models
{
	[Table("songs")]
	public class Song
	{
		[PrimaryKey, AutoIncrement, Column("Id")]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Artist { get; set; }
	}
}

