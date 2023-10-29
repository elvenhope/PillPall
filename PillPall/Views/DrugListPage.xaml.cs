using System.Collections.ObjectModel;
using PillPall.Data;
using PillPall.Models;

namespace PillPall.Views;

public partial class DrugListPage : ContentPage
{
	DrugItemDatabase database;

    public ObservableCollection<DrugItem> Items { get; set; } = new();

    public DrugListPage(DrugItemDatabase drugItemDatabase)
	{
		InitializeComponent();

		database = drugItemDatabase;
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
        await Shell.Current.GoToAsync(nameof(DrugItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new DrugItem()
        });
    }

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not DrugItem item)
            return;

        await Shell.Current.GoToAsync(nameof(DrugItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}
