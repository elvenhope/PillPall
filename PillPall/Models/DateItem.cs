using System;
using System.Collections.ObjectModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace PillPall.Models
{
	public class DateItem
	{
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan Time { get; set; }
        public string Dose { get; set; }
        [ForeignKey(typeof(DrugItem))]
        public int DrugID { get; set; }
        public string DrugName { get; set; }

        public DateItem()
        {

        }
    }
}

