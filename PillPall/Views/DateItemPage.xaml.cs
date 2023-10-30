using System.Collections.ObjectModel;
using PillPall.Data;
using PillPall.Models;

namespace PillPall.Views;


[QueryProperty("Item", "Item")]
public partial class DateItemPage : ContentPage
{
    public DateItem Item
    {
        get => BindingContext as DateItem;
        set => BindingContext = value;
    }

    //TimeSpan SelectedTime;

    DateItemDatabase database;

    public DateItemPage(DateItemDatabase dateItemDatabase)
    {
        InitializeComponent();
        database = dateItemDatabase;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.DayOfWeek))
        {
            await DisplayAlert("Name Required", "Please enter a name for the drug item.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
