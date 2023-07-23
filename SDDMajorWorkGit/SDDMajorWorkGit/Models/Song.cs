using System;
using SQLite;
namespace SDDMajorWorkGit.Models
{
	[Table("song")]
	public class Song
	{
		[PrimaryKey, AutoIncrement, Column("Id")]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Artist { get; set; }
		public string Cover { get; set; }
		public string Music { get; set; }
	}
}

