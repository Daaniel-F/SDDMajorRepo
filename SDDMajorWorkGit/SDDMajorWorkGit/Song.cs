﻿using System;
using SQLite;
namespace SDDMajorWorkGit
{
	public class Song
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Artist { get; set; }
	}
}

