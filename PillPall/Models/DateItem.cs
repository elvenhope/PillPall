using System;
using System.Collections.ObjectModel;
using SQLite;

namespace PillPall.Models
{
	public class DateItem
	{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
        public string Dose { get; set; }
        public int DrugID { get; set; }
    }
}

