using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PillPall.Data;
using PillPall.Models;

namespace PillPall.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{
		DateItemDatabase dateDB;

		[ObservableProperty]
		public DateTime selectedDate;

        [ObservableProperty]
        public ObservableCollection<DateItem> dates = new();

        public MainViewModel(DateItemDatabase dateItemDatabase)
		{
			dateDB = dateItemDatabase;
		}

        async public Task getSpecificDates()
        {
            string Weekday = SelectedDate.DayOfWeek.ToString();
            var items = await dateDB.GetSpecificDayAsync(Weekday);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Dates.Clear();
                foreach (var item in items)
                    Dates.Add(item);
            });
        }
    }
}

