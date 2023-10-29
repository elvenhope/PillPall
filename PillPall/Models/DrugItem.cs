using System;
using SQLite;

namespace PillPall.Models
{
	public class DrugItem
	{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}

