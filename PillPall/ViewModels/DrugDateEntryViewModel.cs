using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PillPall.Data;
using PillPall.Models;

namespace PillPall.ViewModels
{
    public partial class DrugDateEntryViewModel : ObservableObject
	{
        [ObservableProperty]
        public ObservableCollection<DrugItem> drugs = new();

        [ObservableProperty]
        public ObservableCollection<DateItem> dates = new();

        [ObservableProperty]
        public string dayOfWeek;

        [ObservableProperty]
        public TimeSpan time;

        [ObservableProperty]
        public string dose;

        [ObservableProperty]
        public int drugID;

        [ObservableProperty]
        public DateItem item;

        public int something { get; set; }

        DrugItemDatabase drugDB;
        DateItemDatabase dateDB;

        public DrugDateEntryViewModel(DrugItemDatabase drugItemDatabase, DateItemDatabase dateItemDatabase)
		{
            drugDB = drugItemDatabase;
            dateDB = dateItemDatabase;
        }

        public async Task getDrugs()
        {
            var items = await drugDB.GetItemsAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Drugs.Clear();
                foreach (var item in items)
                    Drugs.Add(item);

            });
        }
        public async Task getDates()
        {
            var items = await dateDB.GetItemsAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Dates.Clear();
                foreach (var item in items)
                    Dates.Add(item);

            });
        }

        public async Task OnSaveClicked()
        {
            //AssembleDateItemObject();
            if (string.IsNullOrWhiteSpace(Item.DayOfWeek))
            {
                await Application.Current.MainPage.DisplayAlert("Day Required", "Please choose a weekday.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Item.DrugName))
            {
                await Application.Current.MainPage.DisplayAlert("Drug Required", "Please choose a drug.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(Item.Dose))
            {
                await Application.Current.MainPage.DisplayAlert("Dose Required", "Please write the dose.", "OK");
                return;
            }

            await dateDB.SaveItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }

        public async Task OnDeleteClicked()
        {
            //AssembleDateItemObject();
            if (Item.ID == 0)
                return;
            await dateDB.DeleteItemAsync(Item);
            await Shell.Current.GoToAsync("..");
        }
    }
}

