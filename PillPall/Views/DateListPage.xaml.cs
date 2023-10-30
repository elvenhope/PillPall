using System.Collections.ObjectModel;
using PillPall.Data;
using PillPall.Models;

namespace PillPall.Views;

public partial class DateListPage : ContentPage
{
    DateItemDatabase database;

    public ObservableCollection<DateItem> Items { get; set; } = new();

    public DateListPage(DateItemDatabase dateItemDatabase)
    {
        InitializeComponent();

        database = dateItemDatabase;
        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);

        });
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DateItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new DateItem()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not DateItem item)
            return;

        await Shell.Current.GoToAsync(nameof(DateItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}
